using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.Constants;
using FoodTrack.DataAccess.Entities;
using FoodTrack.Enums;
using FoodTrack.Models.Requests;
using FoodTrack.Models.Responses;

namespace FoodTrack.ModelMappers
{
    public static class OrderMapper
    {
        //get individual
        public static OrderResponse MapFromOrderToOrderResponse(Order order)
        {
            OrderResponse orderResponse = new OrderResponse
            {
                Entity = EntityType.Order
            };
            orderResponse.OrderResponseIndividual = MapFromOrderToOrderResponseIndividual(order, true);  //should include children properties here
            return orderResponse;
        }

        /// <summary>
        /// crew should include its crewEmployees and its employee
        /// </summary>
        /// <param name="order"></param>
        /// <param name="expandChildObjects"></param>
        /// <returns></returns>
        private static OrderResponseIndividual MapFromOrderToOrderResponseIndividual(Order order, bool expandChildObjects = false)
        {
            var orderResponseIndividual = new OrderResponseIndividual
            {
                Id = order.Id
            };

            if (expandChildObjects == true)
            {
                orderResponseIndividual.OrderItemResponseIndividuals = new List<OrderItemResponseIndividual>();
                foreach (var item in order.OrderItems)
                {
                    var orderItemResponseIndividual = OrderItemMapper.MapFromOrderItemToOrderItemResponseIndividual(item);
                    orderResponseIndividual.OrderItemResponseIndividuals.Add(orderItemResponseIndividual);
                }
            }

            return orderResponseIndividual;
        }


        public static Order MapFromOrderCreateRequestToOrder(OrderCreateRequest orderCreateRequest, DateTime utcNow)
        {
            Order order = new Order
            {
                CreatedAt = utcNow,
                Status = OrderStatus.Created,
                LastModified = utcNow,
                OrderItems = new List<OrderItem>(),
                CategoryId = orderCreateRequest.CategoryId
            };
            foreach (var orderItemCreateRequest in orderCreateRequest.OrderItemCreateRequests)
            {
                var orderItem = OrderItemMapper.MapFromOrderItemCreateRequestToOrderItem(orderItemCreateRequest, utcNow);
                order.OrderItems.Add(orderItem);
            }
            return order;
        }
    }
}
