using FoodTrack.Models;
using FoodTrack.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IExcelService _excelService { get; set; }

        public OrderController(IExcelService excelService) {
            _excelService = excelService;
        }

        [HttpGet]
        public IActionResult Post()
        {
            //Defining the ContentType for excel file.
            string ContentType = "Application/msexcel";

            //Define the file name.
            string fileName = "Output.xlsx";

            var order = new Order
            {
                Day = "Tuesday",
                ShoppingListId = 1,
                OrderItems = new System.Collections.Generic.List<OrderItem> {
                    new OrderItem()
                }

            };

            var stream = _excelService.CreateAndSendFile(order);

            return File(stream, ContentType, fileName);
        }
    }
}