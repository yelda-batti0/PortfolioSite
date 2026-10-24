using PortfolioSite.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.ViewModels
{
    public class ProjectEditViewModel
    {
        public int ProjectId { get; set; }

        public ProjectCardType CardType { get; set; } = ProjectCardType.Standard;

        [Required(ErrorMessage = "Türkçe başlık gerekli.")]
        [StringLength(120)]
        public string TitleTr { get; set; } 
        [Required(ErrorMessage = "İngilizce başlık gerekli.")]
        [StringLength(120)]
        public string TitleEn { get; set; } 

        [StringLength(200)] public string SubtitleTr { get; set; } 
        [StringLength(200)] public string SubtitleEn { get; set; } 

        [Required(ErrorMessage = "Türkçe açıklama gerekli.")]
        [StringLength(1200)]
        public string DescriptionTr { get; set; } 
        [Required(ErrorMessage = "İngilizce açıklama gerekli.")]
        [StringLength(1200)]
        public string DescriptionEn { get; set; }

        [StringLength(300)] public string Technologies { get; set; } 

        [StringLength(80)] public string? CategoryLabelTr { get; set; }
        [StringLength(80)] public string? CategoryLabelEn { get; set; }
        [StringLength(120)] public string? FooterNoteTr { get; set; }
        [StringLength(120)] public string? FooterNoteEn { get; set; }

        [StringLength(60)] public string? PrimaryButtonTextTr { get; set; }
        [StringLength(60)] public string? PrimaryButtonTextEn { get; set; }
        [StringLength(500)] public string? PrimaryButtonUrl { get; set; }
        [StringLength(60)] public string? SecondaryButtonTextTr { get; set; }
        [StringLength(60)] public string? SecondaryButtonTextEn { get; set; }
        [StringLength(500)] public string? SecondaryButtonUrl { get; set; }

        [StringLength(100)] public string? CodeFileName { get; set; }
        [StringLength(40)] public string? CodeBadge { get; set; }
        [StringLength(3000)] public string? CodeSnippet { get; set; }

        // Mevcut görsel (formda önizleme) ve yeni yüklenecek dosya
        public string? ImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }
        public bool RemoveImage { get; set; }

        [Range(0, 1000)] public int SortOrder { get; set; }
        public bool IsPublished { get; set; } = true;
    }
}
