using System;
using System.IO;
using FoodTrack.DataAccess.Entities;
using FoodTrack.Enums;
using Syncfusion.XlsIO;

namespace FoodTrack.Services
{
    public class ExcelService : IExcelService
    {
        private readonly string Expected_Column_Char = "B";
        private readonly string Counted_Column_Char = "C";
        private readonly string ToOrder_Column_Char = "D";

        public string CreateAndSaveFile(Order order)
        {
            //New instance of ExcelEngine is created 
            //Equivalent to launching Microsoft Excel with no workbooks open
            //Instantiate the spreadsheet creation engine
            ExcelEngine excelEngine = new ExcelEngine();

            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            string basePath = "";
            //A existing workbook is opened.  
            switch (order.CategoryId) {
                case (int)CategoryType.Groceries:
                    {
                        basePath = @"C:\Users\Florencia.RojasAmaya\Documents\FoodTracking\FoodTrack\ExcelFiles\Groceries.xlsx";
                        break;
                    };
                case (int)CategoryType.SausageDay:
                    {
                        basePath = @"C:\Users\Florencia.RojasAmaya\Documents\FoodTracking\FoodTrack\ExcelFiles\Sausage-day.xlsx";
                        break;
                    };
                case (int)CategoryType.BurgerDay:
                    {
                        basePath = @"C:\Users\Florencia.RojasAmaya\Documents\FoodTracking\FoodTrack\ExcelFiles\Burger-day.xlsx";
                        break;
                    };
                case (int)CategoryType.BaconAndEggDay:
                    {
                        basePath = @"C:\Users\Florencia.RojasAmaya\Documents\FoodTracking\FoodTrack\ExcelFiles\Bacon-and-eggs.xlsx";
                        break;
                    };
                case (int)CategoryType.FridayNight:
                    {
                        basePath = @"C:\Users\Florencia.RojasAmaya\Documents\FoodTracking\FoodTrack\ExcelFiles\Friday-night.xlsx";
                        break;
                    };
                default:
                    break;
            }

            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ExcelFiles\Woolworths-list.xlsx");

            FileStream sampleFile = new FileStream(basePath, FileMode.Open);

            IWorkbook workbook = application.Workbooks.Open(sampleFile);

            //Access first worksheet from the workbook.
            IWorksheet worksheet = workbook.Worksheets[0];

            //Set Text.
            worksheet.Range["B1"].Text = order.CreatedAt.DayOfWeek.ToString();

            foreach (var item in order.OrderItems) {
                var cell_expected = Expected_Column_Char + item.CategoryItem.RowOrder;
                var cell_counted = Counted_Column_Char + item.CategoryItem.RowOrder;
                var cell_toOrder = ToOrder_Column_Char + item.CategoryItem.RowOrder;

                worksheet.Range[cell_expected].Text = item.QuantityNeeded.ToString();
                worksheet.Range[cell_counted].Text = item.AvailableQuantity.ToString();
                worksheet.Range[cell_toOrder].Text = (item.QuantityNeeded - item.AvailableQuantity).ToString();
            }

            //Creating stream object.
            MemoryStream stream = new MemoryStream();

            //Saving the workbook to stream in XLSX format
            workbook.SaveAs(stream, ExcelSaveType.SaveAsXLS);

            stream.Position = 0;

            //Closing the workbook.
            workbook.Close();

            //Dispose the Excel engine
            excelEngine.Dispose();
            
            //Defining the ContentType for excel file.
            string ContentType = "Application/msexcel";

            //Define the file name.
            string fileName = "Order-list-"+order.Id+".xlsx";
            var path = @"C:\files\";

            //Save the workbook in file system as XLSX format
            SaveStreamAsFile(path, stream, fileName);

            return path+ fileName;
        }

        public static void SaveStreamAsFile(string filePath, Stream inputStream, string fileName)
        {
            try
            {

                DirectoryInfo info = new DirectoryInfo(filePath);
                if (!info.Exists)
                {
                    info.Create();
                }

                string path = Path.Combine(filePath, fileName);
                using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
                {
                    inputStream.CopyTo(outputFileStream);
                }
            }
            catch (Exception ex) {
                inputStream.Dispose();
            }
        }

    } 
}
