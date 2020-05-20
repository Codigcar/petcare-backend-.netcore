using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace PetCare.Migrations
{
    public partial class kai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Document = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuscriptionPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuscriptionPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Age = table.Column<string>(nullable: false),
                    Breed = table.Column<string>(maxLength: 30, nullable: false),
                    Photo = table.Column<string>(maxLength: 50, nullable: false),
                    Sex = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    BusinessName = table.Column<string>(maxLength: 30, nullable: false),
                    Region = table.Column<string>(maxLength: 30, nullable: false),
                    Field = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    SuscriptionPlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesProviders_SuscriptionPlans_SuscriptionPlanId",
                        column: x => x.SuscriptionPlanId,
                        principalTable: "SuscriptionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CVV_Number = table.Column<string>(nullable: false),
                    Expiry_Date = table.Column<string>(maxLength: 8, nullable: false),
                    ServicesProviderForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_ServicesProviders_ServicesProviderForeignKey",
                        column: x => x.ServicesProviderForeignKey,
                        principalTable: "ServicesProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SuscriptionPlans",
                columns: new[] { "Id", "Description", "Duration", "Name", "Price" },
                values: new object[] { 1, "Plan Basico", 1, "Basica", 19.899999999999999 });

            migrationBuilder.InsertData(
                table: "SuscriptionPlans",
                columns: new[] { "Id", "Description", "Duration", "Name", "Price" },
                values: new object[] { 2, "Plan Premium", 1, "Premium", 39.899999999999999 });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ServicesProviderForeignKey",
                table: "Cards",
                column: "ServicesProviderForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_CustomerId",
                table: "Pets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesProviders_SuscriptionPlanId",
                table: "ServicesProviders",
                column: "SuscriptionPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "ServicesProviders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SuscriptionPlans");
        }
    }
}
