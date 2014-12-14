using System;
using System.Text;
using System.Web.Mvc;
using HallOfFame_dotnet.Models;

namespace HallOfFame_dotnet.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder link = new TagBuilder("a");
                link.MergeAttribute("href", pageUrl(i));
                link.InnerHtml = i.ToString();
                
                TagBuilder li = new TagBuilder("li") {InnerHtml = link.ToString()};
                
                if (i == pageInfo.PageNumber)
                {
                    li.AddCssClass("active");
                }

                result.Append(li);
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}