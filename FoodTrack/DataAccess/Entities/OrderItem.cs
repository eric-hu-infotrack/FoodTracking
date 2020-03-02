using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.DataAccess.Entities
{
    public class OrderItem : BaseEntity
    { 
        public int QuantityToOrder { get; set; }   
        public int QuantityNeeded { get; set; }     //total quantity we need

        public DateTime? LastModified { get; set; }

        public int OrderId { get; set; }   //fk
        public int ItemId { get; set; }    //fk
        //navigation property
        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
    }
}
