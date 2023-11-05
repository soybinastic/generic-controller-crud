
using Inventory.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Data;

public class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) {}
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
}