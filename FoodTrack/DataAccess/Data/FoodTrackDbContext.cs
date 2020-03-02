using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodTrack.DataAccess.Data
{
    public class FoodTrackDbContext : DbContext
    {
        public FoodTrackDbContext()
        {
        }

        public FoodTrackDbContext(DbContextOptions<FoodTrackDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //soft-delete global query filter
            modelBuilder.Entity<Category>().HasQueryFilter(e => e.IsDeleted == false);
            modelBuilder.Entity<Item>().HasQueryFilter(ce => ce.IsDeleted == false);
            modelBuilder.Entity<CategoryItem>().HasQueryFilter(sj => sj.IsDeleted == false);
            modelBuilder.Entity<Order>().HasQueryFilter(sr => sr.IsDeleted == false);
            modelBuilder.Entity<OrderItem>().HasQueryFilter(cje => cje.IsDeleted == false);

            //category : item many to many configuration
            modelBuilder.Entity<CategoryItem>()
                .HasOne(ci => ci.Category)
                .WithMany(c => c.CategoryItems)
                .HasForeignKey(ci => ci.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CategoryItem>()
                .HasOne(ci => ci.Item)
                .WithMany(i => i.CategoryItems)
                .HasForeignKey(ci => ci.ItemId);
        }

        //provide a non-DI way to init dbcontext 
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseLazyLoadingProxies().UseSqlServer(DbGlobalSettings.ConnectionString);
        //    }
        //}

    }
}
