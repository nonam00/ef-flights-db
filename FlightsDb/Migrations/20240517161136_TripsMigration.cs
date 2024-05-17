using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightsDb.Migrations
{
    /// <inheritdoc />
    public partial class TripsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeatsNumber = table.Column<int>(type: "int", nullable: false),
                    ArrivalAirportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartureAirportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_ArrivalAirport",
                        column: x => x.ArrivalAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trips_DepartureAirport",
                        column: x => x.DepartureAirportId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ArrivalAirportId",
                table: "Trips",
                column: "ArrivalAirportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DepartureAirportId",
                table: "Trips",
                column: "DepartureAirportId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
