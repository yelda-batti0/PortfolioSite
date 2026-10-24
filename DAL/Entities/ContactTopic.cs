namespace PortfolioSite.DAL.Entities
{
    public class ContactTopic
    {
        public int ContactTopicId { get; set; }
        public string NameTr { get; set; } 
        public string NameEn { get; set; } 
        public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
