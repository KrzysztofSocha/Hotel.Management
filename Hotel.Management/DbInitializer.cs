using Microsoft.EntityFrameworkCore;
using Hotel.Management.Entities;
namespace Hotel.Management
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<BookingStatus>().HasData(
                  new BookingStatus() { Id = 1, Name = "Dostępny" },
                  new BookingStatus() { Id = 2, Name = "Zarezerwowany" }

            );
            modelBuilder.Entity<Apartament>().HasData(
                new Apartament()
                {
                    Id = 1,
                    Description = "Apartament prezydencki z widokiem na morze",
                    PriceForDay = 400,
                    PeopleCount = 5,
                    Number = "1",
                    Floor = 4,
                },
                new Apartament()
                {
                    Id = 2,
                    Description = "Apartament  z widokiem na morze",
                    PriceForDay = 250,
                    PeopleCount = 3,
                    Number = "2",
                    Floor = 4,
                });
        }
    }
}
