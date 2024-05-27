using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightsDb.Migrations
{
    /// <inheritdoc />
    public partial class FkMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Trips_TripId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_DepartureAirport",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_ArrivalAirport",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destination",
                table: "Destination");

            migrationBuilder.RenameTable(
                name: "Destination",
                newName: "Destinations");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartureAirportId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArrivalAirportId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PassengerId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Trips_TripId",
                table: "Tickets",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_DepartureAirport",
                table: "Trips",
                column: "DepartureAirportId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_ArrivalAirport",
                table: "Trips",
                column: "ArrivalAirportId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Trips_TripId",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Destinations",
                newName: "Destination");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartureAirportId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ArrivalAirportId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PassengerId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destination",
                table: "Destination",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Trips_TripId",
                table: "Tickets",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id");
        }
    }
}
