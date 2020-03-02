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
    public class OrderController : ControllerBase
    {
        private IExcelService _excelService { get; set; }
        private IEmailService _emailService { get; set; }

        public OrderController(IExcelService excelService, IEmailService emailService) {
            _excelService = excelService;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Post(){
            try
            {
                //Defining the ContentType for excel file.
                string ContentType = "Application/msexcel";

                //Define the file name.
                string fileName = "Order-list.xlsx";

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
                        QuantityToOrder = 3,
                        CategoryItem = new CategoryItem{ Id = 4, Item = new Item{ Quantity = 2} }
                    },
                    new OrderItem(){
                        Id = 2,
                        QuantityNeeded = 6,
                        QuantityToOrder = 4,
                        CategoryItem = new CategoryItem{ Id = 5, Item = new Item{ Quantity = 2} }
                    }
                }
                };

                var filePath = _excelService.CreateAndSaveFile(order);

                if (!string.IsNullOrEmpty(filePath))
                {
                    _emailService.SendEmail(filePath, order.Category.Name);
                }

                return Ok(filePath);

            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}