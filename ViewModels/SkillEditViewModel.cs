using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.ViewModels
{
    public class SkillEditViewModel
    {
        public int SkillId { get; set; }

        [Required(ErrorMessage = "Türkçe kategori adı gerekli.")]
        [StringLength(100)]
        public string NameTr { get; set; } 

        [Required(ErrorMessage = "İngilizce kategori adı gerekli.")]
        [StringLength(100)]
        public string NameEn { get; set; } 

        [Required(ErrorMessage = "Türkçe ana satır gerekli.")]
        [StringLength(200)]
        public string MainLineTr { get; set; } 

        [Required(ErrorMessage = "İngilizce ana satır gerekli.")]
        [StringLength(200)]
        public string MainLineEn { get; set; } 

        [StringLength(300)]
        public string DetailTr { get; set; } 

        [StringLength(300)]
        public string DetailEn { get; set; } 

        [StringLength(60)]
        public string BadgeTr { get; set; } 

        [StringLength(60)]
        public string BadgeEn { get; set; } 

        public string? IconKey { get; set; }

        [Range(0, 1000, ErrorMessage = "Sıra 0 ile 1000 arasında olmalı.")]
        public int SortOrder { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
