namespace PortfolioSite.ViewModels
{
    public class SkillsViewModel
    {
        // Bölüm başlığı (SiteSettings tablosundan)
        public string Label { get; set; } = "";
        public string TitleHtml { get; set; } = "";
        public string SideNote { get; set; } = "";

        // Satırlar (SkillCategories tablosundan)
        public List<SkillItemViewModel> Items { get; set; } = new();
    }

    public class SkillItemViewModel
    {
        public string Name { get; set; } = "";
        public string MainLine { get; set; } = "";
        public string Detail { get; set; } = "";
        public string Badge { get; set; } = "";
        public string? IconKey { get; set; }
    }
}