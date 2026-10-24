namespace PortfolioSite.DAL.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        public ProjectCardType CardType { get; set; } = ProjectCardType.Standard;

        public string TitleTr { get; set; } 
        public string TitleEn { get; set; } 
        public string SubtitleTr { get; set; } 
        public string SubtitleEn { get; set; } 
        public string DescriptionTr { get; set; } 
        public string DescriptionEn { get; set; } 

       
        public string Technologies { get; set; } 

     
        public string? CategoryLabelTr { get; set; }
        public string? CategoryLabelEn { get; set; }

      
        public string? FooterNoteTr { get; set; }
        public string? FooterNoteEn { get; set; }

        
        public string? ImagePath { get; set; }

       
        public string? PrimaryButtonTextTr { get; set; }
        public string? PrimaryButtonTextEn { get; set; }
        public string? PrimaryButtonUrl { get; set; }

       
        public string? SecondaryButtonTextTr { get; set; }
        public string? SecondaryButtonTextEn { get; set; }
        public string? SecondaryButtonUrl { get; set; }

      
        public string? CodeFileName { get; set; }   
        public string? CodeBadge { get; set; }      
        public string? CodeSnippet { get; set; }

        public int SortOrder { get; set; }
        public bool IsPublished { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
