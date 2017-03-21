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
using ContactApp.Models;
using System.Windows.Controls;
using System.ComponentModel;

namespace ContactApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadContacts();
        }

        // Do this when delete is selected
        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ContactRepository.Remove(selectedContact.Id);
            selectedContact = null;
            LoadContacts();
        }

        // Check status of deletion; enable or disable the menu
        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedContact != null);
            uxContextFileDelete.IsEnabled = (selectedContact != null);
        }

        private ContactModel selectedContact;

        private void uxContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedContact = (ContactModel)uxContactList.SelectedValue;
        }

        private void LoadContacts()
        {
            var contacts = App.ContactRepository.GetAll();

            uxContactList.ItemsSource = contacts
                .Select(t => ContactModel.ToModel(t))
                .ToList();

            // OR
            //var uiContactModelList = new List<ContactModel>();
            //foreach (var repositoryContactModel in contacts)
            //{
            //    This is the .Select(t => ... )
            //    var uiContactModel = ContactModel.ToModel(repositoryContactModel);
            //
            //    uiContactModelList.Add(uiContactModel);
            //}

            //uxContactList.ItemsSource = uiContactModelList;
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();

            if (window.ShowDialog() == true)
            {
                var uiContactModel = window.Contact;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.ContactRepository.Add(repositoryContactModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());

                LoadContacts(); //when adding, call on load contacts to show up
            }
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
        }

        
        
        //KEY to sorting = tags
        private void ColumnHeaderSort_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            
            string sortBy = column.Tag.ToString();
            
            uxContactList.Items.SortDescriptions.Clear();

            var sortDescription = new System.ComponentModel.SortDescription(sortBy, System.ComponentModel.ListSortDirection.Ascending);

            uxContactList.Items.SortDescriptions.Add(sortDescription);
        }
    }
    
}