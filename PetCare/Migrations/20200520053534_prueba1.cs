using Microsoft.EntityFrameworkCore.Migrations;

namespace PetCare.Migrations
{
    public partial class prueba1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV_Number",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Expiry_Date",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "CVV",
                table: "Cards",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "DateOfExpiry",
                table: "Cards",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "DateOfExpiry",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "CVV_Number",
                table: "Cards",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Expiry_Date",
                table: "Cards",
                type: "varchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }
    }
}
