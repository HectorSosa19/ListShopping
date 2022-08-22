using Microsoft.EntityFrameworkCore;
using ShoppingList.Entities;

namespace ShoppingList.Context
{
    public class ContextShop : DbContext
    {
        public ContextShop(DbContextOptions<ContextShop> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Brand>()
           .HasOne(e => e.Supermarkets)
           .WithMany(c => c.Brands)
           .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Products>()
          .HasOne(e => e.Supermarket)
          .WithMany(c => c.Products)
          .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Products>()
         .HasOne(e => e.ListShop)
         .WithMany(c => c.Products)
         .OnDelete(DeleteBehavior.ClientCascade);
        }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<ListShop> ListShop { get; set; }
        public DbSet<Supermarket> Supermarket { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
