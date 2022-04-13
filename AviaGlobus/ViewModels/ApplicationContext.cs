using AviaGlobus.Models;
using Microsoft.EntityFrameworkCore;

namespace AviaGlobus.ViewModels
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<FlightType> FlightType { get; set; }
        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<PassportType> PassportType { get; set; }
        public DbSet<PlaneType> PlaneType { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}