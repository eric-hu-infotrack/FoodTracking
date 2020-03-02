using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.DataAccess.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string ProfilePath { get; set; }   //photo url

        //navigation property
        public virtual ICollection<CategoryItem> CategoryItems { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
