using Merchandising.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Merchandising.Domain.Context;

public class MerchandisingDbContext : DbContext, IDisposable, IMerchandisingDbContext
{
    public MerchandisingDbContext(DbContextOptions<MerchandisingDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseLazyLoadingProxies();
    }
}
