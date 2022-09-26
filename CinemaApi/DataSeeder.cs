using Bogus;
using CinemaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi
{
    public class DataSeeder
    {
        public static void Seed(CinemaDbContext context)
        {
            var movieGen = new Faker<Movie>("pl")
              .RuleFor(c => c.Title, c => c.Random.Words(1))
              .RuleFor(c => c.Description, c => c.Lorem.Sentence())
              .RuleFor(c => c.Director, c => c.Person.FullName);
                //.RuleFor(c => c.Premiere, c => c.Date.Between(new DateOnly(2012,1,1), new DateOnly(2016, 12, 31)));

            var cinemaGen = new Faker<Cinema>("pl")
                .RuleFor(c => c.Name, c => c.Random.Words(2))
                .RuleFor(c => c.Owner, c => c.Person.FullName)
                .RuleFor(c => c.WorkersQuantity, c => c.Random.Number(50, 100));

            var hallGen = new Faker<CinemaHall>("pl")
                .RuleFor(c => c.Name, c => c.Random.AlphaNumeric(2))
                .RuleFor(c => c.Cinema, cinemaGen.Generate());

            var moviePerfGen = new Faker<MoviePerforming>("pl")
                .RuleFor(c => c.Movie, movieGen.Generate())
                .RuleFor(c => c.CinemaHall, hallGen.Generate());

            var screenPlayGen = new Faker<ScreenPlay>("pl")
               .RuleFor(c => c.ShowTime, c => c.Date.Between(new DateTime(2020, 1, 1), new DateTime(2022, 12, 31)))
               .RuleFor(c => c.MoviePerforming, moviePerfGen.Generate());

            var addressGen = new Faker<Address>("pl")
                .RuleFor(c => c.Street, c => c.Address.StreetName())
                .RuleFor(c => c.PostalCode, c => c.Address.ZipCode())
                .RuleFor(c => c.City, c => c.Address.City())
                .RuleFor(c => c.Cinema, cinemaGen.Generate());

            var userGen = new Faker<User>("pl")
                .RuleFor(c => c.Name, c => c.Person.FirstName)
                .RuleFor(c => c.LastName, c => c.Person.LastName)
                .RuleFor(c => c.Email, c => c.Person.Email)
                .RuleFor(c => c.Password, c=>c.Internet.Password())
                .RuleFor(c => c.DateOfBirth, c => c.Person.DateOfBirth)
                .RuleFor(c => c.RoleId, c => c.Random.Number(1,4));

            var seetRes = new Faker<SeetReserving>("pl")
                .RuleFor(c => c.Rows, c => c.Random.String(2,'A','G'))
                .RuleFor(c => c.Seats, c => c.Random.Number(1,10))
                .RuleFor(c => c.IsReserved, c => c.Random.Bool())
                .RuleFor(c => c.CinemaHall, hallGen.Generate())
                .RuleFor(c => c.User, userGen.Generate());

            var addresses = addressGen.Generate(5);
            var seetreservings = seetRes.Generate(5);
            var screenplays = screenPlayGen.Generate(5);
           /* var users = userGen.Generate(5);
            var movies = movieGen.Generate(5);
            var movieperfs = moviePerfGen.Generate(5);
            var cinemas = cinemaGen.Generate(5);
            var halls = hallGen.Generate(5);*/

            context.AddRange(addresses);
            context.AddRange(seetreservings);
            context.AddRange(screenplays);
           /* context.AddRange(users);
            context.AddRange(halls);
            context.AddRange(cinemas);
            context.AddRange(movieperfs);
            context.AddRange(movies);*/

            context.SaveChanges();

        }
    }
}
