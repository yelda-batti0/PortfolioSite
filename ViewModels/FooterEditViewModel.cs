using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.ViewModels
{
    public class FooterEditViewModel
    {
        [Required(ErrorMessage = "Türkçe kapanış cümlesi gerekli.")]
        [StringLength(300)]
        public string ClosingStatementTr { get; set; } = "";
        [Required(ErrorMessage = "İngilizce kapanış cümlesi gerekli.")]
        [StringLength(300)]
        public string ClosingStatementEn { get; set; } = "";

        [StringLength(150)] public string AvailabilityTextTr { get; set; } = "";
        [StringLength(150)] public string AvailabilityTextEn { get; set; } = "";
        public bool IsAvailable { get; set; } = true;

        [Required(ErrorMessage = "Türkçe başlık gerekli.")]
        [StringLength(100)]
        public string TitleTr { get; set; } = "";
        [Required(ErrorMessage = "İngilizce başlık gerekli.")]
        [StringLength(100)]
        public string TitleEn { get; set; } = "";

        [StringLength(500)] public string DescriptionTr { get; set; } = "";
        [StringLength(500)] public string DescriptionEn { get; set; } = "";

        [StringLength(500)] public string? ColophonTextTr { get; set; }
        [StringLength(500)] public string? ColophonTextEn { get; set; }
        [StringLength(200)] public string? ColophonNoteTr { get; set; }
        [StringLength(200)] public string? ColophonNoteEn { get; set; }

        [StringLength(200)] public string CopyrightTextTr { get; set; } = "";
        [StringLength(200)] public string CopyrightTextEn { get; set; } = "";
        [StringLength(100)] public string LocationText { get; set; } = "";
    }
}
