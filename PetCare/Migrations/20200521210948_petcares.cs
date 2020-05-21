using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace PetCare.Migrations
{
    public partial class petcares : Migration
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
                name: "ServiTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiTypes", x => x.Id);
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
                    MedicalProfileId = table.Column<int>(nullable: false),
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
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ServiTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ServiTypes_ServiTypeId",
                        column: x => x.ServiTypeId,
                        principalTable: "ServiTypes",
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
                name: "MedicalProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Lenght = table.Column<string>(nullable: true),
                    Eyes = table.Column<string>(nullable: true),
                    Breed = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    PetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalProfiles_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CVV_number = table.Column<string>(nullable: false),
                    DateOfExpiry = table.Column<string>(maxLength: 8, nullable: false),
                    ServicesProviderForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_ServicesProviders_ServicesProviderForeignKey",
                        column: x => x.ServicesProviderForeignKey,
                        principalTable: "ServicesProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderJoinServices",
                columns: table => new
                {
                    ProviderId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderJoinServices", x => new { x.ProviderId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ProviderJoinServices_ServicesProviders_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "ServicesProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderJoinServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderRepresentatives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Position = table.Column<string>(maxLength: 50, nullable: false),
                    Phone1 = table.Column<string>(maxLength: 9, nullable: false),
                    Phone2 = table.Column<string>(maxLength: 9, nullable: false),
                    Direction = table.Column<string>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderRepresentatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderRepresentatives_ServicesProviders_ProviderId",
                        column: x => x.ProviderId,
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
                name: "IX_MedicalProfiles_PetId",
                table: "MedicalProfiles",
                column: "PetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ServicesProviderForeignKey",
                table: "Payments",
                column: "ServicesProviderForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_CustomerId",
                table: "Pets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderJoinServices_ServiceId",
                table: "ProviderJoinServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderRepresentatives_ProviderId",
                table: "ProviderRepresentatives",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiTypeId",
                table: "Services",
                column: "ServiTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesProviders_SuscriptionPlanId",
                table: "ServicesProviders",
                column: "SuscriptionPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalProfiles");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProviderJoinServices");

            migrationBuilder.DropTable(
                name: "ProviderRepresentatives");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "ServicesProviders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ServiTypes");

            migrationBuilder.DropTable(
                name: "SuscriptionPlans");
        }
    }
}
