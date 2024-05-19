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
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeatsNumber = table.Column<int>(type: "int", nullable: false),
                    ArrivalAirportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartureAirportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.UniqueConstraint("AK_Trips_Number", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Trips_ArrivalAirport",
                        column: x => x.ArrivalAirportId,
                        principalTable: "Destination",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trips_DepartureAirport",
                        column: x => x.DepartureAirportId,
                        principalTable: "Destination",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ArrivalAirportId",
                table: "Trips",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DepartureAirportId",
                table: "Trips",
                column: "DepartureAirportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
