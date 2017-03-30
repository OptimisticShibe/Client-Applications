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
using FinalProject.Models;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadVenues();
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new VenueWindow();

            if (window.ShowDialog() == true)
            {
                var uiVenueModel = window.Venue;

                var repositoryVenueModel = uiVenueModel.ToRepositoryModel();

                App.VenueRepository.Add(repositoryVenueModel);
            }

            LoadVenues();
        }

        private void LoadVenues()
        {
            var venues = App.VenueRepository.GetAll();

            uxVenueList.ItemsSource = venues
                .Select(x => VenueModel.ToModel(x))
                .ToList();
        }

        private void uxContextFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new VenueWindow();

            if (window.ShowDialog() == true)
            {
                var uiVenueModel = window.Venue;

                var repositoryVenueModel = uiVenueModel.ToRepositoryModel();

                App.VenueRepository.Add(repositoryVenueModel);
            }

            LoadVenues();
        }

        private void uxContextFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new VenueWindow();
            window.Venue = selectedVenue;

            if (window.ShowDialog() == true)
            {
                App.VenueRepository.Update(window.Venue.ToRepositoryModel());
                LoadVenues();
            }
        }

        private void uxContextFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.VenueRepository.Remove(selectedVenue.Id);
            selectedVenue = null;
            LoadVenues();
        }

        private VenueModel selectedVenue;

        private void uxVenueList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedVenue = (VenueModel)uxVenueList.SelectedValue;
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.VenueRepository.Remove(selectedVenue.Id);
            selectedVenue = null;
            LoadVenues();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedVenue != null);
        }

        private void uxContextFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxContextFileDelete.IsEnabled = (selectedVenue != null);
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new VenueWindow();
            window.Venue = selectedVenue;

            if (window.ShowDialog() == true)
            {
                App.VenueRepository.Update(window.Venue.ToRepositoryModel());
                LoadVenues();
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedVenue != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void uxVenueList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            uxFileChange_Click(null, null);
        }
        //public override void EndInit()
        //{
        //    base.EndInit();

        //    var FinalProject = new FinalProjectEntities();

        //    FinalProject.Venues.Load();

        //    uxVenueList.ItemsSource = FinalProject.Venues.Local;
        //}
    }
}
