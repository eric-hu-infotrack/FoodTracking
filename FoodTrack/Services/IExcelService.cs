using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FoodTrack.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrack.Services
{
    public interface IExcelService
    {
        Stream CreateAndSendFile(Order order);
    }
}
