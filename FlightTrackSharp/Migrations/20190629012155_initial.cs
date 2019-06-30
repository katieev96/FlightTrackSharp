using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightTrackSharp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftManufacturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftManufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AircraftModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumEngines = table.Column<int>(nullable: false),
                    EngineType = table.Column<string>(nullable: true),
                    TailNumber = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    AircraftModelId = table.Column<Guid>(nullable: true),
                    AircraftManufacturerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aircraft_AircraftManufacturer_AircraftManufacturerId",
                        column: x => x.AircraftManufacturerId,
                        principalTable: "AircraftManufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aircraft_AircraftModel_AircraftModelId",
                        column: x => x.AircraftModelId,
                        principalTable: "AircraftModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_AircraftManufacturerId",
                table: "Aircraft",
                column: "AircraftManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_AircraftModelId",
                table: "Aircraft",
                column: "AircraftModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "AircraftManufacturer");

            migrationBuilder.DropTable(
                name: "AircraftModel");
        }
    }
}
