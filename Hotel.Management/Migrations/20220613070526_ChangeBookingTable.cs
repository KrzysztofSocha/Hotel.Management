using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Management.Migrations
{
    public partial class ChangeBookingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartaments_Bookings_BookingId",
                table: "Apartaments");

            migrationBuilder.DropIndex(
                name: "IX_Apartaments_BookingId",
                table: "Apartaments");

            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "Apartaments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Apartaments_BookingId",
                table: "Apartaments",
                column: "BookingId",
                unique: true,
                filter: "[BookingId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartaments_Bookings_BookingId",
                table: "Apartaments",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartaments_Bookings_BookingId",
                table: "Apartaments");

            migrationBuilder.DropIndex(
                name: "IX_Apartaments_BookingId",
                table: "Apartaments");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "Apartaments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartaments_BookingId",
                table: "Apartaments",
                column: "BookingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartaments_Bookings_BookingId",
                table: "Apartaments",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
