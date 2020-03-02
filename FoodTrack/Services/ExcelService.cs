using System.IO;
using System.Threading.Tasks;
using FoodTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.XlsIO;

namespace FoodTrack.Services
{
    public class ExcelService : IExcelService
    {
        public Stream CreateAndSendFile(Order order)
        {
            //New instance of ExcelEngine is created 
            //Equivalent to launching Microsoft Excel with no workbooks open
            //Instantiate the spreadsheet creation engine
            ExcelEngine excelEngine = new ExcelEngine();

            //Instantiate the Excel application object
            IApplication application = excelEngine.Excel;

            //Assigns default application version
            application.DefaultVersion = ExcelVersion.Excel2013;

            //A existing workbook is opened.              
            string basePath = @"C:\Users\Florencia.RojasAmaya\Documents\FoodTracking\FoodTrack\ExcelFiles\Woolworths-list.xlsx";
            FileStream sampleFile = new FileStream(basePath, FileMode.Open);

            IWorkbook workbook = application.Workbooks.Open(sampleFile);

            //Access first worksheet from the workbook.
            IWorksheet worksheet = workbook.Worksheets[0];

            //Set Text in cell A3.
            worksheet.Range["B4"].Text = "Hello World";
            
            //Creating stream object.
            MemoryStream stream = new MemoryStream();

            //Saving the workbook to stream in XLSX format
            workbook.SaveAs(stream);

            stream.Position = 0;

            //Closing the workbook.
            workbook.Close();

            //Dispose the Excel engine
            excelEngine.Dispose();

            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return stream;
        }
    }
}
