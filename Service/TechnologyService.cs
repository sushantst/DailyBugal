using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using BugalDaily.Models;

namespace BugalDaily.Service
{
    public class TechnologyService
    {
        private readonly string _apiKey = "7a121d9364a4607d21324d87477d5be7";

        public async Task<List<TechArticleModel>> GetTechnologyNewsAsync()
        {
            using var client = new HttpClient();

            var url = $"https://gnews.io/api/v4/top-headlines?category=technology&lang=en&apikey={_apiKey}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TechArticleModel>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GNewsApiResponse>(json);

            if (result?.Articles == null)
                return new List<TechArticleModel>();

            return result.Articles.Select(a => new TechArticleModel
            {
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Url = a.Url,
                UrlToImage = a.Image,
                SourceName = a.Source?.Name,
                PublishedAt = a.PublishedAt
            }).ToList();
        }

        public async Task<List<TechArticleModel>> GetPoliticsNewsAsync()
        {
            using var client = new HttpClient();

            var url = $"https://gnews.io/api/v4/top-headlines?category=nation&lang=en&apikey={_apiKey}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TechArticleModel>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GNewsApiResponse>(json);

            if (result?.Articles == null)
                return new List<TechArticleModel>();

            return result.Articles.Select(a => new TechArticleModel
            {
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Url = a.Url,
                UrlToImage = a.Image,
                SourceName = a.Source?.Name,
                PublishedAt = a.PublishedAt
            }).ToList();
        }

        public async Task<List<TechArticleModel>> GetBuisnessNewsAsync()
        {
            using var client = new HttpClient();

            var url = $"https://gnews.io/api/v4/top-headlines?category=business&country=in&lang=en&apikey={_apiKey}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TechArticleModel>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GNewsApiResponse>(json);

            if (result?.Articles == null)
                return new List<TechArticleModel>();

            return result.Articles.Select(a => new TechArticleModel
            {
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Url = a.Url,
                UrlToImage = a.Image,
                SourceName = a.Source?.Name,
                PublishedAt = a.PublishedAt
            }).ToList();
        }
        public async Task<List<TechArticleModel>> GetHealthNewsAsync()
        {
            using var client = new HttpClient();

            var url = $"https://gnews.io/api/v4/top-headlines?q=health&country=in&lang=en&apikey={_apiKey}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TechArticleModel>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GNewsApiResponse>(json);

            if (result?.Articles == null)
                return new List<TechArticleModel>();

            return result.Articles.Select(a => new TechArticleModel
            {
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Url = a.Url,
                UrlToImage = a.Image,
                SourceName = a.Source?.Name,
                PublishedAt = a.PublishedAt
            }).ToList();
        }
        public async Task<List<TechArticleModel>> GetSportsNewsAsync()
        {
            using var client = new HttpClient();

            var url = $"https://gnews.io/api/v4/top-headlines?category=sports&lang=en&apikey={_apiKey}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TechArticleModel>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GNewsApiResponse>(json);

            if (result?.Articles == null)
                return new List<TechArticleModel>();

            return result.Articles.Select(a => new TechArticleModel
            {
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Url = a.Url,
                UrlToImage = a.Image,
                SourceName = a.Source?.Name,
                PublishedAt = a.PublishedAt
            }).ToList();
        }
        public async Task<List<TechArticleModel>> GetAstrologyNewsAsync()
        {
            using var client = new HttpClient();

            var url = $"https://gnews.io/api/v4/top-headlines?q=astrology&country=in&lang=en&apikey={_apiKey}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TechArticleModel>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GNewsApiResponse>(json);

            if (result?.Articles == null)
                return new List<TechArticleModel>();

            return result.Articles.Select(a => new TechArticleModel
            {
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Url = a.Url,
                UrlToImage = a.Image,
                SourceName = a.Source?.Name,
                PublishedAt = a.PublishedAt
            }).ToList();
        }
        public async Task<List<TechArticleModel>> GetGeneralNewsAsync()
        {
            using var client = new HttpClient();

            var url = $"https://gnews.io/api/v4/top-headlines?category=general&lang=en&apikey={_apiKey}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TechArticleModel>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GNewsApiResponse>(json);

            if (result?.Articles == null)
                return new List<TechArticleModel>();

            return result.Articles.Select(a => new TechArticleModel
            {
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Url = a.Url,
                UrlToImage = a.Image,
                SourceName = a.Source?.Name,
                PublishedAt = a.PublishedAt
            }).ToList();
        }

        public async Task<List<TechArticleModel>> GetInSportsNewsAsync()
        {
            using var client = new HttpClient();

            var url = $"https://gnews.io/api/v4/top-headlines?category=sports&country=in&lang=en&apikey={_apiKey}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TechArticleModel>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GNewsApiResponse>(json);

            if (result?.Articles == null)
                return new List<TechArticleModel>();

            return result.Articles.Select(a => new TechArticleModel
            {
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Url = a.Url,
                UrlToImage = a.Image,
                SourceName = a.Source?.Name,
                PublishedAt = a.PublishedAt
            }).ToList();
        }

        public async Task<List<TechArticleModel>> GetInBuisnessNewsAsync()
        {
            using var client = new HttpClient();

            var url = $"https://gnews.io/api/v4/top-headlines?q=business&country=in&lang=en&apikey={_apiKey}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TechArticleModel>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GNewsApiResponse>(json);

            if (result?.Articles == null)
                return new List<TechArticleModel>();

            return result.Articles.Select(a => new TechArticleModel
            {
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Url = a.Url,
                UrlToImage = a.Image,
                SourceName = a.Source?.Name,
                PublishedAt = a.PublishedAt
            }).ToList();
        }

        public async Task<List<TechArticleModel>> GetInEducationNewsAsync()
        {
            using var client = new HttpClient();

            var url = $"https://gnews.io/api/v4/top-headlines?q=education&country=in&lang=en&apikey={_apiKey}";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<TechArticleModel>();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GNewsApiResponse>(json);

            if (result?.Articles == null)
                return new List<TechArticleModel>();

            return result.Articles.Select(a => new TechArticleModel
            {
                Title = a.Title,
                Description = a.Description,
                Content = a.Content,
                Url = a.Url,
                UrlToImage = a.Image,
                SourceName = a.Source?.Name,
                PublishedAt = a.PublishedAt
            }).ToList();
        }
    }

}
