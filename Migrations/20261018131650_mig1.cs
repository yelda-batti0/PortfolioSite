using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSite.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TitleTr = table.Column<string>(type: "TEXT", nullable: false),
                    TitleEn = table.Column<string>(type: "TEXT", nullable: false),
                    HeaderLabelTr = table.Column<string>(type: "TEXT", nullable: false),
                    HeaderLabelEn = table.Column<string>(type: "TEXT", nullable: false),
                    BodyTr = table.Column<string>(type: "TEXT", nullable: false),
                    BodyEn = table.Column<string>(type: "TEXT", nullable: false),
                    TenetsTitleTr = table.Column<string>(type: "TEXT", nullable: false),
                    TenetsTitleEn = table.Column<string>(type: "TEXT", nullable: false),
                    TenetsTr = table.Column<string>(type: "TEXT", nullable: false),
                    TenetsEn = table.Column<string>(type: "TEXT", nullable: false),
                    FooterNoteTr = table.Column<string>(type: "TEXT", nullable: false),
                    FooterNoteEn = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutId);
                });

            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    ContactMessageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Topic = table.Column<string>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.ContactMessageId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HeaderLabelTr = table.Column<string>(type: "TEXT", nullable: false),
                    HeaderLabelEn = table.Column<string>(type: "TEXT", nullable: false),
                    TitleTr = table.Column<string>(type: "TEXT", nullable: false),
                    TitleEn = table.Column<string>(type: "TEXT", nullable: false),
                    TitleAccentTr = table.Column<string>(type: "TEXT", nullable: false),
                    TitleAccentEn = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionTr = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionEn = table.Column<string>(type: "TEXT", nullable: false),
                    ResponseNotTr = table.Column<string>(type: "TEXT", nullable: false),
                    ResponseNotEn = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "ContactTopics",
                columns: table => new
                {
                    ContactTopicId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameTr = table.Column<string>(type: "TEXT", nullable: false),
                    NameEn = table.Column<string>(type: "TEXT", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTopics", x => x.ContactTopicId);
                });

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    FooterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClosingStatementTr = table.Column<string>(type: "TEXT", nullable: false),
                    ClosingStatementEn = table.Column<string>(type: "TEXT", nullable: false),
                    AvailabilityTextTr = table.Column<string>(type: "TEXT", nullable: false),
                    AvailabilityTextEn = table.Column<string>(type: "TEXT", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    TitleTr = table.Column<string>(type: "TEXT", nullable: false),
                    TitleEn = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionTr = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionEn = table.Column<string>(type: "TEXT", nullable: false),
                    ColophonTextTr = table.Column<string>(type: "TEXT", nullable: true),
                    ColophonTextEn = table.Column<string>(type: "TEXT", nullable: true),
                    ColophonNoteTr = table.Column<string>(type: "TEXT", nullable: true),
                    ColophonNoteEn = table.Column<string>(type: "TEXT", nullable: true),
                    CopyrightTextTr = table.Column<string>(type: "TEXT", nullable: false),
                    CopyrightTextEn = table.Column<string>(type: "TEXT", nullable: false),
                    LocationText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.FooterId);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    HeroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HeadlineTr = table.Column<string>(type: "TEXT", nullable: false),
                    HeadlineEn = table.Column<string>(type: "TEXT", nullable: false),
                    SubtitleTr = table.Column<string>(type: "TEXT", nullable: false),
                    SubtitleEn = table.Column<string>(type: "TEXT", nullable: false),
                    ButtonTextTr = table.Column<string>(type: "TEXT", nullable: false),
                    ButtonTextEn = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.HeroId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardType = table.Column<int>(type: "INTEGER", nullable: false),
                    TitleTr = table.Column<string>(type: "TEXT", nullable: false),
                    TitleEn = table.Column<string>(type: "TEXT", nullable: false),
                    SubtitleTr = table.Column<string>(type: "TEXT", nullable: false),
                    SubtitleEn = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionTr = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionEn = table.Column<string>(type: "TEXT", nullable: false),
                    Technologies = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryLabelTr = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryLabelEn = table.Column<string>(type: "TEXT", nullable: true),
                    FooterNoteTr = table.Column<string>(type: "TEXT", nullable: true),
                    FooterNoteEn = table.Column<string>(type: "TEXT", nullable: true),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryButtonTextTr = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryButtonTextEn = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryButtonUrl = table.Column<string>(type: "TEXT", nullable: true),
                    SecondaryButtonTextTr = table.Column<string>(type: "TEXT", nullable: true),
                    SecondaryButtonTextEn = table.Column<string>(type: "TEXT", nullable: true),
                    SecondaryButtonUrl = table.Column<string>(type: "TEXT", nullable: true),
                    CodeFileName = table.Column<string>(type: "TEXT", nullable: true),
                    CodeBadge = table.Column<string>(type: "TEXT", nullable: true),
                    CodeSnippet = table.Column<string>(type: "TEXT", nullable: true),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPublished = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    SiteSettingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiteName = table.Column<string>(type: "TEXT", nullable: false),
                    LogoPath = table.Column<string>(type: "TEXT", nullable: true),
                    ProjectsLabelTr = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectsLabelEn = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectsDateRange = table.Column<string>(type: "TEXT", nullable: false),
                    SkillsLabelTr = table.Column<string>(type: "TEXT", nullable: false),
                    SkillsLabelEn = table.Column<string>(type: "TEXT", nullable: false),
                    SkillsTitleTr = table.Column<string>(type: "TEXT", nullable: false),
                    SkillsTitleEn = table.Column<string>(type: "TEXT", nullable: false),
                    SkillsSideNoteTr = table.Column<string>(type: "TEXT", nullable: false),
                    SkillsSideNoteEn = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.SiteSettingId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameTr = table.Column<string>(type: "TEXT", nullable: false),
                    NameEn = table.Column<string>(type: "TEXT", nullable: false),
                    MainLineTr = table.Column<string>(type: "TEXT", nullable: false),
                    MainLineEn = table.Column<string>(type: "TEXT", nullable: false),
                    DetailTr = table.Column<string>(type: "TEXT", nullable: false),
                    DetailEn = table.Column<string>(type: "TEXT", nullable: false),
                    BadgeTr = table.Column<string>(type: "TEXT", nullable: false),
                    BadgeEn = table.Column<string>(type: "TEXT", nullable: false),
                    IconKey = table.Column<string>(type: "TEXT", nullable: true),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    SocialMediaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.SocialMediaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ContactTopics");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SocialMedias");
        }
    }
}
