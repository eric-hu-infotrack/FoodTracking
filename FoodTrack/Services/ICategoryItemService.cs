using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.DataAccess.Entities;

namespace FoodTrack.Services
{
    public interface ICategoryItemService
    {
        /// <summary>
        /// default ordered by name
        /// </summary>
        /// <returns></returns>
        IQueryable<CategoryItem> GetCategoryItemsForCategory(int? categoryId);
    }
}
