namespace PortfolioSite.DAL.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string HeaderLabelTr { get; set; }
        public string HeaderLabelEn { get; set; }
        public string TitleTr { get; set; }
        public string TitleEn { get; set; }
        public string TitleAccentTr { get; set; }
        public string TitleAccentEn { get; set; }
        public string DescriptionTr { get; set; }
        public string DescriptionEn { get; set; }
        public string ResponseNotTr { get; set; }
        public string ResponseNotEn { get; set; }
        public string Email { get; set; }
    }
}
