using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

public static class HtmlExtensions
{
    public static IHtmlString Code(this HtmlHelper htmlHelper, string code)
    {
        int num = 0;
        string[] lines = code.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        if (lines.Length > 1)
        {
            num = lines
                .Skip(1)
                .Min(x =>
                {
                    int index = x.ToList().FindIndex(c => c != ' ');
                    return index == -1 ? Int32.MaxValue : index;
                });
        }
        string spaces = new String(' ', num);
        code = code
            .Replace("Bootstrap(this)", "Bootstrap()")
            .Replace(Environment.NewLine + spaces, Environment.NewLine);
        return new HtmlString(string.Format(@"<pre class='prettyprint'>{0}</pre>", htmlHelper.Raw(HttpUtility.HtmlEncode(code))));
    }
}

