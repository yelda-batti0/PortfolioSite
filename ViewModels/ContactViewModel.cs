namespace PortfolioSite.ViewModels
{
    public class ContactViewModel
    {
        public string HeaderLabel { get; set; } 
        public string Title { get; set; } 
        public string TitleAccent { get; set; } 
        public string Description { get; set; } 
        public string ResponseNote { get; set; } 
        public string Email { get; set; } 

        // ContactTopics tablosundan, açılır liste için
        public List<string> Topics { get; set; } = new();
    }
}
