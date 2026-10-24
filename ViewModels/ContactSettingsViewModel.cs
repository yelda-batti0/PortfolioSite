using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.ViewModels
{
    public class ContactSettingsViewModel
    {
        [Required(ErrorMessage = "Türkçe üst etiket gerekli.")]
        [StringLength(100)]
        public string HeaderLabelTr { get; set; } = "";
        [Required(ErrorMessage = "İngilizce üst etiket gerekli.")]
        [StringLength(100)]
        public string HeaderLabelEn { get; set; } = "";

        [Required(ErrorMessage = "Türkçe başlık gerekli.")]
        [StringLength(150)]
        public string TitleTr { get; set; } = "";
        [Required(ErrorMessage = "İngilizce başlık gerekli.")]
        [StringLength(150)]
        public string TitleEn { get; set; } = "";

        [Required(ErrorMessage = "Türkçe vurgulu kısım gerekli.")]
        [StringLength(100)]
        public string TitleAccentTr { get; set; } = "";
        [Required(ErrorMessage = "İngilizce vurgulu kısım gerekli.")]
        [StringLength(100)]
        public string TitleAccentEn { get; set; } = "";

        [Required(ErrorMessage = "Türkçe açıklama gerekli.")]
        [StringLength(600)]
        public string DescriptionTr { get; set; } = "";
        [Required(ErrorMessage = "İngilizce açıklama gerekli.")]
        [StringLength(600)]
        public string DescriptionEn { get; set; } = "";

        [StringLength(100)] public string ResponseNotTr { get; set; } = "";
        [StringLength(100)] public string ResponseNotEn { get; set; } = "";

        [Required(ErrorMessage = "E-posta gerekli.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta yazın.")]
        [StringLength(150)]
        public string Email { get; set; } = "";
    }

    public class TopicEditViewModel
    {
        public int ContactTopicId { get; set; }

        [Required(ErrorMessage = "Türkçe ad gerekli.")]
        [StringLength(150)]
        public string NameTr { get; set; } = "";
        [Required(ErrorMessage = "İngilizce ad gerekli.")]
        [StringLength(150)]
        public string NameEn { get; set; } = "";

        [Range(0, 1000)] public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
