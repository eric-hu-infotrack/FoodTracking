namespace FoodTrack.Services
{
    public interface IEmailService
    {
        bool SendEmail(string excelPath, string name);
    }
}
