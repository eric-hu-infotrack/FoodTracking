using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.Models.Requests
{
    public class OrderCreateRequest
    {
        public int CategoryId { get; set; }
        public List<OrderItemCreateRequest> OrderItemCreateRequests { get; set; }
    }
}
