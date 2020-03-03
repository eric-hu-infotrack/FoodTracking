using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.Models.Requests
{
    public class OrderItemCreateRequest
    {
        public int AvailableQuantity { get; set; }
        public int QuantityNeeded { get; set; }     //total quantity we need

        public int CategoryItemId { get; set; }    //fk
    }
}
