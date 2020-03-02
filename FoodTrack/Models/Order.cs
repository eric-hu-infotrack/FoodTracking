using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.Models
{
    public class Order
    {
        public string Day { get; set; }

        public int ShoppingListId { get; set; }

        public List<OrderItem> OrderItems { get; set;}
        
    }

public class OrderItem
{
    public string Name { get; set; }
    public int Expected { get; set; }
    public int Counted { get; set; }
    public int ToOrder { get; set; }
    }
}
