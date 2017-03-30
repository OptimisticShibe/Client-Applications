using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenueDB;

namespace VenueRepository
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
    }

    public class VenueRepository
    {
        public VenueModel Add(VenueModel venueModel)
        {
            var venueDB = ToDbModel(venueModel);

            DatabaseManager.Instance.Venues.Add(venueDB);
            DatabaseManager.Instance.SaveChanges();

            venueModel = new VenueModel
            {
                VenueName = venueDB.VenueName,
                TicketPrice = venueDB.TicketPrice,
                Id = venueDB.VenueId,
                Quantity = venueDB.TicketQuantity,
                OrderValue = venueDB.OrderValue,
                Notes = venueDB.Notes,
                ShippingOption = venueDB.ShippingOption,
            };
            return venueModel;
        }

        public List<VenueModel> GetAll()
        {
            // I still don't 100% understand this bit here,
            // but I do know it's a lambda expression and that's cool :)
            var items = DatabaseManager.Instance.Venues
              .Select(x => new VenueModel
              {
                  VenueName = x.VenueName,
                  TicketPrice = x.TicketPrice,
                  Id = x.VenueId,
                  Quantity = x.TicketQuantity,
                  OrderValue = x.OrderValue,
                  Notes = x.Notes,
                  ShippingOption = x.ShippingOption,
                  
              }).ToList();

            return items;
        }

        // ???
        public bool Update(VenueModel venueModel)
        {
            var original = DatabaseManager.Instance.Venues.Find(venueModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(venueModel));
                DatabaseManager.Instance.SaveChanges();
            }

            return false;
        }

        // For removing via the app
        public bool Remove(int venueId)
        {
            var items = DatabaseManager.Instance.Venues
                                .Where(t => t.VenueId == venueId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Venues.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Venue ToDbModel(VenueModel venueModel)
        {
            var venueDb = new Venue
            {
                VenueId = venueModel.Id,
                VenueName = venueModel.VenueName,
                TicketPrice = venueModel.TicketPrice,
                TicketQuantity = venueModel.Quantity,
                OrderValue = venueModel.OrderValue,
                Notes = venueModel.Notes,
                ShippingOption = venueModel.ShippingOption,

            };

            return venueDb;
        }
    }
}
