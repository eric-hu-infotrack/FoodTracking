using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTrack.DataAccess
{
    public class DbGlobalSettings
    {
        public static string ConnectionString { get; set; }     //provide database connection string everywhere
    }
}
