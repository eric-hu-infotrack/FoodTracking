using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.DataAccess.Entities
{
    public class CategoryItem : BaseEntity
    {
        public int CategoryId { get; set; }
        public int ItemId { get; set; }
        public int DefaultToOrderNumber { get; set; }
        public int FrequencyRate { get; set;  }   //how many times per week

        //navigation property
        public virtual Category Category { get; set; }
        public virtual Item Item { get; set; }
    }
}
