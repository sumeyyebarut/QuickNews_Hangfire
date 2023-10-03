
using System.Threading.Tasks;
using QuickNews.Model;
namespace QuickNews.Services.Abstract
{
   
        public interface IEmailService
        {
            bool SendReport(Task<News.Root> quickNewsList);
        
    }
}
