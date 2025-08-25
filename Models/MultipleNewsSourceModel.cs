namespace BugalDaily.Models
{
    public class MultipleNewsSourceModel
    {
        public List<TechArticleModel> articles { get; set; }
        public List<TechArticleModel> general { get; set; }
        public List<TechArticleModel> sports { get; set; }
        public List<TechArticleModel> buisness { get; set; }
        public List<TechArticleModel> education { get; set; }
    }
}
