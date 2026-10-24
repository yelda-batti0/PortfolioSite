namespace PortfolioSite.DAL.Entities
{
    public class Hero
    {
        public int HeroId { get; set; }

        // Büyük başlık. İşaretleme: ==vurgu==  *italik*  ✦ (yıldız)
        public string HeadlineTr { get; set; } 
        public string HeadlineEn { get; set; } 

        // Başlığın altındaki açıklama paragrafı
        public string SubtitleTr { get; set; } 
        public string SubtitleEn { get; set; } 

        // Alttaki çerçeveli buton yazısı ("Selected Systems & Research")
        public string ButtonTextTr { get; set; } 
        public string ButtonTextEn { get; set; } 
    }
}
