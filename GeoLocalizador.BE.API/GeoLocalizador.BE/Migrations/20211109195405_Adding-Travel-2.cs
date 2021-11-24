using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoLocalizador.BE.Migrations
{
    public partial class AddingTravel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VesselTravels_GeoPositions_DestinationIdPosition",
                table: "VesselTravels");

            migrationBuilder.DropForeignKey(
                name: "FK_VesselTravels_GeoPositions_OriginIdPosition",
                table: "VesselTravels");

            migrationBuilder.RenameColumn(
                name: "OriginIdPosition",
                table: "VesselTravels",
                newName: "OriginIdHarbor");

            migrationBuilder.RenameColumn(
                name: "DestinationIdPosition",
                table: "VesselTravels",
                newName: "DestinationIdHarbor");

            migrationBuilder.RenameIndex(
                name: "IX_VesselTravels_OriginIdPosition",
                table: "VesselTravels",
                newName: "IX_VesselTravels_OriginIdHarbor");

            migrationBuilder.RenameIndex(
                name: "IX_VesselTravels_DestinationIdPosition",
                table: "VesselTravels",
                newName: "IX_VesselTravels_DestinationIdHarbor");

            migrationBuilder.AddForeignKey(
                name: "FK_VesselTravels_Harbors_DestinationIdHarbor",
                table: "VesselTravels",
                column: "DestinationIdHarbor",
                principalTable: "Harbors",
                principalColumn: "IdHarbor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VesselTravels_Harbors_OriginIdHarbor",
                table: "VesselTravels",
                column: "OriginIdHarbor",
                principalTable: "Harbors",
                principalColumn: "IdHarbor",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VesselTravels_Harbors_DestinationIdHarbor",
                table: "VesselTravels");

            migrationBuilder.DropForeignKey(
                name: "FK_VesselTravels_Harbors_OriginIdHarbor",
                table: "VesselTravels");

            migrationBuilder.RenameColumn(
                name: "OriginIdHarbor",
                table: "VesselTravels",
                newName: "OriginIdPosition");

            migrationBuilder.RenameColumn(
                name: "DestinationIdHarbor",
                table: "VesselTravels",
                newName: "DestinationIdPosition");

            migrationBuilder.RenameIndex(
                name: "IX_VesselTravels_OriginIdHarbor",
                table: "VesselTravels",
                newName: "IX_VesselTravels_OriginIdPosition");

            migrationBuilder.RenameIndex(
                name: "IX_VesselTravels_DestinationIdHarbor",
                table: "VesselTravels",
                newName: "IX_VesselTravels_DestinationIdPosition");

            migrationBuilder.AddForeignKey(
                name: "FK_VesselTravels_GeoPositions_DestinationIdPosition",
                table: "VesselTravels",
                column: "DestinationIdPosition",
                principalTable: "GeoPositions",
                principalColumn: "IdPosition",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VesselTravels_GeoPositions_OriginIdPosition",
                table: "VesselTravels",
                column: "OriginIdPosition",
                principalTable: "GeoPositions",
                principalColumn: "IdPosition",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
