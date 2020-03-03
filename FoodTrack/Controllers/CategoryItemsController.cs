using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.DataAccess.Data;
using FoodTrack.DataAccess.Entities;
using FoodTrack.ModelMappers;
using FoodTrack.Models.Responses;
using FoodTrack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTrack.Controllers
{
    public class CategoryItemsController : ApiBaseController
    {
        private readonly FoodTrackDbContext db;
        private readonly ICategoryItemService _categoryItemService;

        public CategoryItemsController(FoodTrackDbContext db, ICategoryItemService categoryItemService)
        {
            this.db = db;
            this._categoryItemService = categoryItemService;
        }

        /// <summary>
        /// Get all categorie items for one category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CategoryItemGetAllResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> GetAll(int? categoryId)
        {
            if (categoryId == null)
            {
                return IdNotProvidedBadRequest();
            }

            List<CategoryItem> categoryItems = await _categoryItemService.GetCategoryItemsForCategory(categoryId)
                .AsNoTracking()
                .ToListAsync();
            //map to response
            CategoryItemGetAllResponse categoryItemGetAllResponse = CategoryItemMapper.MapFromCategoryItemsToCategoryItemGetAllResponse(categoryItems);
            return Ok(categoryItemGetAllResponse);
        }

    }
}
