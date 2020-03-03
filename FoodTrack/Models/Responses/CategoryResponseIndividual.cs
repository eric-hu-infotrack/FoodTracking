using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.Models.Responses
{
    public class CategoryResponseIndividual
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }   //photo url
    }
}
