using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.Enums
{
    public enum OrderStatus
    {
        Created,
        Finished
    }

    public enum OrderItemStatus
    {
        Untouched,
        Updated
    }

    public enum CategoryType
    {
        //Match with Category Ids
        Groceries = 1,
        SausageDay = 2,
        BurgerDay = 3,
        BaconAndEggDay = 4,
        FridayNight = 5
    }

}
