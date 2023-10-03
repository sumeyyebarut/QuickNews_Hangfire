using QuickNews.Model;

namespace QuickNews.Services.Concrete
{
    public class HtmlBodyCreator
    {
        public static string CreateEmailBody(List<News.Result> list)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(System.IO.Path.GetFullPath("../../../Hangfire/NewsTemplate.html")))
            {
                body = reader.ReadToEnd();
            }

            string message = "";

            foreach (var n in list)
                message += "<b>Haber başlığı: </b>" + n.name + " <b>Haber detayları: </b>" + n.description + " <b>Kaynak: </b>" + n.source + " <b>Haber detayları için tıklayınız: </b>" + n.url + "<br/><br/>";

            body = body.Replace("{message}", message);
            return body;

        }
    }
}
