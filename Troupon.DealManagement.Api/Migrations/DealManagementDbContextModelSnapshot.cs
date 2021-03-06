// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Troupon.DealManagement.Infra.Persistence;

namespace Troupon.DealManagement.Api.Migrations
{
    [DbContext(typeof(DealsDbContext))]
    partial class DealManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Troupon.DealManagement")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Account.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BillingInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MerchantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BillingInfoId");

                    b.HasIndex("LocationId");

                    b.HasIndex("MerchantId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Account.BillingInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreditCardId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CreditCardId");

                    b.ToTable("BillingInfos");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Category.DealCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DealId");

                    b.ToTable("DealCategories");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Common.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateProvince")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Common.CreditCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cvv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Common.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrencyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Common.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("PositionId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Common.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Common.Price", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<Guid?>("CurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Deal.Deal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Limitation")
                        .HasColumnType("int");

                    b.Property<string>("OtherConditions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Deal.DealOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DealId");

                    b.ToTable("DealOptions");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Deal.DealPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CurrentPriceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DealOptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OriginalPriceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("CurrentPriceId");

                    b.HasIndex("DealOptionId");

                    b.HasIndex("OriginalPriceId");

                    b.ToTable("DealPrices");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Merchant.Merchant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Merchants");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Account.Account", b =>
                {
                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Account.BillingInfo", "BillingInfo")
                        .WithMany()
                        .HasForeignKey("BillingInfoId");

                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Common.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Merchant.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId");

                    b.Navigation("BillingInfo");

                    b.Navigation("Location");

                    b.Navigation("Merchant");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Account.BillingInfo", b =>
                {
                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Common.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Common.CreditCard", "CreditCard")
                        .WithMany()
                        .HasForeignKey("CreditCardId");

                    b.Navigation("Address");

                    b.Navigation("CreditCard");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Category.DealCategory", b =>
                {
                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Deal.Deal", null)
                        .WithMany("Categories")
                        .HasForeignKey("DealId");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Common.Location", b =>
                {
                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Common.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Common.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.Navigation("Address");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Common.Price", b =>
                {
                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Common.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Deal.Deal", b =>
                {
                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Account.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Deal.DealOption", b =>
                {
                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Deal.Deal", null)
                        .WithMany("Options")
                        .HasForeignKey("DealId");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Deal.DealPrice", b =>
                {
                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Common.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Common.Price", "CurrentPrice")
                        .WithMany()
                        .HasForeignKey("CurrentPriceId");

                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Deal.DealOption", null)
                        .WithMany("Prices")
                        .HasForeignKey("DealOptionId");

                    b.HasOne("Troupon.DealManagement.Core.Domain.Entities.Common.Price", "OriginalPrice")
                        .WithMany()
                        .HasForeignKey("OriginalPriceId");

                    b.Navigation("Currency");

                    b.Navigation("CurrentPrice");

                    b.Navigation("OriginalPrice");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Deal.Deal", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Options");
                });

            modelBuilder.Entity("Troupon.DealManagement.Core.Domain.Entities.Deal.DealOption", b =>
                {
                    b.Navigation("Prices");
                });
#pragma warning restore 612, 618
        }
    }
}
