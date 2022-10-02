using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApi.Entities
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MoviePerforming> MoviePerformings { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<SeetReserving> SeetReservings { get; set; }
        public DbSet<ScreenPlay> ScreenPlays { get; set; }
        public DbSet<AddressHasHalls> AddressesHasHalls { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {

        }
    }
}
