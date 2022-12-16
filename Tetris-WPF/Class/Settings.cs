using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_WPF
{
    internal class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static string direction;
        private static int id;

        public Settings()
        {
            Width = 20;
            Height = 20;
            direction = "down";
            id = 0;
        }
    }
}
