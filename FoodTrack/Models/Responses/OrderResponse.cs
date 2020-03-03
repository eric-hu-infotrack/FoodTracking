using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.Models.Responses
{
    public class OrderResponse : EntityResponseBase
    {
        public OrderResponseIndividual OrderResponseIndividual { get; set; }
    }
}
