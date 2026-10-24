using Microsoft.EntityFrameworkCore;
using PortfolioSite.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PortfolioSite.DAL.Context
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactTopic> ContactTopics { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
    }
}
