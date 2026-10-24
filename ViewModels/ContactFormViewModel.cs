using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.ViewModels
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "Val_NameRequired")]
        [StringLength(100, ErrorMessage = "Val_NameLength")]
        public string FullName { get; set; } = "";

        [Required(ErrorMessage = "Val_EmailRequired")]
        [EmailAddress(ErrorMessage = "Val_EmailInvalid")]
        [StringLength(150, ErrorMessage = "Val_EmailLength")]
        public string EmailAddress { get; set; } = "";

        [StringLength(150)]
        public string? SubjectTopic { get; set; }

        [Required(ErrorMessage = "Val_MessageRequired")]
        [StringLength(3000, MinimumLength = 10, ErrorMessage = "Val_MessageLength")]
        public string MessageBody { get; set; } = "";

        public string? Website { get; set; }
    }
}
