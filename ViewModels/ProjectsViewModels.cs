using PortfolioSite.DAL.Entities;

namespace PortfolioSite.ViewModels
{
    public class ProjectsViewModel
    {
        // Bölüm başlığı (SiteSettings tablosundan)
        public string Label { get; set; } = "";
        public string DateRange { get; set; } = "";

        // Kartlar (Projects tablosundan)
        public List<ProjectItemViewModel> Items { get; set; } = new();
    }

    public class ProjectItemViewModel
    {
        public ProjectCardType CardType { get; set; }

        public string Title { get; set; } = "";
        public string Subtitle { get; set; } = "";
        public string Description { get; set; } = "";

        // "C#, .NET, Redis" metni parçalanıp liste olarak gelir
        public List<string> Technologies { get; set; } = new();

        public string CategoryLabel { get; set; } = "";
        public string FooterNote { get; set; } = "";
        public string? ImagePath { get; set; }

        public string PrimaryButtonText { get; set; } = "";
        public string? PrimaryButtonUrl { get; set; }
        public string SecondaryButtonText { get; set; } = "";
        public string? SecondaryButtonUrl { get; set; }

        public string? CodeFileName { get; set; }
        public string? CodeBadge { get; set; }
        public string? CodeSnippet { get; set; }
    }
}