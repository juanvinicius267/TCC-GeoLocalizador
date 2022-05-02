using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoLocalizador.BE.Migrations
{
    public partial class RfidLogsgpsdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltitudeUnits",
                table: "TruckGeoPositions");

            migrationBuilder.DropColumn(
                name: "GeoSep",
                table: "TruckGeoPositions");

            migrationBuilder.DropColumn(
                name: "GeoSepUnits",
                table: "TruckGeoPositions");

            migrationBuilder.DropColumn(
                name: "Satellites",
                table: "TruckGeoPositions");

            migrationBuilder.RenameColumn(
                name: "SignalQuality",
                table: "TruckGeoPositions",
                newName: "RunStatus");

            migrationBuilder.RenameColumn(
                name: "RefStationId",
                table: "TruckGeoPositions",
                newName: "GnssSat");

            migrationBuilder.RenameColumn(
                name: "AgeGpsData",
                table: "TruckGeoPositions",
                newName: "GlonasSat");

            migrationBuilder.AlterColumn<string>(
                name: "Speed",
                table: "TruckGeoPositions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Altitude",
                table: "TruckGeoPositions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "TruckGeoPositions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FixMode",
                table: "TruckGeoPositions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "TruckGeoPositions");

            migrationBuilder.DropColumn(
                name: "FixMode",
                table: "TruckGeoPositions");

            migrationBuilder.RenameColumn(
                name: "RunStatus",
                table: "TruckGeoPositions",
                newName: "SignalQuality");

            migrationBuilder.RenameColumn(
                name: "GnssSat",
                table: "TruckGeoPositions",
                newName: "RefStationId");

            migrationBuilder.RenameColumn(
                name: "GlonasSat",
                table: "TruckGeoPositions",
                newName: "AgeGpsData");

            migrationBuilder.AlterColumn<int>(
                name: "Speed",
                table: "TruckGeoPositions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Altitude",
                table: "TruckGeoPositions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltitudeUnits",
                table: "TruckGeoPositions",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "GeoSep",
                table: "TruckGeoPositions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "GeoSepUnits",
                table: "TruckGeoPositions",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Satellites",
                table: "TruckGeoPositions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
