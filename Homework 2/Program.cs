using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Homework_2
{
    class Program
    {
        private Models.User user = new Models.User();

        static void Main(string[] args)
        {
            //Provided List:
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            //Homework tasks below:
            //1. Displaying all passwords that are "hello"
            users = users.Where(x => x.Password == "hello").ToList();

            //I don't know how to list the passwords to the console w/o a foreach loop
            foreach (var entry in users)
            {
                Console.WriteLine("{0}", entry.Password);
            }
           
            //2. Deleting passwords that are just lowercase names

            //Why has no one ever taught me Lambda expressions? They seem to be the solution to a lot of problems.
            users = users.Where(x => x.Password != x.Name.ToLower()).ToList();

            //3. Removing first user with the Hello password:
            var removeHello = users.FirstOrDefault(x => x.Password == "hello");
            users.Remove(removeHello);

            Console.WriteLine("\n");
            foreach (var entry in users)
            {
                Console.WriteLine("{0} {1}", entry.Name, entry.Password);
            }

            Console.ReadLine();

        }
    }
}
