using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class VenueModel
    {
        public int Id { get; set; }
        public string VenueName { get; set; }
        public double TicketPrice { get; set; }
        public int Quantity { get; set; }
        public double OrderValue { get; set; }
        public string Notes { get; set; }
        public string ShippingOption { get; set; }


        internal VenueModel Clone()
        {
            return (VenueModel)MemberwiseClone();
        }

        public VenueRepository.VenueModel ToRepositoryModel()
        {
            var repositoryModel = new VenueRepository.VenueModel
            {
                Id = Id,
                VenueName = VenueName,
                TicketPrice = TicketPrice,
                Quantity = Quantity,
                OrderValue = OrderValue,
                Notes = Notes,
                ShippingOption = ShippingOption,
            };

            return repositoryModel;
        }

        public static VenueModel ToModel(VenueRepository.VenueModel repositoryModel)
        {
            var venueModel = new VenueModel
            {
                Id = repositoryModel.Id,
                VenueName = repositoryModel.VenueName,
                TicketPrice = repositoryModel.TicketPrice,
                Quantity = repositoryModel.Quantity,
                OrderValue = repositoryModel.OrderValue,
                Notes = repositoryModel.Notes,
                ShippingOption = repositoryModel.ShippingOption,
            };

            return venueModel;
        }
    }
}
