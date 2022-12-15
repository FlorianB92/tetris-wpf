using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Tetris_WPF
{
    internal class Block
    {
        private Point curPosition;
        private Point[] objectShape;
        private Brush color;
        private bool rotation;

        public Block()
        {
            curPosition= new Point(0, 0);
            color = Brushes.Transparent;
            objectShape = RandomShape();
        }

        private Point[] RandomShape()
        {
            Random rand = new Random();

            switch (rand.Next() % 7)
            {
                case 0 ://ClevelandZ
                    rotation= true;
                    color = Brushes.Red;
                    return new Point[]
                    {
                        new Point(3,0),
                        new Point(4,0),
                        new Point(4,1),
                        new Point(5,1)
                    };
                case 1://Hero
                    rotation = true;
                    color = Brushes.Blue;
                    return new Point[]
                    {
                        new Point(3,0),
                        new Point(4,0),
                        new Point(5,0),
                        new Point(6,0)
                    };
                case 2://RhodeIslandZ
                    rotation = true;
                    color = Brushes.Green;
                    return new Point[]
                    {
                        new Point(5,0),
                        new Point(4,0),
                        new Point(4,1),
                        new Point(3,1)
                    };
                case 3://RickyB
                    rotation = true;
                    color = Brushes.BlueViolet;
                    return new Point[]
                    {
                        new Point(3,0),
                        new Point(3,1),
                        new Point(4,1),
                        new Point(5,1)
                    };
                case 4://RickyO
                    rotation = true;
                    color = Brushes.Orange;
                    return new Point[]
                    {
                        new Point(5,0),
                        new Point(5,1),
                        new Point(4,1),
                        new Point(3,1)
                    };
                case 5://Smashboy
                    rotation = true;
                    color = Brushes.Yellow;
                    return new Point[]
                    {
                        new Point(3,0),
                        new Point(3,1),
                        new Point(4,0),
                        new Point(4,1)
                    };
                case 6://Teewee
                    rotation = true;
                    color = Brushes.Violet;
                    return new Point[]
                    {
                        new Point(4,0),
                        new Point(3,1),
                        new Point(4,1),
                        new Point(5,1)
                    };

                default: return null;
            }
        }
    }
}
