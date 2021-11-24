using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoLocalizador.BE.Migrations
{
    public partial class AddingTravel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TruckTravels",
                columns: table => new
                {
                    IdTravel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrigin = table.Column<int>(type: "int", nullable: false),
                    OriginIdPosition = table.Column<int>(type: "int", nullable: true),
                    IdDestination = table.Column<int>(type: "int", nullable: false),
                    DestinationIdPosition = table.Column<int>(type: "int", nullable: true),
                    IdTruck = table.Column<int>(type: "int", nullable: false),
                    TruckIdTruck = table.Column<int>(type: "int", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckTravels", x => x.IdTravel);
                    table.ForeignKey(
                        name: "FK_TruckTravels_GeoPositions_DestinationIdPosition",
                        column: x => x.DestinationIdPosition,
                        principalTable: "GeoPositions",
                        principalColumn: "IdPosition",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TruckTravels_GeoPositions_OriginIdPosition",
                        column: x => x.OriginIdPosition,
                        principalTable: "GeoPositions",
                        principalColumn: "IdPosition",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TruckTravels_TruckInfos_TruckIdTruck",
                        column: x => x.TruckIdTruck,
                        principalTable: "TruckInfos",
                        principalColumn: "IdTruck",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VesselTravels",
                columns: table => new
                {
                    IdTravel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrigin = table.Column<int>(type: "int", nullable: false),
                    OriginIdPosition = table.Column<int>(type: "int", nullable: true),
                    IdDestination = table.Column<int>(type: "int", nullable: false),
                    DestinationIdPosition = table.Column<int>(type: "int", nullable: true),
                    IdVessel = table.Column<int>(type: "int", nullable: false),
                    VesselIdNavio = table.Column<int>(type: "int", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselTravels", x => x.IdTravel);
                    table.ForeignKey(
                        name: "FK_VesselTravels_GeoPositions_DestinationIdPosition",
                        column: x => x.DestinationIdPosition,
                        principalTable: "GeoPositions",
                        principalColumn: "IdPosition",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VesselTravels_GeoPositions_OriginIdPosition",
                        column: x => x.OriginIdPosition,
                        principalTable: "GeoPositions",
                        principalColumn: "IdPosition",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VesselTravels_VesselInfos_VesselIdNavio",
                        column: x => x.VesselIdNavio,
                        principalTable: "VesselInfos",
                        principalColumn: "IdNavio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TruckTravels_DestinationIdPosition",
                table: "TruckTravels",
                column: "DestinationIdPosition");

            migrationBuilder.CreateIndex(
                name: "IX_TruckTravels_OriginIdPosition",
                table: "TruckTravels",
                column: "OriginIdPosition");

            migrationBuilder.CreateIndex(
                name: "IX_TruckTravels_TruckIdTruck",
                table: "TruckTravels",
                column: "TruckIdTruck");

            migrationBuilder.CreateIndex(
                name: "IX_VesselTravels_DestinationIdPosition",
                table: "VesselTravels",
                column: "DestinationIdPosition");

            migrationBuilder.CreateIndex(
                name: "IX_VesselTravels_OriginIdPosition",
                table: "VesselTravels",
                column: "OriginIdPosition");

            migrationBuilder.CreateIndex(
                name: "IX_VesselTravels_VesselIdNavio",
                table: "VesselTravels",
                column: "VesselIdNavio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckTravels");

            migrationBuilder.DropTable(
                name: "VesselTravels");
        }
    }
}
