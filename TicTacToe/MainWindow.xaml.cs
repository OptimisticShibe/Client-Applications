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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        //Counter to determine "turn."
        private int counter;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Ensures X goes first when window loaded
            counter = 1;
            uxTurn.Text = "It's X's Turn";
        }
        

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button butt = sender as Button;
            // Determining X's turn
            if (counter == 1)
            {
                butt.Content = "X";
                uxTurn.Text = "It's O's Turn";
            }

            // Determining O's turn
            else
            {
                butt.Content = "O";
                uxTurn.Text = "It's X's Turn";
            }

            //Increasing counter
            counter += 1;
            if (counter > 2)
            {
                counter = 1;
            }
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
