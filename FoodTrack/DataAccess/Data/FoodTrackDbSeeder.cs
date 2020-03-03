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
            using (var transaction = await db.Database.BeginTransactionAsync())
            {
                DateTime utcNow = DateTime.UtcNow;
                if (!await db.Categories.AnyAsync())
                {
                    List<Category> categories = new List<Category>
                    {
                        new Category
                        {
                            CreatedAt = utcNow,
                            Name = "Groceries",
                            ProfilePath = "https://cdn.pixabay.com/photo/2015/09/02/12/25/basket-918416_960_720.jpg"
                        },
                        new Category
                        {
                            CreatedAt = utcNow,
                            Name = "Sausage Sizzle",
                            ProfilePath = "https://cdn.pixabay.com/photo/2018/07/08/20/18/grill-party-3524649_960_720.jpg"
                        },
                        new Category
                        {
                            CreatedAt = utcNow,
                            Name = "Burger",
                            ProfilePath = "https://cdn.pixabay.com/photo/2015/04/20/13/25/burger-731298_960_720.jpg"
                        },
                        new Category
                        {
                            CreatedAt = utcNow,
                            Name = "Bacon and Egg Breakfast",
                            ProfilePath = "https://cdn.pixabay.com/photo/2020/02/06/13/43/breakfast-4824364_960_720.jpg"
                        },    
                        new Category
                        {
                            CreatedAt = utcNow,
                            Name = "Friday Night",
                            ProfilePath = "https://cdn.pixabay.com/photo/2016/05/26/19/37/chips-potatoes-1418192_960_720.jpg"
                        },
                    };
                    db.Categories.AddRange(categories);
                    await db.SaveChangesAsync();
                }
                if (!await db.Items.AnyAsync())
                {
                    //List<Item> items = new List<Item>
                    //{
                    //    new Item
                    //    {
                    //        CreatedAt = utcNow,
                    //        QuantityInTotal = 10,
                    //        Name = "BS",
                    //        ProfilePath = ""
                    //    },
                    //    new Item
                    //    {

                    //    }
                    //};
                    //db.Items.AddRange(items);
                    //await db.SaveChangesAsync();
                }
                if (!await db.CategoryItems.AnyAsync())
                {
                    //List<CategoryItem> categoryItems = new List<CategoryItem>
                    //{
                    //    new CategoryItem
                    //    {
                    //        CreatedAt = utcNow,
                    //        DefaultQuantityNeeded
                    //        FrequencyRate = 
                    //        RowOrder = 1,
                    //        CategoryId = 2,
                    //        ItemId = 1
                    //    }
                    //};
                    //db.CategoryItems.AddRange(categoryItems);
                    //await db.SaveChangesAsync();
                }
                transaction.Commit();
            }
        }
    }
}
