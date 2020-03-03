using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoodTrack.Models.Responses
{
    public class OrderItemResponseIndividual
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string ItemName { get; set; }

        public string ItemProfilePath { get; set; }

        public int QuantityNeeded { get; set; }

        public int AvailableQuantity { get; set; }

        public int QuantityToOrder { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
