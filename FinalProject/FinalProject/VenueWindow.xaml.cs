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
using FinalProject.Models;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for VenueWindow.xaml
    /// </summary>
    public partial class VenueWindow : Window
    {
        public VenueWindow()
        {
            InitializeComponent();

            ShowInTaskbar = false;
        }

        public VenueModel Venue { get; set; }

        // To update the Value field
        private void updateValue()
        {
            if ((!string.IsNullOrEmpty(uxQuantity.Text)) && (!string.IsNullOrEmpty(uxTicketPrice.Text)))
            {
                var orderValue = double.Parse(uxQuantity.Text) * double.Parse(uxTicketPrice.Text);
                uxOrderValue.Text = orderValue.ToString();
            }
        }

        private void uxTicketPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateValue();
        }

        private void uxQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateValue();
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (uxETickets.IsChecked.Value)
            {
                Venue.ShippingOption = "E-Tickets";
            }
            else
            {
                Venue.ShippingOption = "Hard Tickets";
            }

            //Venue.VenueName = uxVenueName.Text;
            Venue.OrderValue = double.Parse(uxOrderValue.Text);
            //Venue.Quantity = int.Parse(uxQuantity.Text);
            //Venue.Notes = uxNotes.Text;



            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Venue != null)
            {
                if (Venue.ShippingOption == "E-Tickets")
                {
                    uxETickets.IsChecked = true;
                }
                else
                {
                    uxHardTickets.IsChecked = false;
                }
                uxSubmit.Content = "Update";
            }
            else
            {
                Venue = new VenueModel();
            }

            uxGrid.DataContext = Venue;
        }
    }
}
