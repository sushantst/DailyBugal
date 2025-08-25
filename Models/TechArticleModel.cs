using Newtonsoft.Json;

namespace BugalDaily.Models
{
    public class TechArticleModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string SourceName { get; set; }
        public DateTime? PublishedAt { get; set; }
    }


    public class GNewsApiResponse
    {
        [JsonProperty("articles")]
        public List<GNewsArticle> Articles { get; set; } = new();
    }

    public class GNewsArticle
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("publishedAt")]
        public DateTime? PublishedAt { get; set; }

        [JsonProperty("source")]
        public GNewsSource Source { get; set; }
    }

    public class GNewsSource
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }


}
