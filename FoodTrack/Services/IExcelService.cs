using FoodTrack.DataAccess.Entities;

namespace FoodTrack.Services
{
    public interface IExcelService
    {
        string CreateAndSaveFile(Order order);
    }
}
