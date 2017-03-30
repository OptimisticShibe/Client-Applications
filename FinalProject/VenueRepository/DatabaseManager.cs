using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenueDB;

namespace VenueRepository
{
    public class DatabaseManager
    {
        private static readonly FinalProjectEntities entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new FinalProjectEntities();
            entities.Database.Connection.Open();
        }

        // Provide an accessor to the database
        public static FinalProjectEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
