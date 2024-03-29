﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Tetris_WPF.Class;

namespace Tetris_WPF
{

    public partial class Game : Window
    {
        GameField field = new GameField(10, 21);
        public Game()
        {
            InitializeComponent();
            field.StartGame(gamegrid, endscreen, score, endscore, nextblock);
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (field.gameOn)
            {
                if (e.Key == Key.D)
                {
                    field.goRight = true;
                    field.goRotation = false;
                }

                if (e.Key == Key.A)
                {
                    field.goLeft = true;
                    field.goRotation = false;
                }

                if (e.Key == Key.S)
                {
                    field.goFDown = true;
                    field.goRotation = false;
                }

                if (e.Key == Key.Space)
                {
                    field.Rotation();
                }
            
                if (e.Key == Key.P)
                {
                    if (field.timer.IsEnabled)
                    {
                        field.timer.Stop();
                        pause.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        field.timer.Start();
                        pause.Visibility = Visibility.Hidden;
                    }
                }
            }
            if(e.Key == Key.Escape)
            {
                Start start = new Start();
                start.Show();
                this.Close();
                
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                field.goRight = false;
            }

            if (e.Key == Key.A)
            {
                field.goLeft = false;
            }

            if (e.Key == Key.S)
            {
                field.goFDown = false;
            }
        }
    }
}
