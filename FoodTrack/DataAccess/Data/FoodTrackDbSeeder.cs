using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodTrack.DataAccess.Data
{
    public static class FoodTrackDbSeeder
    {
        public static async Task Seed(FoodTrackDbContext db)
        {
            await db.Database.MigrateAsync();
            //if any error occurs, rollback the entire transaction(avoid database inconsistency)
            //using (var transaction = await db.Database.BeginTransactionAsync())
            //{
            //    DateTime utcNow = DateTime.UtcNow;
            //    if (!await db.Categories.AnyAsync())
            //    {
            //        List<Category> categories = new List<Category>
            //        {
            //            new Category
            //            {
            //                CreatedAt = utcNow
            //            },
            //            new Category
            //            {
            //                CreatedAt = utcNow
            //            }
            //        };
            //        db.Categories.AddRange(categories);
            //        await db.SaveChangesAsync();
            //    }
            //    if (!await db.Items.AnyAsync())
            //    {
            //        List<Item> costCentres = new List<Item>
            //        {
            //            new Item
            //            {
            //                CreatedAt = utcNow
            //            },
            //            new Item
            //            {
            //                CreatedAt = utcNow
            //            }
            //        };
            //        db.Items.AddRange(costCentres);
            //        await db.SaveChangesAsync();
            //    }
            //    if (!await db.CategoryItems.AnyAsync())
            //    {
            //        List<CategoryItem> sites = new List<CategoryItem>
            //        {
            //            new CategoryItem
            //            {
            //                CreatedAt = utcNow
            //            }
            //        };
            //        db.CategoryItems.AddRange(sites);
            //        await db.SaveChangesAsync();
            //    }
            //    transaction.Commit();
            //}
        }
    }
}
