namespace PortfolioSite.DAL.Entities
{
    public class Footer
    {
        public int FooterId { get; set; }

        public string ClosingStatementTr { get; set; } 
        public string ClosingStatementEn { get; set; } 

        public string AvailabilityTextTr { get; set; } 
        public string AvailabilityTextEn { get; set; } 
        public bool IsAvailable { get; set; } = true;
        public string TitleTr { get; set; } = "";
        public string TitleEn { get; set; } = "";
        public string DescriptionTr { get; set; } = "";
        public string DescriptionEn { get; set; } = "";
        public string? ColophonTextTr { get; set; }
        public string? ColophonTextEn { get; set; }
        public string? ColophonNoteTr { get; set; }
        public string? ColophonNoteEn { get; set; }
        public string CopyrightTextTr { get; set; } = "";
        public string CopyrightTextEn { get; set; } = "";
        public string LocationText { get; set; } = "";
    }
}
