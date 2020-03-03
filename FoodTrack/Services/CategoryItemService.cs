using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.DataAccess.Data;
using FoodTrack.DataAccess.Entities;

namespace FoodTrack.Services
{
    public class CategoryItemService : ICategoryItemService
    {
        private readonly FoodTrackDbContext db;

        public CategoryItemService(FoodTrackDbContext db)
        {
            this.db = db;
        }

        IQueryable<CategoryItem> ICategoryItemService.GetCategoryItems()
        {
            var categoryItems = db.CategoryItems.AsQueryable();
            return categoryItems;
        }

        IQueryable<CategoryItem> ICategoryItemService.GetCategoryItemsForCategory(int? categoryId)
        {
            var categoryItems = db.CategoryItems.Where(ci => ci.CategoryId == categoryId).OrderBy(ci => ci.RowOrder);
            return categoryItems;
        }
    }
}
