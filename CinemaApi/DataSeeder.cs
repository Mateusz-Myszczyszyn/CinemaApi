using Bogus;
using CinemaApi.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi
{
    public class DataSeeder
    {
        public static void Seed(CinemaDbContext context)
        {
            var language = "pl";

            Randomizer.Seed = new Random(911);

            string[] randomCinemas = { "Cinema City", "Multikino", "Helios" };

            var AddressGen = new Faker<Address>(language)
                .RuleFor(a => a.PostalCode, c => c.Address.ZipCode())
                .RuleFor(a => a.City, c => c.Address.City())
                .RuleFor(a => a.Street, c => c.Address.StreetAddress());

            var gen = AddressGen.Generate(2);
            
            // context.AddRange(cinemas);

            var SeetReservingGen = new Faker<SeetReserving>(language)
                .RuleFor(sr => sr.Seats, sr => sr.Random.Number(1, 10))
                .RuleFor(sr => sr.Rows, sr => sr.Random.String(1, 'A', 'G'))
                .RuleFor(sr => sr.IsReserved, sr => sr.Random.Bool());

            var seetReservings = SeetReservingGen.Generate(5);

            var UserGen = new Faker<User>(language)
                .RuleFor(u => u.Name, u => u.Person.FirstName)
                .RuleFor(u => u.Email, u => u.Person.Email)
                .RuleFor(u => u.LastName, u => u.Person.LastName)
                .RuleFor(u => u.Password, u => u.Internet.Password())
                .RuleFor(u => u.RoleId, u => u.Random.Number(1, 4))
                .RuleFor(u=>u.SeetReservings,seetReservings);
                

            var users = UserGen.Generate(5);

            string[] hallsMock = { "Hall A", "Hall B", "Hall C", "Hall D", "Hall E" };
            var HallGen = new Faker<CinemaHall>(language)
                .RuleFor(ch => ch.Name, ch => ch.PickRandom(hallsMock))
                .RuleFor(ch => ch.CinemaId,ch=>ch.Random.Number(1,2))
                .RuleFor(u => u.SeetReservings, seetReservings);

            var halls = HallGen.Generate(5);

            var CinemaGen = new Faker<Cinema>(language)
                .RuleFor(c => c.Name, c => c.PickRandom(randomCinemas))
                .RuleFor(c => c.Owner, c => c.Name.FullName())
                .RuleFor(c => c.Addresses, gen)
                .RuleFor(c=>c.CinemaHalls,halls);

            var cinemas = CinemaGen.Generate(2);

            context.AddRange(cinemas);
            context.AddRange(users);
            context.AddRange(halls);
            context.SaveChanges();
        }
    }
}
