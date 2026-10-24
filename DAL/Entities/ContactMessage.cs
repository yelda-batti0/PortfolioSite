namespace PortfolioSite.DAL.Entities
{
    public class ContactMessage
    {
        public int ContactMessageId { get; set; }
        public string FullName { get; set; } 
        public string Email { get; set; } 
        public string Topic { get; set; } 
        public string Message { get; set; } 
        public string Language { get; set; } = "tr";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
    }
}
