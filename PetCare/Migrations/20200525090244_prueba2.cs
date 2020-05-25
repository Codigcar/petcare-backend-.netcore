using Microsoft.EntityFrameworkCore.Migrations;

namespace PetCare.Migrations
{
    public partial class prueba2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV_number",
                table: "Payments");

            migrationBuilder.AddColumn<string>(
                name: "CVV",
                table: "Payments",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "Payments");

            migrationBuilder.AddColumn<string>(
                name: "CVV_number",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
