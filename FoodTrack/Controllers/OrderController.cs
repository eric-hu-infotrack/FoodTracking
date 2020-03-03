using System;
using System.IO;
using FoodTrack.DataAccess.Entities;
using FoodTrack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiBaseController
    {
        private IExcelService _excelService { get; set; }
        private IEmailService _emailService { get; set; }

        public OrderController(IExcelService excelService, IEmailService emailService) {
            _excelService = excelService;
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult Post(){
            try
            {
                var order = new Order
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    Category = new Category { Id = 1, Name = "Groceries" },
                    CategoryId = 1,
                    OrderItems = new System.Collections.Generic.List<OrderItem> {
                    new OrderItem(){
                        Id = 1,
                        QuantityNeeded = 5,
                        CategoryItem = new CategoryItem{ Id = 1, Item = new Item{ QuantityInTotal = 2} , RowOrder=4 }
                    },
                    new OrderItem(){
                        Id = 2,
                        QuantityNeeded = 6,
                        CategoryItem = new CategoryItem{ Id = 5, Item = new Item{ QuantityInTotal = 2}, RowOrder=5}
                    }
                }
                };

                var filePath = _excelService.CreateAndSaveFile(order);

                if (!string.IsNullOrEmpty(filePath))
                {
                    _emailService.SendEmail(filePath, order.Category.Name);
                }

                return Ok("Email Sent");

            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}