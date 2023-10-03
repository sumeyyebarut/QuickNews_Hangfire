using Newtonsoft.Json;
using QuickNews.Model;
using QuickNews.Services.Abstract;
using System.Net;

namespace QuickNews.Services.Concrete
{
    public class NewsService : INewsService
    {
        public NewsService()
        {

        }
        public async Task<News.Root> GetQuickNews()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var requestMessage =
                        new HttpRequestMessage(HttpMethod.Get,
                            "https://api.collectapi.com/news/getNews?country=tr&tag=general");

                    requestMessage.Headers.Add("Authorization", "apikey 5HgJg0Chu1YFbyHHFjELua:5M81bWcCkM330VhNZkvTXP");
                    // account açıp api key alınmalı, api'ya subscribe olunmalı.

                    var result = client.SendAsync(requestMessage);

                    if (result.Result.StatusCode != HttpStatusCode.OK)
                        throw new Exception(result.Result.RequestMessage.ToString());

                    if (result.Result.Content is object &&
                        result.Result.Content.Headers.ContentType.MediaType == "application/json")
                    {
                        var contentStream = await result.Result.Content.ReadAsStreamAsync();
                        var streamReader = new StreamReader(contentStream);
                        var jsonReader = new JsonTextReader(streamReader);

                        JsonSerializer serializer = new JsonSerializer();

                        try
                        {
                            var list = serializer.Deserialize<News.Root>(jsonReader);
                            return list;
                        }
                        catch (JsonReaderException e)
                        {
                            throw new Exception(e.Message);
                        }
                    }
                    throw new Exception("Content/MediaType error");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);

                }
            }
        }
    }
}
