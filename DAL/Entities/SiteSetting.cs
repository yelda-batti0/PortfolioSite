namespace PortfolioSite.DAL.Entities
{
    public class SiteSetting
    {
        public int SiteSettingId { get; set; }

        public string SiteName { get; set; } = "";
        public string? LogoPath { get; set; }
        public string ProjectsLabelTr { get; set; } = "";
        public string ProjectsLabelEn { get; set; } = "";
        public string ProjectsDateRange { get; set; } = "";
        public string SkillsLabelTr { get; set; } = "";
        public string SkillsLabelEn { get; set; } = "";
        public string SkillsTitleTr { get; set; } = "";
        public string SkillsTitleEn { get; set; } = "";
        public string SkillsSideNoteTr { get; set; } = "";
        public string SkillsSideNoteEn { get; set; } = "";
        public string? CvPath { get; set; }
    }
} 

