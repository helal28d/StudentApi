using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{
    public class DataContext : DbContext
    {
        //constructor
        public DataContext( DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Gategory> Gategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configure one to many relation using Fluent API
            modelBuilder.Entity<Product>()
                .HasOne<Gategory>(s => s.Gategory)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.GategoryId);
                //.OnDelete(DeleteBehavior.Cascade);
                //
             modelBuilder.Entity<Gategory>().HasData(
                new Gategory {Id=1  ,Name = "Drinks" },
                new Gategory { Id=2, Name = "Books" },
                new Gategory {Id=3,  Name = "Food" }
                );
        }
        //
       

    }
}