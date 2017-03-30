using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static VenueRepository.VenueRepository venueRepository;

        static App()
        {
            venueRepository = new VenueRepository.VenueRepository();
        }

        public static VenueRepository.VenueRepository VenueRepository
        {
            get
            {
                return venueRepository;
            }
        }
    }
}
