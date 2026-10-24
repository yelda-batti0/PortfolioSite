using System.Net;
using System.Text.RegularExpressions;

namespace PortfolioSite.Helpers
{
    public static class MarkupHelper
    {
        private const string Star =
            "<span class=\"animated-star-sparkle mx-1 sm:mx-2 align-middle select-none\">" +
            "<svg class=\"w-6 h-6 sm:w-8 sm:h-8 text-neutral-900 drop-shadow-sm transition-transform hover:rotate-45 duration-300\" " +
            "fill=\"none\" stroke=\"currentColor\" stroke-linecap=\"round\" stroke-linejoin=\"round\" stroke-width=\"1.5\" viewBox=\"0 0 24 24\">" +
            "<polygon fill=\"#F5BE24\" fill-opacity=\"0.4\" points=\"12 2 15 9 22 12 15 15 12 22 9 15 2 12 9 9\"></polygon>" +
            "<circle cx=\"12\" cy=\"12\" fill=\"#111111\" r=\"2\"></circle></svg></span>";

        public static string ToHtml(string? text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";

           
            var html = WebUtility.HtmlEncode(text);

        
            html = Regex.Replace(html, @"==(.+?)==",
                "<span class=\"inline-block my-1\"><span class=\"text-highlight font-normal\">$1</span></span>");

            html = Regex.Replace(html, @"\*(.+?)\*",
                "<span class=\"italic font-light\">$1</span>");

            // ✦  → animasyonlu yıldız
            html = html.Replace("✦", Star);

            return html;
        }
    }
}