using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoodTrack.Models.Responses
{
    public class CategoryGetAllResponse : EntitiesResponseBase
    {
        [JsonProperty("items")]
        public List<CategoryResponseIndividual> CategoryResponseIndividuals { get; set; }
    }
}
