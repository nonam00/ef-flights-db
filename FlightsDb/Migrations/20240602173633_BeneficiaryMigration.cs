using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightsDb.Migrations
{
    /// <inheritdoc />
    public partial class BeneficiaryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Passengers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Sale",
                table: "Passengers",
                type: "decimal(8,2)",
                nullable: true,
                defaultValueSql: "0.1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Sale",
                table: "Passengers");
        }
    }
}
