using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tetris_WPF
{
    public class GameField
    {
        private readonly int[,] grid;
        public int Rows { get; set; }
        public int Columns { get; set; }

        public GameField()
        {
            // Create the grid
            Grid gameField = new Grid();
            gameField.Width = 220;
            gameField.Height = 500;
            gameField.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            gameField.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            gameField.ShowGridLines = true;
            gameField.Background = Brushes.Yellow;

            // Define the Columns
            ColumnDefinition[] colDef = new ColumnDefinition[Columns];
            for(int i = 0; i < Columns; i++)
            {
                colDef[i] = new ColumnDefinition();
                gameField.ColumnDefinitions.Add(colDef[i]);
            }

            // Define the Rows
            RowDefinition[] rowDef = new RowDefinition[Rows];
            for(int i = 0; i < Rows; i++)
            {
                rowDef[i] = new RowDefinition();
                gameField.RowDefinitions.Add(rowDef[i]);
            }

            // Add the Grid as the Content of the Parent Window Object
        }
    }
}
