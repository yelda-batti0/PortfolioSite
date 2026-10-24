namespace PortfolioSite.ViewModels
{
    public class AboutViewModel
    {
        public string HeaderLabel { get; set; } = "";
        public string Title { get; set; } = "";

        public string? CvPath { get; set; }

        // Boş satırla ayrılmış metin, paragraflara bölünmüş hali
        public List<string> Paragraphs { get; set; } = new();

        public string TenetsTitle { get; set; } = "";

        // Her satır bir madde
        public List<string> Tenets { get; set; } = new();

        public string FooterNote { get; set; } = "";

        // SocialMedias tablosundan
        public List<SocialLinkViewModel> SocialLinks { get; set; } = new();
    }
}
