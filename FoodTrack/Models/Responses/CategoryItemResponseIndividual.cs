using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.Models.Responses
{
    public class CategoryItemResponseIndividual
    {
        public int Id { get; set; }
        public int DefaultQuantityNeeded { get; set; }
        public int FrequencyRate { get; set; }   //how many times per week
        public int RowOrder { get; set; }      //a number indicating list order in ui
        public int CategoryId { get; set; }   //fk
        public int ItemId { get; set; }      //fk
    }
}
