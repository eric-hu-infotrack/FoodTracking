using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.DataAccess.Entities
{
    public class CategoryItem : BaseEntity
    {
        public int DefaultQuantityNeeded { get; set; }
        public int FrequencyRate { get; set;  }   //how many times per week
        public int RowOrder { get; set; }      //a number indicating list order in ui
        public int CategoryId { get; set; }   //fk
        public int ItemId { get; set; }      //fk


        //navigation property
        public virtual Category Category { get; set; }
        public virtual Item Item { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
