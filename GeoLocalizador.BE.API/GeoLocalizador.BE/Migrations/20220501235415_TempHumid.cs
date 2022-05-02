using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoLocalizador.BE.Migrations
{
    public partial class TempHumid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Humidity",
                table: "TruckGeoPositions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "TruckGeoPositions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "TruckGeoPositions");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "TruckGeoPositions");
        }
    }
}
