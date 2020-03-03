using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodTrack.DataAccess.DbExtensions
{
    public static class OrderDbExtensions
    {
        /// <summary>
        /// eager load necessary data for potential get request in api
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IQueryable<Order> IncludeAll(this IQueryable<Order> source)
        {
            return source
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.CategoryItem.Item)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.CategoryItem.Category);                
        }
    }
}
