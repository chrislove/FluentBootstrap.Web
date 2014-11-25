using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

public static class HtmlExtensions
{
    public static IHtmlString Code(this HtmlHelper htmlHelper, string code, string language = "csharp")
    {
        return new HtmlString(string.Format(@"<pre><code class=""language-{0}"">{1}</code></pre>", language, 
            htmlHelper.Raw(HttpUtility.HtmlEncode(code.Replace("Bootstrap(this)", "Bootstrap()")))));
    }
}


