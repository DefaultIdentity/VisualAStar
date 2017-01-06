using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAStar
{
    class Grid
    {
        public Cell[,]  grid        { get; }
        public int      rows        { get; }
        public int      cols        { get; }
        public int      size        { get; }

        public Grid(int rows, int cols, int pObst)
        {
            this.rows   = rows;
            this.cols   = cols;
            this.size   = rows * cols;

            grid        = new Cell[rows, cols]; /* 8 for cardinal directions */

            Random r    = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = new Cell(i, j);

                    /* If we want obstacles */
                    if (pObst != 0)
                    {
                        if (r.Next(pObst) == 0)
                            grid[i, j].isPassable = false;
                    }
                }
            }
        }

        /* Clears the grid without altering the structure */
        public void Clear()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j].isPassable)
                        grid[i, j] = new Cell(i, j);
                }
            }
        }

        /* This Heuristic Calculation prioritizes nodes along the straight path from the root to the destination */
        public double CalcHCross(Cell curr, Cell dest, Cell root)
        {
            double dX = Math.Abs(curr.col - dest.col);
            double dY = Math.Abs(curr.row - dest.row);

            double crossDX1 = curr.col - dest.col;
            double crossDY1 = curr.row - dest.row;
            double crossDX2 = root.col - dest.col;
            double crossDY2 = root.row - dest.row;

            double cross = Math.Abs((crossDX1 * crossDY2) - (crossDX2 * crossDY1));

            /* 2.0 is a weight for a faster search, and the cross product gets added at 1/100th scale */
            return ((Math.Sqrt((dX * dX) + (dY * dY)) * 2.0) + (cross * 0.01));
        }

        /* This is a fast Heuristic Calculation only taking into account 4 directions */
        public double CalcHFast(Cell curr, Cell dest)
        {
            /* 1.05 is a weight to break ties */
            return (1.05 * (Math.Abs(curr.col - dest.col) + Math.Abs(curr.row - dest.row)));
        }

        /* This is the generic Euclidian Distance calculation taking into account diagonals */
        public double CalcHFastDiag(Cell curr, Cell dest)
        {
            double dX = Math.Abs(curr.col - dest.col);
            double dY = Math.Abs(curr.row - dest.row);

            /* 1.412 is the length of a diagonal of a 1x1 square, for weighting nicely */
            return (Math.Sqrt((dX * dX) + (dY * dY)) * 1.412);
        }

        public Stack<Cell> Search(int rootRow, int rootCol, int destRow, int destCol, int mode)
        {
            CellHeap openSet = new CellHeap();

            Cell root = grid[rootRow, rootCol];
            Cell dest = grid[destRow, destCol];

            // Set the root/destination cells to passable if they werent already
            root.isPassable = true;
            dest.isPassable = true;

            /* Set up neighbor adjacency lists, needs to be down here after obstacles, root, and dest are set */
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // North
                    if ((i > 0) && (grid[i - 1, j].isPassable))
                        grid[i, j].neighbors[0] = grid[i - 1, j];

                    // East
                    if ((j + 1 < cols) && (grid[i, j + 1].isPassable))
                        grid[i, j].neighbors[1] = grid[i, j + 1];

                    // South
                    if ((i + 1 < rows) && (grid[i + 1, j].isPassable))
                        grid[i, j].neighbors[2] = grid[i + 1, j];

                    // West
                    if ((j > 0) && (grid[i, j - 1].isPassable))
                        grid[i, j].neighbors[3] = grid[i, j - 1];

                    // North-East
                    if ((i > 0) && (j + 1 < cols) && grid[i - 1, j + 1].isPassable)
                        grid[i, j].neighbors[4] = grid[i - 1, j + 1];

                    // South-East
                    if ((i + 1 < rows) && (j + 1 < cols) && grid[i + 1, j + 1].isPassable)
                        grid[i, j].neighbors[5] = grid[i + 1, j + 1];

                    // South-West
                    if ((i + 1 < rows) && (j > 0) && grid[i + 1, j - 1].isPassable)
                        grid[i, j].neighbors[6] = grid[i + 1, j - 1];

                    // North-West
                    if ((i > 0) && (j > 0) && grid[i - 1, j - 1].isPassable)
                        grid[i, j].neighbors[7] = grid[i - 1, j - 1];
                }
            }

            bool found = false;

            root.f = 0.0;
            root.g = 0.0;
            root.h = 0.0;

            openSet.Insert(root);

            /* 4 neighbors for N/S/E/W for 4 directional modes, else 8 neighbors */
            int numNeighbors = (mode <= 2) ? 4 : 8;

            while (!found)
            {
                Cell curr;
                if (openSet.Peek() == null)
                    break;

                curr = openSet.ExtractMin();
                double min = curr.f;

                /* If minimum f value is max double, the destination is impossible */
                if (min == double.MaxValue)
                {
                    Console.WriteLine(min);
                    break;
                }

                curr.isVisited = true;

                /* We have found the destination */
                if (curr.row == dest.row && curr.col == dest.col)
                {
                    Console.WriteLine("Found.");
                    Stack<Cell> path = new Stack<Cell>();

                    while(curr.prev != null)
                    {
                        path.Push(curr);
                        curr = curr.prev;
                    }

                    return path;
                }

                for (int i = 0; i < numNeighbors; i++)
                {
                    //Console.WriteLine(i);
                    /* If neighbor is not possible, continue */
                    if (curr.neighbors[i] == null)
                        continue;
                    //else if (curr.neighbors[i].isVisited)
                    //    continue;

                    double tempG = curr.g + 1.0;
                    double tempH = 0.0;

                    if (mode == 0) // 4 Directional Fast
                        tempH = CalcHFast(curr.neighbors[i], dest);
                    else if (mode == 1) // 4 directional cross product
                        tempH = CalcHCross(curr.neighbors[i], dest, root);
                    else if (mode == 2) // 4 directional Djikstra's
                        tempH = 0.0;
                    else if (mode == 3) // 8 directional cross product
                        tempH = CalcHCross(curr.neighbors[i], dest, root);
                    else if (mode == 4) // 8 Directional euclidian
                        tempH = CalcHFastDiag(curr.neighbors[i], dest);
                    else
                    {
                        Console.WriteLine("Invalid mode.");
                        return new Stack<Cell>();
                    }

                    double tempF = tempG + tempH;

                    //Console.WriteLine(tempF + " | " + curr.neighbors[i].f);

                    if (curr.neighbors[i].f > tempF)
                    {
                        curr.neighbors[i].g = tempG;
                        curr.neighbors[i].h = tempH;
                        curr.neighbors[i].f = tempF;
                        curr.neighbors[i].prev = curr;

                        openSet.Insert(curr.neighbors[i]);
                    }
                }
            }

            return new Stack<Cell>();
        }
    }
}
