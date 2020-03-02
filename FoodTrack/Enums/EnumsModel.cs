using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.Enums
{
    public class EnumsModel
    {
        public enum OrderStatus
        {
            Created,
            Pending,
            Finished
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
}
