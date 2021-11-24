using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoLocalizador.BE.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Harbors",
                columns: table => new
                {
                    IdHarbor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdMarineTraffic = table.Column<int>(type: "int", nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harbors", x => x.IdHarbor);
                });

            migrationBuilder.CreateTable(
                name: "VesselInfos",
                columns: table => new
                {
                    IdNavio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vessel_Type_Generic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vessel_Type_Detailed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MMSI = table.Column<int>(type: "int", nullable: false),
                    Call_Sign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gross_Tonnage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LengthxBreadth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year_Built = table.Column<int>(type: "int", nullable: false),
                    Home_Port = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChange = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselInfos", x => x.IdNavio);
                });

            migrationBuilder.CreateTable(
                name: "VesselGeoPositions",
                columns: table => new
                {
                    IdPosition = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVesselInfo = table.Column<int>(type: "int", nullable: false),
                    VesselInfoIdNavio = table.Column<int>(type: "int", nullable: true),
                    LastPositionReceived = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LocationArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Current_Port = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeedCourse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AISSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselGeoPositions", x => x.IdPosition);
                    table.ForeignKey(
                        name: "FK_VesselGeoPositions_VesselInfos_VesselInfoIdNavio",
                        column: x => x.VesselInfoIdNavio,
                        principalTable: "VesselInfos",
                        principalColumn: "IdNavio",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VesselGeoPositions_VesselInfoIdNavio",
                table: "VesselGeoPositions",
                column: "VesselInfoIdNavio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Harbors");

            migrationBuilder.DropTable(
                name: "VesselGeoPositions");

            migrationBuilder.DropTable(
                name: "VesselInfos");
        }
    }
}
