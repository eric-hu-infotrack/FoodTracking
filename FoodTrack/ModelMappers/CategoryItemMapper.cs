using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.Constants;
using FoodTrack.DataAccess.Entities;
using FoodTrack.Models.Responses;

namespace FoodTrack.ModelMappers
{
    public static class CategoryItemMapper
    {
        //get all
        public static CategoryItemGetAllResponse MapFromCategoryItemsToCategoryItemGetAllResponse(List<CategoryItem> categoryItems)
        {
            CategoryItemGetAllResponse categoryItemGetAllResponse = new CategoryItemGetAllResponse
            {
                Entities = EntityType.CategoryItems,
                CategoryItemResponseIndividuals = new List<CategoryItemResponseIndividual>()
            };
            foreach (var categoryItem in categoryItems)
            {
                var categoryItemResponseIndividual = MapFromCategoryItemToCategoryItemResponseIndividual(categoryItem);
                categoryItemGetAllResponse.CategoryItemResponseIndividuals.Add(categoryItemResponseIndividual);
            }
            return categoryItemGetAllResponse;
        }

        public static CategoryItemResponseIndividual MapFromCategoryItemToCategoryItemResponseIndividual(CategoryItem categoryItem)
        {
            CategoryItemResponseIndividual categoryItemResponseIndividual = new CategoryItemResponseIndividual
            {
                Id = categoryItem.Id,
                ItemName = categoryItem.Item.Name,
                ItemProfilePath = categoryItem.Item.ProfilePath,
                DefaultQuantityNeeded = categoryItem.DefaultQuantityNeeded,
                FrequencyRate = categoryItem.FrequencyRate,
                RowOrder = categoryItem.RowOrder,
                CategoryId = categoryItem.CategoryId,
                ItemId = categoryItem.ItemId
            };
            return categoryItemResponseIndividual;
        }

    }
}
