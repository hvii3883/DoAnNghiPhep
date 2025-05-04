using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EmailService
    {
       
            public void SendEmail(string toEmail, string subject, string body)
            {
                var fromAddress = new MailAddress("youremail@gmail.com", "Quản lý nghỉ phép");
                var toAddress = new MailAddress(toEmail);
                string fromPassword = "exux gpix weqg nfhv"; // dùng App Password của Gmail

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("thianhtta@gmail.com", fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
        }
    }

