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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized; //equally easy in CS as in XAML
            uxSubmit.IsEnabled = false;
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            //if (string.IsNullOrEmpty(uxName.Text) || string.IsNullOrEmpty(uxPassword.Text))
            //{
            //    uxSubmit.IsEnabled = false;
            //}
            //else
            //{ uxSubmit.IsEnabled = true; }
            UpdateInterface();
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            //if (string.IsNullOrEmpty(uxName.Text) || string.IsNullOrEmpty(uxPassword.Text))
            //{
            //    uxSubmit.IsEnabled = false;
            //}
            //else
            //{ uxSubmit.IsEnabled = true; }
            UpdateInterface();
        }

        //private void textBoxes_TextChanged(object sender, EventArgs e)
        //{
        //    UpdateInterface();
        //}

        private void UpdateInterface()
        {
            if ((!string.IsNullOrEmpty(uxName.Text)) && (!string.IsNullOrEmpty(uxPassword.Text)))
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }
        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password: " + uxPassword.Text);
        }
    }

}

