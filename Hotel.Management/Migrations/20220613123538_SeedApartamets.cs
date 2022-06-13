using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Management.Migrations
{
    public partial class SeedApartamets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apartaments",
                columns: new[] { "Id", "BookingId", "DeletionTime", "Description", "Floor", "IsDeleted", "Number", "PeopleCount", "PriceForDay", "StatusId" },
                values: new object[] { 1, null, null, "Apartament prezydencki z widokiem na morze", 4, false, "1", 5, 400.0, 1 });

            migrationBuilder.InsertData(
                table: "Apartaments",
                columns: new[] { "Id", "BookingId", "DeletionTime", "Description", "Floor", "IsDeleted", "Number", "PeopleCount", "PriceForDay", "StatusId" },
                values: new object[] { 2, null, null, "Apartament  z widokiem na morze", 4, false, "2", 3, 250.0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apartaments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartaments",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
