using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.DataAccess.Data;
using FoodTrack.DataAccess.Entities;
using FoodTrack.ModelMappers;
using FoodTrack.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTrack.Controllers
{
    public class CategoriesController : ApiBaseController
    {
        private readonly FoodTrackDbContext db;

        public CategoriesController(FoodTrackDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CategoryGetAllResponse), 200)]
        public async Task<IActionResult> GetAll()
        {
            List<Category> categories = await db.Categories
                .AsNoTracking()
                .ToListAsync();
            //map to response
            CategoryGetAllResponse categoryGetAllResponse = CategoryMapper.MapFromCategoriesToCategoryGetAllResponse(categories);
            return Ok(categoryGetAllResponse);
        }
    }
}