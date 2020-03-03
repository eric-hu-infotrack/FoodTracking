using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.Constants;
using FoodTrack.DataAccess.Entities;
using FoodTrack.Models.Responses;

namespace FoodTrack.ModelMappers
{
    public static class CategoryMapper
    {
        //get all
        public static CategoryGetAllResponse MapFromCategoriesToCategoryGetAllResponse(List<Category> categories)
        {
            CategoryGetAllResponse categoryGetAllResponse = new CategoryGetAllResponse
            {
                Entities = EntityType.Categories,
                CategoryResponseIndividuals = new List<CategoryResponseIndividual>()
            };
            foreach (var category in categories)
            {
                var categoryResponseIndividual = MapFromCategoryToCategoryResponseIndividual(category);
                categoryGetAllResponse.CategoryResponseIndividuals.Add(categoryResponseIndividual);
            }
            return categoryGetAllResponse;
        }

        public static CategoryResponseIndividual MapFromCategoryToCategoryResponseIndividual(Category category)
        {
            CategoryResponseIndividual categoryResponseIndividual = new CategoryResponseIndividual
            {
                Id = category.Id,
                Name = category.Name,
                ProfilePath = category.ProfilePath
            };
            return categoryResponseIndividual;
        }
    }
}
