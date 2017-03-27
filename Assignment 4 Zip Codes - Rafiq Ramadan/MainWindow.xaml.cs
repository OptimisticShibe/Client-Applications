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
using System.Text.RegularExpressions;

namespace Assignment_4_Zip_Codes___Rafiq_Ramadan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmitButton.IsEnabled = false;
        }
        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateInterface();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void updateInterface()
        {
            //Still working on this. Once submit is on, it only turns off if less than 5 char.
            if (Regex.IsMatch(uxTextbox.Text, @"((^\d{5}(-\d{4}$)?$)|^(\w\d){3}$)"))
            {
                uxSubmitButton.IsEnabled = true;
            }
            else
            {
                uxSubmitButton.IsEnabled = false;
            }
        }

    }
}
