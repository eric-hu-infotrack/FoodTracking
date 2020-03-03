using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.DataAccess.Entities
{
    public class OrderItem : BaseEntity
    {        
        public int AvailableQuantity { get; set; }  //quantity available at that point
        public int QuantityNeeded { get; set; }     //total quantity we need

        public DateTime? LastModified { get; set; }

        public int OrderId { get; set; }   //fk
        public int CategoryItemId { get; set; }    //fk
        //navigation property
        public virtual Order Order { get; set; }
        public virtual CategoryItem CategoryItem { get; set; }
    }
}
