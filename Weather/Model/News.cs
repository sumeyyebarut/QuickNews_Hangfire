namespace QuickNews.Model
{
    public class News { 
    public class Result
    {
        public string key { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string source { get; set; }
    }

    public class Root
    {
        public List<Result> QuickNewsList { get; set; }
    }
}
}