using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.Enums;

namespace FoodTrack.DataAccess.Entities
{
    public class Order : BaseEntity
    {
        public OrderStatus Status { get; set; }

        public DateTime? LastModified { get; set; }
        public int CategoryId { get; set; }
        //navigation property
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
