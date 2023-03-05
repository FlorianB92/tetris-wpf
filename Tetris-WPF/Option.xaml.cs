using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Tetris_WPF
{
    /// <summary>
    /// Interaktionslogik für Option.xaml
    /// </summary>
    public partial class Option : Window
    {
        public Option()
        {
            InitializeComponent();
        }

        private void backbutton_Click(object sender, RoutedEventArgs e)
        {
            Start start= new Start();
            start.Show();
            this.Close();
        }
    }
}
