using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetCare.Migrations
{
    public partial class ultimate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(maxLength: 30, nullable: false),
                    Region = table.Column<string>(maxLength: 30, nullable: false),
                    Field = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Publish = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CVV = table.Column<int>(nullable: false),
                    DateOfExpiry = table.Column<string>(maxLength: 8, nullable: false),
                    ServicesProviderForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Providers_ServicesProviderForeignKey",
                        column: x => x.ServicesProviderForeignKey,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RolId = table.Column<int>(nullable: false),
                    SubscriptionPlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_SubscriptionPlans_SubscriptionPlanId",
                        column: x => x.SubscriptionPlanId,
                        principalTable: "SubscriptionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderJoinProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<int>(nullable: false),
                    TypeProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderJoinProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderJoinProducts_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProviderJoinProducts_TypeProducts_TypeProductId",
                        column: x => x.TypeProductId,
                        principalTable: "TypeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Phone = table.Column<long>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Document = table.Column<long>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false),
                    Owner = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProfiles_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessProfiles_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Phone = table.Column<long>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Document = table.Column<long>(nullable: false),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonProfiles_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PJPId = table.Column<int>(nullable: false),
                    TypeProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProviderJoinProducts_PJPId",
                        column: x => x.PJPId,
                        principalTable: "ProviderJoinProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Age = table.Column<string>(nullable: false),
                    Breed = table.Column<string>(maxLength: 30, nullable: false),
                    Photo = table.Column<string>(maxLength: 50, nullable: false),
                    Sex = table.Column<string>(maxLength: 50, nullable: false),
                    PersonProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_PersonProfiles_PersonProfileId",
                        column: x => x.PersonProfileId,
                        principalTable: "PersonProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qualification = table.Column<int>(nullable: false),
                    Commentary = table.Column<string>(maxLength: 50, nullable: false),
                    PersonProfileId = table.Column<int>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_PersonProfiles_PersonProfileId",
                        column: x => x.PersonProfileId,
                        principalTable: "PersonProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayAvailability = table.Column<string>(nullable: true),
                    StartTime = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availabilities_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndTime = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false),
                    PetId = table.Column<int>(nullable: false),
                    PersonProfileId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    VeterinaryName = table.Column<string>(nullable: true),
                    ProductTypeName = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    PetName = table.Column<string>(nullable: true),
                    DateReservation = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    PersonName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_PersonProfiles_PersonProfileId",
                        column: x => x.PersonProfileId,
                        principalTable: "PersonProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    ProviderId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_MedicalProfiles_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    MedicalProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_MedicalProfiles_MedicalProfileId",
                        column: x => x.MedicalProfileId,
                        principalTable: "MedicalProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Create_at = table.Column<DateTime>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationRecords_MedicalProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "MedicalProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "Publish" },
                values: new object[,]
                {
                    { 1, "Busca veterinarias", "Usuario", false },
                    { 2, "Ofrece Servicios", "ServicesProvider", true }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPlans",
                columns: new[] { "Id", "Description", "Duration", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Plan Free", 1, "Free", 0.0 },
                    { 2, "Plan Basico", 1, "Basica", 19.899999999999999 },
                    { 3, "Plan Premium", 1, "Premium", 39.899999999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RolId",
                table: "Accounts",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_SubscriptionPlanId",
                table: "Accounts",
                column: "SubscriptionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_ProductId",
                table: "Availabilities",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProfiles_AccountId",
                table: "BusinessProfiles",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProfiles_ProviderId",
                table: "BusinessProfiles",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalProfiles_PetId",
                table: "MedicalProfiles",
                column: "PetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalProfiles_ProviderId",
                table: "MedicalProfiles",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_MedicalProfileId",
                table: "MedicalRecords",
                column: "MedicalProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ServicesProviderForeignKey",
                table: "Payments",
                column: "ServicesProviderForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonProfiles_AccountId",
                table: "PersonProfiles",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PersonProfileId",
                table: "Pets",
                column: "PersonProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PJPId",
                table: "Products",
                column: "PJPId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderJoinProducts_ProviderId",
                table: "ProviderJoinProducts",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderJoinProducts_TypeProductId",
                table: "ProviderJoinProducts",
                column: "TypeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PersonProfileId",
                table: "Requests",
                column: "PersonProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ProductId",
                table: "Requests",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PersonProfileId",
                table: "Reviews",
                column: "PersonProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProviderId",
                table: "Reviews",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationRecords_ProfileId",
                table: "VaccinationRecords",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "BusinessProfiles");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "VaccinationRecords");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "MedicalProfiles");

            migrationBuilder.DropTable(
                name: "ProviderJoinProducts");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "TypeProducts");

            migrationBuilder.DropTable(
                name: "PersonProfiles");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans");
        }
    }
}
