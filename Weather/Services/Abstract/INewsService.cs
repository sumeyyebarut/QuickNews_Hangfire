using QuickNews.Model;

namespace QuickNews.Services.Abstract
{
    public interface INewsService
    {
        Task<News.Root> GetQuickNews();
    }
}
