using Hotel.Management.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Management
{
    public class HotelContext : DbContext
    {
        public DbSet<Apartament> Apartaments { get; set; }
        public DbSet<BookingApartament> Bookings { get; set; }
        public DbSet<BookingHistory> BookingHistories { get; set; }
        public DbSet<Client> CLients { get; set; }
        public DbSet<ClientAddress> ClientAddresses { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartament>()
             .HasOne(c => c.Booking)
             .WithOne(o => o.Apartament);


            modelBuilder.Entity<Client>()
             .HasOne(c => c.Address)
             .WithOne(o => o.Client);
            modelBuilder.Entity<Client>().HasKey(x => x.Index);
            modelBuilder.Entity<Apartament>().HasMany(x => x.AccomHistories).WithOne(x => x.Apartament);
        }
    }
}
