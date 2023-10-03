using QuickNews.Services.Abstract;

namespace QuickNews.Services.Concrete
{
    public class QuickNewsService : IQuickNewsService
    {
        private INewsService _newsService;
        private IEmailService _emailService;

        public QuickNewsService(INewsService newsService, IEmailService emailService)
        {
            _newsService = newsService;
            _emailService = emailService;
        }
        public bool CurrencyReporter()
        {
            var currencyList = _newsService.GetQuickNews();
            bool isSuccess = _emailService.SendReport(currencyList);
            return isSuccess;
        }
    }
}
