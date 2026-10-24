using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.ViewModels
{
    public class SocialEditViewModel
    {
        public int SocialMediaId { get; set; }

        [Required(ErrorMessage = "Ad gerekli.")]
        [StringLength(60)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Link gerekli.")]
        [StringLength(500)]
        public string Url { get; set; } 

        [Range(0, 1000, ErrorMessage = "Sıra 0 ile 1000 arasında olmalı.")]
        public int SortOrder { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
