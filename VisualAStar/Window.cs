using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualAStar
{
    public partial class Window : Form
    {
        private Graphics bg;
        private Graphics fg;
        private Graphics g;

        private Bitmap background;
        private Bitmap foreground;
        private Bitmap scene;

        private bool bRefresh;
        private bool fRefresh;

        private Grid aStar;

        private int cellsize = 20;

        private int rows = 30;
        private int cols = 30;
        private int pObst = 4;

        private int rootRow = 0;
        private int rootCol = 0;
        private int destRow = 29;
        private int destCol = 29;

        private bool pathFound = false;
        private Point[] path;

        private bool showPath = true;
        private bool showVals = false;

        private bool destPick = false;

        private int pCount;

        private int mode = 1;


        
        public Window()
        {
            InitializeComponent();

            background = new Bitmap(this.ViewBox.Width, this.ViewBox.Height);
            foreground = new Bitmap(this.ViewBox.Width, this.ViewBox.Height);
            scene = new Bitmap(this.ViewBox.Width, this.ViewBox.Height);

            bg = Graphics.FromImage(background);
            fg = Graphics.FromImage(foreground);
            g = Graphics.FromImage(scene);

            rows = int.Parse(RowsBox.Text);
            cols = int.Parse(ColsBox.Text);
            pObst = int.Parse(ProbObstacleBox.Text);

            aStar = new Grid(rows, cols, pObst);

            rootRow = int.Parse(RootRowBox.Text);
            rootCol = int.Parse(RootColBox.Text);
            destRow = int.Parse(DestRowBox.Text);
            destCol = int.Parse(DestColBox.Text);

            ModeBox.SelectedIndex = 0;

            pathFound = false;

            bRefresh = true;
            fRefresh = true;

            Draw(); 
        }

        private void Draw()
        {
            if (bRefresh)
                DrawBackground();

            if (fRefresh)
                DrawForeground();

            g.DrawImage(background, 0, 0);
            g.DrawImage(foreground, 0, 0);

            this.ViewBox.Image = scene;
            this.ViewBox.Refresh();
        }

        private void DrawBackground()
        {
            SolidBrush lineBrush = new SolidBrush(Color.FromArgb(65, 65, 65));
            SolidBrush backBrush = new SolidBrush(Color.FromArgb(224, 224, 224));
            SolidBrush rootBrush = new SolidBrush(Color.Green);
            SolidBrush destBrush = new SolidBrush(Color.Red);
            Pen linePen = new Pen(Color.FromArgb(65, 65, 65), 1);

            bg.Clear(Color.White);
            bg.FillRectangle(backBrush, new Rectangle(10, 10, cols * cellsize, rows * cellsize));
            for (int i = 0; i <= cols; i++)
                bg.DrawLine(linePen, 10 + (i * cellsize), 10, 10 + (i * cellsize), 10 + (rows * cellsize));
            for (int i = 0; i <= rows; i++)
                bg.DrawLine(linePen, 10, 10 + (i * cellsize), 10 + (cols * cellsize), 10 + (i * cellsize));

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (!aStar.grid[i, j].isPassable)
                        bg.FillRectangle(lineBrush, new Rectangle(10 + (j * cellsize), 10 + (i * cellsize), cellsize, cellsize));

            bRefresh = false;
        }

        private void DrawForeground()
        {
            SolidBrush rootBrush = new SolidBrush(Color.Green);
            SolidBrush destBrush = new SolidBrush(Color.Red);
            SolidBrush lineBrush = new SolidBrush(Color.Black);
            Pen linePen = new Pen(Color.FromArgb(65, 65, 65), 1);

            fg.Clear(Color.Transparent);

            fg.FillRectangle(rootBrush, new Rectangle(10 + (rootCol * cellsize), 10 + (rootRow * cellsize), cellsize, cellsize));
            fg.FillRectangle(destBrush, new Rectangle(10 + (destCol * cellsize), 10 + (destRow * cellsize), cellsize, cellsize));

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (((i == destRow) && (j == destCol)) || ((i == rootRow) && (j == rootCol)))
                        continue;

                    if (aStar.grid[i, j].f != double.MaxValue)
                    {
                        Rectangle r = new Rectangle(10 + (j * cellsize), 10 + (i * cellsize), cellsize, cellsize);
                        double color;

                        // Get the distance between the source and destination
                        double dX = Math.Abs(rootRow - destRow);
                        double dY = Math.Abs(rootCol - destCol);
                        double p = 1.2;
                        if (mode == 3)
                            p = 2.0;

                        // Sets up the range for the h value color estimator
                        double max = Math.Sqrt((dX * dX) + (dY * dY)) * p;

                        // Uses the max to figure out what to color each node
                        color = 200 - (((aStar.grid[i, j].h) / max) * 200);
                        if (color > 200)
                            color = 200;
                        else if (color < 0)
                            color = 0;

                        // Color gets more blue the closer it gets to the destination and more red the farther away.
                        Color hColor = Color.FromArgb(255 - (int)color, (int)color + 55, (int)color + 55);
                        SolidBrush hBrush = new SolidBrush(hColor);
                        fg.FillRectangle(hBrush, r);
                        fg.DrawRectangle(linePen, r);

                        if (showVals)
                            fg.DrawString(aStar.grid[i, j].h.ToString("#.#"), new Font("Arial", cellsize / 3), lineBrush, 11 + (j * cellsize), 14 + (i * cellsize));
                    }
                }
            }

            if (pathFound && showPath)
            {
                if (!showVals && path.Length > 0)
                {
                    fg.DrawLine(linePen, (path[0].X * cellsize) + (cellsize / 2) + 10, (path[0].Y * cellsize) + (cellsize / 2) + 10, (rootCol * cellsize) + (cellsize / 2) + 10, (rootRow * cellsize) + (cellsize / 2) + 10);
                }

                for (int i = 0; i < path.Length; i++)
                {
                    Point curr = path[i];
                    if (showVals)
                    {
                        Rectangle r = new Rectangle(11 + (curr.X * cellsize), 11 + (curr.Y * cellsize), cellsize, cellsize);
                        fg.DrawRectangle(System.Drawing.Pens.Yellow, r);
                    }
                    else
                    {
                        if (i > 0)
                        {
                            fg.DrawLine(linePen, (path[i - 1].X * cellsize) + (cellsize / 2) + 10, (path[i - 1].Y * cellsize) + (cellsize / 2) + 10, (curr.X * cellsize) + (cellsize / 2) + 10, (curr.Y * cellsize) + (cellsize / 2) + 10);
                        }
                    }
                }
            }

            fRefresh = false;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            rootRow = int.Parse(RootRowBox.Text);
            rootCol = int.Parse(RootColBox.Text);
            destRow = int.Parse(DestRowBox.Text);
            destCol = int.Parse(DestColBox.Text);

            mode = ModeBox.SelectedIndex;

            if (rootRow < 0)
                rootRow = 0;
            else if (rootRow >= rows)
                rootRow = rows - 1;

            if (rootCol < 0)
                rootCol = 0;
            else if (rootCol >= cols)
                rootCol = cols - 1;

            if (destRow < 0)
                destRow = 0;
            else if (destRow >= rows)
                destRow = rows - 1;

            if (destCol < 0)
                destCol = 0;
            else if (destCol >= cols)
                destCol = cols - 1;

            RootRowBox.Text = rootRow + "";
            RootColBox.Text = rootCol + "";
            DestRowBox.Text = destRow + "";
            DestColBox.Text = destCol + "";

            if (pathFound)
                aStar.Clear();

            Stack<Cell> temp = aStar.Search(rootRow, rootCol, destRow, destCol, mode);
            this.path = new Point[temp.Count];
            pCount = path.Length;
            
            for (int i = 0; i < pCount; i++)
            {
                Cell tCell = temp.Pop();
                path[i] = new Point(tCell.col, tCell.row);
            }

            pathFound = true;

            fRefresh = true;

            Draw();
        }

        private void NewMapButton_Click(object sender, EventArgs e)
        {
            rows = int.Parse(RowsBox.Text);
            cols = int.Parse(ColsBox.Text);
            pObst = int.Parse(ProbObstacleBox.Text);

            aStar = new Grid(rows, cols, pObst);

            rootRow = int.Parse(RootRowBox.Text);
            rootCol = int.Parse(RootColBox.Text);
            destRow = int.Parse(DestRowBox.Text);
            destCol = int.Parse(DestColBox.Text);

            this.cellsize = int.Parse(CellSizeBox.Text);

            aStar = new Grid(rows, cols, pObst);

            pCount = 0;
            pathFound = false;

            background = new Bitmap(this.ViewBox.Width, this.ViewBox.Height);
            foreground = new Bitmap(this.ViewBox.Width, this.ViewBox.Height);
            scene = new Bitmap(this.ViewBox.Width, this.ViewBox.Height);

            bg = Graphics.FromImage(background);
            fg = Graphics.FromImage(foreground);
            g = Graphics.FromImage(scene);

            if ((cellsize * rows) > (this.ViewBox.Height - 20))
            {
                cellsize = (this.ViewBox.Height - 20) / rows;
                this.CellSizeBox.Text = cellsize + "";
            }

            if ((cellsize * cols) > (this.ViewBox.Width - 20))
            {
                cellsize = (this.ViewBox.Width - 20) / cols;
                this.CellSizeBox.Text = cellsize + "";
            }

            bRefresh = true;
            fRefresh = true;

            Draw();
        }

        private void ShowPathBox_CheckedChanged(object sender, EventArgs e)
        {
            showPath = ShowPathBox.Checked;
            fRefresh = true;
            Draw();
        }

        private void ShowValsBox_CheckedChanged(object sender, EventArgs e)
        {
            showVals = ShowValsBox.Checked;
            fRefresh = true;
            Draw();
        }

        private void ViewBox_MouseClick(object sender, MouseEventArgs e)
        {
            int cellRow = (e.Y - 10) / cellsize;
            int cellCol = (e.X - 10) / cellsize;
            if ((cellCol < cols) && (cellCol >= 0) && (cellRow < rows) && (cellRow >= 0))
            {
                if (destPick)
                {
                    destRow = cellRow;
                    destCol = cellCol;
                    DestRowBox.Text = cellRow + "";
                    DestColBox.Text = cellCol + "";
                    destPick = false;
                    aStar.Clear();
                    pathFound = false;
                    fRefresh = true;
                    Draw();
                }
                else
                {
                    rootRow = cellRow;
                    rootCol = cellCol;
                    RootRowBox.Text = cellRow + "";
                    RootColBox.Text = cellCol + "";
                    destPick = true;
                    aStar.Clear();
                    pathFound = false;
                    fRefresh = true;
                    Draw();
                }
            }
        }
    }
}
