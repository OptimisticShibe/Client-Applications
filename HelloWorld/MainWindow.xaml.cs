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
using System.Data.Entity;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();
        public MainWindow()
        {
            InitializeComponent();
            //WindowState = WindowState.Maximized; 
            uxSubmit.IsEnabled = false;
        }
        public override void EndInit()
        {
            base.EndInit();

            var sample = new SampleEntities();

            sample.Users.Load();

            uxList.ItemsSource = sample.Users.Local;
        }
        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateInterface();
        }

        private void uxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            UpdateInterface();
        }
        
        private void UpdateInterface()
        {
            if ((!string.IsNullOrEmpty(uxName.Text)) && (!string.IsNullOrEmpty(uxPassword.Password)))
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
            MessageBox.Show("Submitting password: " + uxPassword.Password);

            var window = new SecondWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }

        
        
    }

}

