using QuickNews.Model;
using QuickNews.Services.Abstract;
using System.Net.Mail;
using System.Net;
using System;
using System.Threading.Tasks;

namespace QuickNews.Services.Concrete
{
    public class EmailService : IEmailService
    {
        public bool SendReport(Task<News.Root> quickNewsList)
        {
            MailMessage msg = new MailMessage(); //Mesaj gövdesini tanımlıyoruz...
            msg.Subject = "Quick Daily News"+ DateTime.Now;
            msg.From = new MailAddress("barutsumeyye@gmail.com", "Quick Daily News");
            msg.To.Add(new MailAddress("barutsumeyye@gmail.com", "Sumeyye Barut"));

            //Mesaj içeriğinde HTML karakterler yer alıyor ise aşağıdaki alan TRUE olarak gönderilmeli ki HTML olarak yorumlansın. Yoksa düz yazı olarak gönderilir...
            msg.IsBodyHtml = true;
            msg.Body = HtmlBodyCreator.CreateEmailBody(quickNewsList.Result.QuickNewsList);

            //Mesaj önceliği (BELİRTMEK ZORUNLU DEĞİL!)
            msg.Priority = MailPriority.High;

            //SMTP/Gönderici bilgilerinin yer aldığı erişim/doğrulama bilgileri
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); //Bu alanda gönderim yapacak hizmetin smtp adresini ve size verilen portu girmelisiniz.
            NetworkCredential AccountInfo = new NetworkCredential("Sumeyyebarut@gmail.com", "*******");
            smtp.UseDefaultCredentials = false; //Standart doğrulama kullanılsın mı? -> Yalnızca gönderici özellikle istiyor ise TRUE işaretlenir.
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = false; //SSL kullanılarak mı gönderilsin...

            try
            {
                smtp.Send(msg);
                Console.WriteLine("E-Posta başarıyla gönderildi.");
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
