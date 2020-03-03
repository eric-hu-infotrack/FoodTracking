using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoodTrack.Models.Responses
{
    public class OrderResponseIndividual
    {    
        public int Id { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<OrderItemResponseIndividual> OrderItemResponseIndividuals { get; set; }
    }
}
