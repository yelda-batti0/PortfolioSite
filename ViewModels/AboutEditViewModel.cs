using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.ViewModels
{
    public class AboutEditViewModel
    {
        [Required(ErrorMessage = "Türkçe panel etiketi gerekli.")]
        [StringLength(120)]
        public string HeaderLabelTr { get; set; } 

        [Required(ErrorMessage = "İngilizce panel etiketi gerekli.")]
        [StringLength(120)]
        public string HeaderLabelEn { get; set; } 

        [Required(ErrorMessage = "Türkçe başlık gerekli.")]
        [StringLength(300)]
        public string TitleTr { get; set; } 

        [Required(ErrorMessage = "İngilizce başlık gerekli.")]
        [StringLength(300)]
        public string TitleEn { get; set; } 

        [Required(ErrorMessage = "Türkçe metin gerekli.")]
        [StringLength(4000)]
        public string BodyTr { get; set; } 

        [Required(ErrorMessage = "İngilizce metin gerekli.")]
        [StringLength(4000)]
        public string BodyEn { get; set; } 

        [StringLength(120)]
        public string TenetsTitleTr { get; set; } 

        [StringLength(120)]
        public string TenetsTitleEn { get; set; } 

        [StringLength(1500)]
        public string TenetsTr { get; set; } 

        [StringLength(1500)]
        public string TenetsEn { get; set; } 

        [StringLength(200)]
        public string FooterNoteTr { get; set; } 

        [StringLength(200)]
        public string FooterNoteEn { get; set; } 
    }
}
