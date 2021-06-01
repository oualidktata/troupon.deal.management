using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Troupon.DealManagement.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Troupon.DealManagement");

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateProvince = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cvv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillingInfos",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreditCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingInfos_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillingInfos_CreditCards_CreditCardId",
                        column: x => x.CreditCardId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "CreditCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Positions_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BillingInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_BillingInfos_BillingInfoId",
                        column: x => x.BillingInfoId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "BillingInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Limitation = table.Column<int>(type: "int", nullable: false),
                    OtherConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deals_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DealCategories",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DealId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealCategories_Deals_DealId",
                        column: x => x.DealId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "Deals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DealOptions",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DealId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealOptions_Deals_DealId",
                        column: x => x.DealId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "Deals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DealPrices",
                schema: "Troupon.DealManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OriginalPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentPriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DealOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealPrices_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DealPrices_DealOptions_DealOptionId",
                        column: x => x.DealOptionId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "DealOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DealPrices_Prices_CurrentPriceId",
                        column: x => x.CurrentPriceId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DealPrices_Prices_OriginalPriceId",
                        column: x => x.OriginalPriceId,
                        principalSchema: "Troupon.DealManagement",
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BillingInfoId",
                schema: "Troupon.DealManagement",
                table: "Accounts",
                column: "BillingInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_LocationId",
                schema: "Troupon.DealManagement",
                table: "Accounts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_MerchantId",
                schema: "Troupon.DealManagement",
                table: "Accounts",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInfos_AddressId",
                schema: "Troupon.DealManagement",
                table: "BillingInfos",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingInfos_CreditCardId",
                schema: "Troupon.DealManagement",
                table: "BillingInfos",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_DealCategories_DealId",
                schema: "Troupon.DealManagement",
                table: "DealCategories",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_DealOptions_DealId",
                schema: "Troupon.DealManagement",
                table: "DealOptions",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_DealPrices_CurrencyId",
                schema: "Troupon.DealManagement",
                table: "DealPrices",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DealPrices_CurrentPriceId",
                schema: "Troupon.DealManagement",
                table: "DealPrices",
                column: "CurrentPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_DealPrices_DealOptionId",
                schema: "Troupon.DealManagement",
                table: "DealPrices",
                column: "DealOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_DealPrices_OriginalPriceId",
                schema: "Troupon.DealManagement",
                table: "DealPrices",
                column: "OriginalPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_AccountId",
                schema: "Troupon.DealManagement",
                table: "Deals",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                schema: "Troupon.DealManagement",
                table: "Locations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_PositionId",
                schema: "Troupon.DealManagement",
                table: "Locations",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_CurrencyId",
                schema: "Troupon.DealManagement",
                table: "Prices",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealCategories",
                schema: "Troupon.DealManagement");

            migrationBuilder.DropTable(
                name: "DealPrices",
                schema: "Troupon.DealManagement");

            migrationBuilder.DropTable(
                name: "DealOptions",
                schema: "Troupon.DealManagement");

            migrationBuilder.DropTable(
                name: "Prices",
                schema: "Troupon.DealManagement");

            migrationBuilder.DropTable(
                name: "Deals",
                schema: "Troupon.DealManagement");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "Troupon.DealManagement");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "Troupon.DealManagement");

            migrationBuilder.DropTable(
                name: "BillingInfos",
                schema: "Troupon.DealManagement");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "Troupon.DealManagement");

            migrationBuilder.DropTable(
                name: "Merchants",
                schema: "Troupon.DealManagement");

            migrationBuilder.DropTable(
                name: "CreditCards",
                schema: "Troupon.DealManagement");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "Troupon.DealManagement");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "Troupon.DealManagement");
        }
    }
}
