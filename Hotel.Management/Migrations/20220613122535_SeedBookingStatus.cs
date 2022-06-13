using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Management.Migrations
{
    public partial class SeedBookingStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookingStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Dostępny" });

            migrationBuilder.InsertData(
                table: "BookingStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Zarezerwowany" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookingStatuses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
