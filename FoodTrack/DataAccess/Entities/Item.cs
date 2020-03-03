using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.DataAccess.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public string ProfilePath { get; set; }
        public int QuantityInTotal { get; set; }    //quantity in total

        //navigation property
        public virtual ICollection<CategoryItem> CategoryItems { get; set; }
    }
}
