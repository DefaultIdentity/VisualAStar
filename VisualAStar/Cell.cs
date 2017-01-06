using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAStar
{
    /* Helper class to improve readability */
    class Cell
    {
        public int      row         { get; set; }
        public int      col         { get; set; }

        public double   f           { get; set; }
        public double   g           { get; set; }
        public double   h           { get; set; }

        public Cell     prev        { get; set; }
        public bool     isPassable  { get; set; }
        public bool     isVisited   { get; set; }

        public Cell[]   neighbors   { get; set; }

        public Cell(int row, int col)
        {
            this.row = row;
            this.col = col;

            f = double.MaxValue;
            g = double.MaxValue;
            h = double.MaxValue;

            prev        = null;
            isPassable  = true;
            isVisited   = false;

            // 8 for all cardinal directions;
            neighbors = new Cell[8];
        }
    }
}
