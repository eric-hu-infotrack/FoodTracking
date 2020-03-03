using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.DataAccess.Data;
using FoodTrack.DataAccess.DbExtensions;
using FoodTrack.DataAccess.Entities;
using FoodTrack.ModelMappers;
using FoodTrack.Models.Requests;
using FoodTrack.Models.Responses;
using FoodTrack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTrack.Controllers
{
    public class OrdersController : ApiBaseController
    {
        private readonly FoodTrackDbContext db;
        private readonly IExcelService _excelService;
        private readonly IEmailService _emailService;


        public OrdersController(FoodTrackDbContext db, IExcelService excelService, IEmailService emailService)
        {
            this.db = db;
            this._excelService = excelService;
            this._emailService = emailService;
        }

        /// <summary>
        /// Get single order by id and its accoiciated order items
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)  //create new one
            {
                return IdNotProvidedBadRequest();
            }
            Order order = await db.Orders.IncludeAll().AsNoTracking().SingleOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return ModelNotFound(id);
            }

            //map to response
            OrderResponse orderResponse = OrderMapper.MapFromOrderToOrderResponse(order);
            return Ok(orderResponse);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderResponse), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> Create([FromBody] OrderCreateRequest requestModel)
        {
            DateTime utcNow = DateTime.UtcNow;
            //map to entity
            Order order = OrderMapper.MapFromOrderCreateRequestToOrder(requestModel, utcNow);
            db.Orders.Add(order);

            await db.SaveChangesAsync();

            Order createdOrder = await db.Orders.IncludeAll().AsNoTracking().SingleOrDefaultAsync(o => o.Id == order.Id);

            var filePath = _excelService.CreateAndSaveFile(order);

            if (!string.IsNullOrEmpty(filePath))
            {
                _emailService.SendEmail(filePath, order.Category.Name);
            }

            //map to response
            OrderResponse orderResponse = OrderMapper.MapFromOrderToOrderResponse(order);

            return CreatedAtAction(nameof(GetById), new { id = order.Id }, orderResponse);
        }
    }
}