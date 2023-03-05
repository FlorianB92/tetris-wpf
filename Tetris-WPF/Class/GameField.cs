using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace Tetris_WPF.Class
{
    internal class GameField
    {
        private int columns, rows;
        public DispatcherTimer timer = new DispatcherTimer();
        private List<Rectangle> Rlist = new List<Rectangle>();
        private List<Rectangle> DRlist = new List<Rectangle>();
        private List<Tetriminos> block = new List<Tetriminos>();

        public bool goLeft, goRight, goDown, goFDown, goRotation, gameOn;
        bool[] numbers = new bool[7];
        public string richtung;
        int randomNumber;
        int anzahl = 0;
        int sc = 0;

        Random rand = new Random();

        public GameField(int columns, int rows)
        {
            this.columns = columns;
            this.rows = rows;
        }

        public void StartGame(Grid grid, Grid endscreen, Label score, Label endscore, Image nextblock)
        {
            gameOn = true; // um die Steuerung freizuschalten
            randomNumber = rand.Next(0, 7);
            AddGridDefinition(grid);
            CreateBlock(grid);
            Timer(grid, endscreen, score, endscore, nextblock);
        }

        public void AddGridDefinition(Grid grid)
        {
            for (int i = 0; i < columns; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                ColumnDefinition columnDefinition = grid.ColumnDefinitions[i];
            }
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                RowDefinition rowDefinition = grid.RowDefinitions[i]; ;
            }
        }

        public void CreateBlock(Grid grid)
        {                   
            Tetriminos nblock = new Tetriminos(randomNumber);
            nblock.GiveAColor();
            block.Add(nblock);
            numbers[randomNumber] = true;
            AddToBoard(grid);
            block[0].Rotation();
            block[0].rotation = 0;
            timer.Start();
            randomNumber = rand.Next(0, 7);

            //eine Überprüfung ob alle Zahlen auf true gesetzt sind, falls ja werden sie auf false gesetzt
            for (int i = 0; i < 7; i++)
            {
                int rnd = randomNumber;
                if (anzahl == 7)
                {
                    for (int a = 0; a < 7; a++)
                    {
                        numbers[a] = false;
                    }
                    anzahl = 0;
                }
                if (numbers[rnd] == true)
                {
                    anzahl++;
                    i--;
                    randomNumber = rand.Next(0, 7);
                }
                else
                {
                    anzahl = 0;
                    randomNumber = rnd;
                }                 
            }
        }

        public void AddToBoard(Grid grid)
        {
            for (int i = 0; i < 4; i++)
            {
                Rectangle a = new Rectangle();
                Brush color = block[0].color;
                a.Fill = color;
                Grid.SetColumn(a, block[0].currentCol[i]);
                Grid.SetRow(a, block[0].currentRow[i] + 1);
                Rlist.Add(a);
                grid.Children.Add(a);
            }

            goDown = true;
            goRotation = true;
        }

        public void AddBlocktoList(Grid grid)
        {
            for (int i = 0; i < 4; i++)
            {
                DRlist.Add(Rlist[i]);
            }

            Rlist.Clear();
            block.Clear();
            CreateBlock(grid);
        }

        public void Update(object sender, EventArgs e, Grid grid, Grid endscreen, Label score ,Label endscore, Image nextblock)
        {
            // die Methode richtet sich nach dem interval des Timers
            ShowNextBlock(nextblock);
            CheckLines(grid, endscreen, score, endscore);
            Move(grid, endscreen, score, endscore);
            for (int i = 0; i < 4; i++)
            {
                Grid.SetColumn(Rlist[i], block[0].currentCol[i]);
                Grid.SetRow(Rlist[i], block[0].currentRow[i]);
            }
        }

        public void Timer(Grid grid, Grid endscreen, Label score, Label endscore, Image nextblock)
        {
            timer.Interval = TimeSpan.FromSeconds(0.2);
            timer.Tick += (sender, e) =>
            {
                Update(sender, e, grid, endscreen, score, endscore, nextblock);
            };
        }

        private void Move(Grid grid, Grid endscreen, Label score, Label endscore)
        {
            if (goDown)
            {
                richtung = "down";
            }
            if (goFDown)
            {
                richtung = "fdown";
            }
            if (goLeft)
            {
                richtung = "left";
            }
            if (goRight)
            {
                richtung = "right";
            }

            for (int i = 0; i < 4; ++i)
            {
                switch (richtung)
                {
                    case "left":
                        block[0].currentCol[i]--;
                        break;
                    case "right":
                        block[0].currentCol[i]++;
                        break;
                    case "down":
                        timer.Interval = TimeSpan.FromSeconds(0.2);
                        block[0].currentRow[i]++;
                        break;
                    case "fdown":
                        timer.Interval = TimeSpan.FromSeconds(0.1);
                        block[0].currentRow[i]++;
                        break;
                }
            }
        }

        public void Rotation()
        {
            if (goRotation)
            {
                block[0].rotation++;
                if (block[0].id == 0 || block[0].id == 1 || block[0].id == 2) 
                {
                    if (block[0].rotation > 2) // hier wird verhindert das der Wert über den der Rotation übersteigt
                    {
                        block[0].rotation = 0;
                        block[0].Rotation();
                    }
                    else
                    {
                        block[0].Rotation();
                    }
                }

                else if (block[0].id == 3 || block[0].id == 4 || block[0].id == 6)
                {
                    if (block[0].rotation > 4)
                    {
                        block[0].rotation = 0;
                        block[0].Rotation();
                    }
                    else
                    {
                        block[0].Rotation();
                    }
                }
            }
        }

        private void CheckLines(Grid grid, Grid endscreen, Label score, Label endscore)
        {
            // Außenränder und Boden kollision
            for (int i = 0; i < 4; i++)
            {
                if (block[0].currentCol[i] == 0)
                {
                    goLeft = false;
                    richtung = "down";

                }
                if (block[0].currentCol[i] == 9)
                {
                    goRight = false;
                    richtung = "down";
                }
                if (block[0].currentRow[i] == 0)
                {
                    goRotation = false;
                }
                if (block[0].currentRow[i] == 20)
                {
                    goDown = false;
                    richtung = "";
                    timer.Stop();
                    AddBlocktoList(grid);
                    ClearLines(grid, score);
                }
            }
            //Kollisionsabfrage mit anderen Steinen
            foreach (Rectangle r in DRlist)
            {
                int col = Grid.GetColumn(r);
                int row = Grid.GetRow(r);
                bool collision = false;

                for (int i = 0; i < 4; i++)
                {
                    if (block[0].currentRow[i] + 1 == row && block[0].currentCol[i] == col)
                    {
                        if(row == 3)
                        {
                            collision = true;
                            GameOver(endscore, endscreen);

                        }
                        else
                        {
                            timer.Stop();
                            AddBlocktoList(grid);
                            ClearLines(grid, score);
                            collision = true;
                            break;
                        }                       
                    }
                }
                if (collision)
                {
                    break;
                }
            }

            //Rotation nicht außerhalb des Grids
            for (int i = 0; i < 4; i++)
            {
                if (block[0].id == 1)
                {
                    if (block[0].rotation == 0)
                    {
                        if (block[0].currentCol[i] < 2 || block[0].currentCol[i] > 9)
                        {
                            goRotation = false;
                        }
                        else
                        {
                            goRotation = true;
                        }
                    }
                    else if (block[0].currentCol[i] < 2 || block[0].currentCol[i] > 8)
                    {
                        goRotation = false;
                    }
                    else
                    {
                        goRotation = true;
                    }
                }
                else if (block[0].currentCol[i] < 1 || block[0].currentCol[i] > 8)
                {
                    goRotation = false;
                }
                else
                {
                    goRotation = true;
                }
            }
        }

        public void ClearLines(Grid grid, Label score)
        {
            // eine Methode zum leeren der Reihen, falls eine voll sein sollte
            List<UIElement> elements = new List<UIElement>();
            int multi = 0;
            for (int r = rows - 1; r > 0; r--)
            {
                for (int c = 0; c < 10; c++)
                {
                    UIElement element = grid.Children.Cast<UIElement>().FirstOrDefault(e => Grid.GetRow(e) == r && Grid.GetColumn(e) == c);

                    if (element != null)
                    {
                        elements.Add(element);
                    }
                }
                if (elements.Count == 10)
                {
                    foreach (Rectangle rr in elements)
                    {
                        DRlist.Remove(rr);
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        grid.Children.Remove(elements[i]);
                    }
                    elements.Clear();
                    multi++;

                    for (int nr = r; nr > 0; nr--)
                    {
                        for (int c = 0; c < 10; c++)
                        {
                            UIElement element = grid.Children.Cast<UIElement>().FirstOrDefault(e => Grid.GetRow(e) == nr && Grid.GetColumn(e) == c);
                            if (element != null)
                            {
                                Grid.SetRow(element, nr + 1);
                                Grid.SetColumn(element, c);
                                RepositionDRlist(nr, c);
                            }
                        }
                    }
                    r++;
                }
                else
                {
                    elements.Clear();
                }
            }
            if (multi == 1)
                sc = sc + 40;
            if (multi == 2)
                sc = sc + 100;
            if(multi == 3)
                sc = sc + 300;
            if (multi == 4)
                sc = sc + 1200; 
            score.Content = "Score: " + sc;
            multi = 0;
        }
        private void RepositionDRlist(int r, int i)
        {
            foreach (Rectangle rec in DRlist)
            {
                int col = Grid.GetColumn(rec);
                int row = Grid.GetRow(rec);
                if (row == r && col == i)
                {
                    Grid.SetRow(rec, r + 1);
                    Grid.SetColumn(rec, col);
                }
            }
        }

        private void GameOver(Label endscore, Grid endscreen)
        {
            gameOn = false;
            timer.Stop();
            goDown = false;
            richtung = "";
            timer.Interval = TimeSpan.FromSeconds(0);
            endscore.Content = "Endscore: " + sc;
            endscreen.Visibility = Visibility.Visible;
        }

        private void ShowNextBlock(Image nextblock)
        {
            // darstellung des nächsten Blocks
            string path;
            BitmapImage bitmap = new BitmapImage();
            switch (randomNumber)
            {
                case 0: //Cleveland                   
                    path = "pictures/ClevelandZ.png";
                    bitmap.BeginInit();
                    bitmap.UriSource= new Uri(path, UriKind.Relative);
                    bitmap.EndInit();
                    nextblock.Source = bitmap;
                    break;

                case 1: //Hero
                    path = "pictures/Hero.png";
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(path, UriKind.Relative);
                    bitmap.EndInit();
                    nextblock.Source = bitmap;
                    break;

                case 2: //RhodeIslandZ
                    path = "pictures/RhodeIslandZ.png";
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(path, UriKind.Relative);
                    bitmap.EndInit();
                    nextblock.Source = bitmap;
                    break;

                case 3: //RickyB
                    path = "pictures/BlueRicky.png";
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(path, UriKind.Relative);
                    bitmap.EndInit();
                    nextblock.Source = bitmap;
                    break;

                case 4: //RickyO
                    path = "pictures/OrangeRicky.png";
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(path, UriKind.Relative);
                    bitmap.EndInit();
                    nextblock.Source = bitmap;
                    break;

                case 5: //Smashboy
                    path = "pictures/Smashboy.png";
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(path, UriKind.Relative);
                    bitmap.EndInit();
                    nextblock.Source = bitmap;
                    break;

                case 6: //Teewee
                    path = "pictures/Teewee.png";
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(path, UriKind.Relative);
                    bitmap.EndInit();
                    nextblock.Source = bitmap;
                    break;
            }
        }
    }
}
