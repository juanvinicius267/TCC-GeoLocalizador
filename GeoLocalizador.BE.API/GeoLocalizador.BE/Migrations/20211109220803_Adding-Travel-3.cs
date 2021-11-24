using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoLocalizador.BE.Migrations
{
    public partial class AddingTravel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LogDate",
                table: "VesselTravels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LogDate",
                table: "TruckTravels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogDate",
                table: "VesselTravels");

            migrationBuilder.DropColumn(
                name: "LogDate",
                table: "TruckTravels");
        }
    }
}
