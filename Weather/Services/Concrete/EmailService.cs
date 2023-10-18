using QuickNews.Model;
using QuickNews.Services.Abstract;
using System;
using System.Threading.Tasks;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace QuickNews.Services.Concrete
{
    public class EmailService : IEmailService
    {
        public bool SendReport(Task<News.Root> quickNewsList)
        {
            var message = new MimeMessage(); //Mesaj gövdesini tanımlıyoruz...
            message.Subject = "Quick Daily News"+ DateTime.Now;
            message.From.Add(new MailboxAddress("sümeyye Barut", "barutsumeyye@gmail.com"));
            message.To.Add(new MailboxAddress("sümeyye Barut", "barutsumeyye@gmail.com"));

            
            message.Body = new TextPart(TextFormat.Html) { Text = HtmlBodyCreator.CreateEmailBody(quickNewsList.Result.QuickNewsList) };

            try
            {
                 using var smtp = new SmtpClient();
                            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                            smtp.Authenticate("barutsumeyye@gmail.com", "*** *** *** ***"); //google hesabımızla uygulama sifresi diye alıyoruz. hesabım/guvenlik
                            smtp.Send(message);
                            smtp.Disconnect(true);
                return true;
            }
            catch (Exception ex )
            {

                throw ex ;
            }
           

           
        }
    }
}
