using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tetris_WPF
{
    public class GameField
    {
        private readonly int[,] grid;
        private int Rows { get; }
        private int Columns { get; }

        public int this[int r, int c]
        {
            get => grid[r, c];
            set=> grid[r, c] = value;
        }

        public GameField(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid =  new int[rows, columns];
        }
    }
}
