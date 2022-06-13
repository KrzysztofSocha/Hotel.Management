using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Management.Migrations
{
    public partial class ChangeApartamentInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Apartaments",
                newName: "PeopleCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PeopleCount",
                table: "Apartaments",
                newName: "Area");
        }
    }
}
