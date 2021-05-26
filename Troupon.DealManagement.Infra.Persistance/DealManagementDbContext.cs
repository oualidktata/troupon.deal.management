using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Troupon.DealManagement.Core.Domain.Entities.Account;
using Troupon.DealManagement.Core.Domain.Entities.Category;
using Troupon.DealManagement.Core.Domain.Entities.Common;
using Troupon.DealManagement.Core.Domain.Entities.Deal;
using Troupon.DealManagement.Core.Domain.Entities.Merchant;

namespace Troupon.DealManagement.Infra.Persistence
{
  public class DealManagementDbContext : DbContext
  {
    public DbSet<Deal> Deals { get; set; }
    public DbSet<DealOption> DealOptions { get; set; }
    public DbSet<DealPrice> DealPrices { get; set; }
    public DbSet<Merchant> Merchants { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<DealCategory> DealCategories { get; set; }
    public DbSet<BillingInfo> BillingInfos { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Price> Prices { get; set; }

    public DealManagementDbContext(
      DbContextOptions<DealManagementDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(
      ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("Troupon.DealManagement");
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
  }
}
