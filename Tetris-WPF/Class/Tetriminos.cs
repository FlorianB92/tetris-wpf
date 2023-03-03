using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tetris_WPF.Class
{
    internal class Tetriminos
    {
        public Brush color { get; set; }
        public int[] currentRow { get; set; }
        public int[] currentCol { get; set; }

        public int rotation { get; set; }

        public int id;

        public Tetriminos(int id)
        {
            color = Brushes.Transparent;
            currentRow = currentRow;
            currentCol = currentCol;
            this.id = id;
            rotation = rotation;
        }
        public void GiveAColor()
        {
            switch (id)
            {
                case 0: //ClevelandZ
                    color = Brushes.Red;
                    int[] col = { 3, 4, 4, 5 };
                    int[] row = { 0, 0, 1, 1 };
                    currentCol = col;
                    currentRow = row;
                    break;

                case 1: //Hero
                    color = Brushes.Blue;
                    int[] col1 = { 3, 4, 5, 6, };
                    int[] row1 = { 0, 0, 0, 0 };
                    currentCol = col1;
                    currentRow = row1;
                    break;

                case 2: //RhodeIslandZ
                    color = Brushes.Green;
                    int[] col2 = { 5, 4, 4, 3 };
                    int[] row2 = { 0, 0, 1, 1 };
                    currentCol = col2;
                    currentRow = row2;
                    break;
                case 3: //RickyB
                    color = Brushes.BlueViolet;
                    int[] col3 = { 3, 3, 4, 5 };
                    int[] row3 = { 0, 1, 1, 1 };
                    currentCol = col3;
                    currentRow = row3;
                    break;
                case 4: //Ricky0
                    color = Brushes.Orange;
                    int[] col4 = { 5, 5, 4, 3 };
                    int[] row4 = { 0, 1, 1, 1 };
                    currentCol = col4;
                    currentRow = row4;
                    break;
                case 5: //Smashboy
                    color = Brushes.Yellow;
                    int[] col5 = { 3, 3, 4, 4 };
                    int[] row5 = { 0, 1, 0, 1 };
                    currentCol = col5;
                    currentRow = row5;
                    break;
                case 6: //Teewee
                    color = Brushes.Violet;
                    int[] col6 = { 4, 3, 4, 5 };
                    int[] row6 = { 0, 1, 1, 1 };
                    currentCol = col6;
                    currentRow = row6;
                    break;

                default: break;
            }
        }

        public void Rotation()
        {
            switch (id)
            {
                case 0:
                    switch (rotation)
                    {
                        case 0:
                            currentCol[0] = currentCol[0];
                            currentRow[0] = currentRow[0];
                            currentCol[1] = currentCol[1];
                            currentRow[1] = currentRow[1];
                            currentCol[2] = currentCol[2];
                            currentRow[2] = currentRow[2];
                            currentCol[3] = currentCol[3];
                            currentRow[3] = currentRow[3];
                            break;

                        case 1:
                            currentCol[0] = currentCol[0] + 2;
                            currentRow[0] = currentRow[0] - 1;
                            currentCol[1] = currentCol[1] + 1;
                            currentRow[2] = currentRow[2] - 1;
                            currentCol[3] = currentCol[3] - 1;
                            break;
                        case 2:
                            currentCol[0] = currentCol[0] - 2;
                            currentRow[0] = currentRow[0] + 1;
                            currentCol[1] = currentCol[1] - 1;
                            currentRow[2] = currentRow[2] + 1;
                            currentCol[3] = currentCol[3] + 1;
                            break;

                    }
                    break;

                case 1:
                    switch (rotation)
                    {
                        case 0:
                            currentCol[0] = currentCol[0];
                            currentRow[0] = currentRow[0];
                            currentCol[1] = currentCol[1];
                            currentRow[1] = currentRow[1];
                            currentCol[2] = currentCol[2];
                            currentRow[2] = currentRow[2];
                            currentCol[3] = currentCol[3];
                            currentRow[3] = currentRow[3];
                            break;

                        case 1:
                            currentCol[0] = currentCol[0] + 2;
                            currentRow[0] = currentRow[0] - 2;
                            currentCol[1] = currentCol[1] + 1;
                            currentRow[1] = currentRow[1] - 1;
                            currentCol[3] = currentCol[3] - 1;
                            currentRow[3] = currentRow[3] + 1;
                            break;

                        case 2:
                            currentCol[0] = currentCol[0] - 2;
                            currentRow[0] = currentRow[0] + 2;
                            currentCol[1] = currentCol[1] - 1;
                            currentRow[1] = currentRow[1] + 1;
                            currentCol[3] = currentCol[3] + 1;
                            currentRow[3] = currentRow[3] - 1;
                            break;
                    }
                    break;

                case 2:
                    switch (rotation)
                    {
                        case 0:
                            currentCol[0] = currentCol[0];
                            currentRow[0] = currentRow[0];
                            currentCol[1] = currentCol[1];
                            currentRow[1] = currentRow[1];
                            currentCol[2] = currentCol[2];
                            currentRow[2] = currentRow[2];
                            currentCol[3] = currentCol[3];
                            currentRow[3] = currentRow[3];
                            break;

                        case 1:
                            currentCol[0] = currentCol[0] - 1;
                            currentRow[0] = currentRow[0] - 1;
                            currentCol[2] = currentCol[2] + 1;
                            currentRow[2] = currentRow[2] - 1;
                            currentCol[3] = currentCol[3] + 2;
                            break;

                        case 2:
                            currentCol[0] = currentCol[0] + 1;
                            currentRow[0] = currentRow[0] + 1;
                            currentCol[2] = currentCol[2] - 1;
                            currentRow[2] = currentRow[2] + 1;
                            currentCol[3] = currentCol[3] - 2;
                            break;
                    }
                    break;

                case 3:
                    switch (rotation)
                    {
                        case 0:
                            currentCol[0] = currentCol[0];
                            currentRow[0] = currentRow[0];
                            currentCol[1] = currentCol[1];
                            currentRow[1] = currentRow[1];
                            currentCol[2] = currentCol[2];
                            currentRow[2] = currentRow[2];
                            currentCol[3] = currentCol[3];
                            currentRow[3] = currentRow[3];
                            break;

                        case 1:
                            currentCol[0] = currentCol[0] + 2;
                            currentCol[1] = currentCol[1] + 1;
                            currentRow[1] = currentRow[1] - 1;
                            currentCol[3] = currentCol[3] - 1;
                            currentRow[3] = currentRow[3] + 1;
                            break;

                        case 2:
                            currentRow[0] = currentRow[0] + 2;
                            currentCol[1] = currentCol[1] + 1;
                            currentRow[1] = currentRow[1] + 1;
                            currentCol[3] = currentCol[3] - 1;
                            currentRow[3] = currentRow[3] - 1;
                            break;

                        case 3:
                            currentCol[0] = currentCol[0] - 2;
                            currentCol[1] = currentCol[1] - 1;
                            currentRow[1] = currentRow[1] + 1;
                            currentCol[3] = currentCol[3] + 1;
                            currentRow[3] = currentRow[3] - 1;
                            break;

                        case 4:
                            currentRow[0] = currentRow[0] - 2;
                            currentCol[1] = currentCol[1] - 1;
                            currentRow[1] = currentRow[1] - 1;
                            currentCol[3] = currentCol[3] + 1;
                            currentRow[3] = currentRow[3] + 1;
                            break;
                    }
                    break;

                case 4:
                    switch (rotation)
                    {
                        case 0:
                            currentCol[0] = currentCol[0];
                            currentRow[0] = currentRow[0];
                            currentCol[1] = currentCol[1];
                            currentRow[1] = currentRow[1];
                            currentCol[2] = currentCol[2];
                            currentRow[2] = currentRow[2];
                            currentCol[3] = currentCol[3];
                            currentRow[3] = currentRow[3];
                            break;

                        case 1:
                            currentRow[0] = currentRow[0] + 2;
                            currentCol[1] = currentCol[1] - 1;
                            currentRow[1] = currentRow[1] + 1;
                            currentCol[3] = currentCol[3] + 1;
                            currentRow[3] = currentRow[3] - 1;
                            break;

                        case 2:
                            currentCol[0] = currentCol[0] - 2;
                            currentCol[1] = currentCol[1] - 1;
                            currentRow[1] = currentRow[1] - 1;
                            currentCol[3] = currentCol[3] + 1;
                            currentRow[3] = currentRow[3] + 1;
                            break;

                        case 3:
                            currentRow[0] = currentRow[0] - 2;
                            currentCol[1] = currentCol[1] + 1;
                            currentRow[1] = currentRow[1] - 1;
                            currentCol[3] = currentCol[3] - 1;
                            currentRow[3] = currentRow[3] + 1;
                            break;

                        case 4:
                            currentCol[0] = currentCol[0] + 2;
                            currentCol[1] = currentCol[1] + 1;
                            currentRow[1] = currentRow[1] + 1;
                            currentCol[3] = currentCol[3] - 1;
                            currentRow[3] = currentRow[3] - 1;
                            break;
                    }
                    break;

                case 6:
                    switch (rotation)
                    {
                        case 0:
                            currentCol[0] = currentCol[0];
                            currentRow[0] = currentRow[0];
                            currentCol[1] = currentCol[1];
                            currentRow[1] = currentRow[1];
                            currentCol[2] = currentCol[2];
                            currentRow[2] = currentRow[2];
                            currentCol[3] = currentCol[3];
                            currentRow[3] = currentRow[3];
                            break;

                        case 1:
                            currentCol[0] = currentCol[0] + 1;
                            currentRow[0] = currentRow[0] + 1;
                            currentCol[1] = currentCol[1] + 1;
                            currentRow[1] = currentRow[1] - 1;
                            currentCol[3] = currentCol[3] - 1;
                            currentRow[3] = currentRow[3] + 1;
                            break;

                        case 2:
                            currentCol[0] = currentCol[0] - 1;
                            currentRow[0] = currentRow[0] + 1;
                            currentCol[1] = currentCol[1] + 1;
                            currentRow[1] = currentRow[1] + 1;
                            currentCol[3] = currentCol[3] - 1;
                            currentRow[3] = currentRow[3] - 1;
                            break;

                        case 3:
                            currentCol[0] = currentCol[0] - 1;
                            currentRow[0] = currentRow[0] - 1;
                            currentCol[1] = currentCol[1] - 1;
                            currentRow[1] = currentRow[1] + 1;
                            currentCol[3] = currentCol[3] + 1;
                            currentRow[3] = currentRow[3] - 1;
                            break;

                        case 4:
                            currentCol[0] = currentCol[0] + 1;
                            currentRow[0] = currentRow[0] - 1;
                            currentCol[1] = currentCol[1] - 1;
                            currentRow[1] = currentRow[1] - 1;
                            currentCol[3] = currentCol[3] + 1;
                            currentRow[3] = currentRow[3] + 1;
                            break;
                    }
                    break;
            }
        }
    }
}
