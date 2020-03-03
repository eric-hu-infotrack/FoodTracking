using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoodTrack.Models.Responses
{
    public class CategoryItemGetAllResponse : EntitiesResponseBase
    {
        public int CategoryId { get; set; }

        [JsonProperty("items")]
        public List<CategoryItemResponseIndividual> CategoryItemResponseIndividuals { get; set; }
    }
}
