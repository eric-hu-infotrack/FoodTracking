using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.DataAccess.Entities;
using FoodTrack.Models.Requests;
using FoodTrack.Models.Responses;

namespace FoodTrack.ModelMappers
{
    public static class OrderItemMapper
    {
        /// <summary>
        /// OrderItem should include its CategoryItem and it's Item and Category
        /// </summary>
        /// <param name="orderItem"></param>
        /// <returns></returns>
        public static OrderItemResponseIndividual MapFromOrderItemToOrderItemResponseIndividual(OrderItem orderItem)
        {
            var category = orderItem.CategoryItem.Category;
            var item = orderItem.CategoryItem.Item;
            var orderItemResponseIndividual = new OrderItemResponseIndividual
            {
                Id = orderItem.Id,
                CategoryName = category.Name,
                ItemName = item.Name,
                ItemProfilePath = item.ProfilePath,
                QuantityNeeded = orderItem.QuantityNeeded > 0 ? orderItem.QuantityNeeded : orderItem.CategoryItem.DefaultQuantityNeeded,
                AvailableQuantity = orderItem.AvailableQuantity,
                
                LastModified = orderItem.LastModified
            };
            orderItemResponseIndividual.QuantityToOrder = orderItemResponseIndividual.QuantityNeeded - orderItemResponseIndividual.AvailableQuantity;
            return orderItemResponseIndividual;
        }

        public static OrderItem MapFromOrderItemCreateRequestToOrderItem(OrderItemCreateRequest orderItemCreateRequest, DateTime utcNow)
        {
            OrderItem orderItem = new OrderItem
            {
                CreatedAt = utcNow,
                LastModified = utcNow,
                QuantityNeeded = orderItemCreateRequest.QuantityNeeded,
                AvailableQuantity = orderItemCreateRequest.AvailableQuantity   //user input
            };
            return orderItem;
        }
    }
}
