using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.DataAccess.Entities;

namespace FoodTrack.Services
{
    public interface ICategoryItemService
    {
        IQueryable<CategoryItem> GetCategoryItems();
        /// <summary>
        /// default sorted by row number
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        IQueryable<CategoryItem> GetCategoryItemsForCategory(int? categoryId);
    }
}
