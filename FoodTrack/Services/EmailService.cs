using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace FoodTrack.Services
{
    public class EmailService : IEmailService
    {
        private IConfiguration _configuration { get; set; }
        public EmailService(IConfiguration configuration) {
            _configuration = configuration;
        }
        public bool SendEmail(string excelPath, string name)
        {
            try
            {
                string AppLocation = "";
                string file = excelPath;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(_configuration.GetSection("EmailSettings").GetSection("Host").Value);
                mail.From = new MailAddress(_configuration.GetSection("EmailSettings").GetSection("MailFrom").Value);
                mail.To.Add("florenciarojasamaya@gmail.com"); // Sending MailTo  
                mail.Subject = "Shopping List - "+ name; // Mail Subject  
                mail.Body = "*This is an automatically generated email, please do not reply*";
                var attachment = new Attachment(file); //Attaching File to Mail  
                mail.Attachments.Add(attachment);
                SmtpServer.Port = Convert.ToInt32(_configuration.GetSection("EmailSettings").GetSection("Port").Value); //PORT  
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Credentials = new NetworkCredential("foodtrack.infotrack", "foodtrack123");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
