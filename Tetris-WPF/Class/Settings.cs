using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_WPF
{
    internal class Settings
    {
        private static int Width { get; set; }
        private static int Height { get; set; }

        private static string direction;

        public Settings()
        {
            Width = 20;
            Height = 20;
            direction = "down";
        }
    }
}
