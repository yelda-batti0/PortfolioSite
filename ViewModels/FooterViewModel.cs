namespace PortfolioSite.ViewModels
{
    public class FooterViewModel
    {
        // Büyük kapanış cümlesi
        public string ClosingStatementHtml { get; set; } = "";

        // Müsaitlik rozeti
        public string AvailabilityText { get; set; } = "";
        public bool IsAvailable { get; set; }

        // Sol sütun
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";

        // Colophon (boşsa gizlenir)
        public string ColophonText { get; set; } = "";
        public string ColophonNote { get; set; } = "";

        // Alt çubuk
        public string CopyrightText { get; set; } = "";
        public string LocationText { get; set; } = "";

        // Contact tablosundan
        public string Email { get; set; } = "";

        // SocialMedias tablosundan
        public List<SocialLinkViewModel> SocialLinks { get; set; } = new();
    }

    public class SocialLinkViewModel
    {
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
    }
}