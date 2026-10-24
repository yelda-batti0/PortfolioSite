using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.ViewModels
{
    public class SiteSettingEditViewModel
    {
        [Required(ErrorMessage = "Türkçe proje bölümü başlığı gerekli.")]
        [StringLength(100)]
        public string ProjectsLabelTr { get; set; } = "";
        [Required(ErrorMessage = "İngilizce proje bölümü başlığı gerekli.")]
        [StringLength(100)]
        public string ProjectsLabelEn { get; set; } = "";
        [StringLength(30)]
        public string ProjectsDateRange { get; set; } = "";

        [StringLength(100)] public string SkillsLabelTr { get; set; } = "";
        [StringLength(100)] public string SkillsLabelEn { get; set; } = "";
        [StringLength(150)] public string SkillsTitleTr { get; set; } = "";
        [StringLength(150)] public string SkillsTitleEn { get; set; } = "";
        [StringLength(100)] public string SkillsSideNoteTr { get; set; } = "";
        [StringLength(100)] public string SkillsSideNoteEn { get; set; } = "";

        public string? CvPath { get; set; }
        public IFormFile? CvFile { get; set; }
        public bool RemoveCv { get; set; }
    }
}
