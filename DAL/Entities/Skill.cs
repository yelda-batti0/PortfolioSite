namespace PortfolioSite.DAL.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }

      
        public string NameTr { get; set; } 
        public string NameEn { get; set; } 
        public string MainLineTr { get; set; } 
        public string MainLineEn { get; set; } 
        public string DetailTr { get; set; } 
        public string DetailEn { get; set; } 
        public string BadgeTr { get; set; } 
        public string BadgeEn { get; set; } 
        public string? IconKey { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
