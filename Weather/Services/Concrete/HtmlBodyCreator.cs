using QuickNews.Model;

namespace QuickNews.Services.Concrete
{
    public class HtmlBodyCreator
    {
        public static string CreateEmailBody(List<News.Result> list)
        {
            string body = "<html lang=\"tr\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n</head>\r\n<body>\r\n    <table>\r\n        <tr>\r\n            <td>\r\n\r\n                <div style=\"border-top:3px solid #22BCE5\"></div>\r\n                <span style=\"font-family:Arial;font-size:10pt\">\r\n\r\n                    Quick News - sumeyyebarut\r\n                    {message}\r\n\r\n                </span>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>";
            

            string message = "";
            if (list != null) {
                foreach (var n in list)
                    message += "<b>Haber başlığı: </b>" + n.name + " <b>Haber detayları: </b>" + n.description + " <b>Kaynak: </b>" + n.source + " <b>Haber detayları için tıklayınız: </b>" + n.url + "<br/><br/>";
                body = body.Replace("{message}", message);

            }

            return body;

        }
    }
}
