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
using System.Data.Entity;
using System.ComponentModel;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for ComboWindow.xaml
    /// </summary>
    public partial class ComboWindow : Window
    {
        public ComboWindow()
        {
            InitializeComponent();
            var sample = new SampleEntities();
            sample.Users.Load();
            uxList.ItemsSource = sample.Users.Local;

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
        }

        

        private void uxComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uxGrid.DataContext = e.AddedItems[0];
        }

        
        //private void GridViewColumnHeader_Click(object sender, MouseButtonEventArgs e)
        //{
        //    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
        //    view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            
        //}

        
        private void GridViewColumnHeader_Click_1(object sender, RoutedEventArgs e)
        {

            CollectionView passwordView = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            passwordView.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
        }
        private void GridViewColumnHeader_Click_2(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
        }
    }
}
