using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.ViewModels
{
    public class HeroEditViewModel
    {
        [Required(ErrorMessage = "Türkçe başlık gerekli.")]
        [StringLength(300)]
        public string HeadlineTr { get; set; } 

        [Required(ErrorMessage = "İngilizce başlık gerekli.")]
        [StringLength(300)]
        public string HeadlineEn { get; set; } 

        [Required(ErrorMessage = "Türkçe açıklama gerekli.")]
        [StringLength(600)]
        public string SubtitleTr { get; set; } 

        [Required(ErrorMessage = "İngilizce açıklama gerekli.")]
        [StringLength(600)]
        public string SubtitleEn { get; set; } 

        [Required(ErrorMessage = "Türkçe buton yazısı gerekli.")]
        [StringLength(80)]
        public string ButtonTextTr { get; set; } 

        [Required(ErrorMessage = "İngilizce buton yazısı gerekli.")]
        [StringLength(80)]
        public string ButtonTextEn { get; set; } 
    }
}
