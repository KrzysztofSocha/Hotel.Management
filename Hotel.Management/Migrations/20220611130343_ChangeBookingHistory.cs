using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Management.Migrations
{
    public partial class ChangeBookingHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "BookingHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "BookingHistories");
        }
    }
}
