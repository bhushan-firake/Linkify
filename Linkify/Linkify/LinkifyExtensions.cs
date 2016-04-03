using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Linkify
{
    public static class LinkifyExtensions
    {
        public static string Linkify(this string str, LinkifyConfig config = null)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            if (config == null)
                config = new LinkifyConfig
            {
                Target = "blank",
                ClassName = string.Empty,
                Rel = string.Empty
            };

            string target = string.IsNullOrEmpty(config.Target)
                ? string.Empty
                : string.Format("target='_{0}'", config.Target);

            string className = string.IsNullOrEmpty(config.ClassName)
               ? string.Empty
               : string.Format("class='{0}'", config.ClassName);

            string rel = string.IsNullOrEmpty(config.Rel)
               ? string.Empty
               : string.Format("rel='{0}'", config.Rel);

            string prependedText = string.IsNullOrEmpty(config.UrlPrependedText)
                ? string.Empty
                : config.UrlPrependedText;

            string appendedText = string.IsNullOrEmpty(config.UrlAppendedText)
               ? string.Empty
               : config.UrlAppendedText;

            str = Regex.Replace(str, @"(https\:\/\/|http:\/\/)([www\.]?)([^\s|<]+)", string.Format("<a href='{0}$1$2$3{1}' {2} {3} {4}>$1$2$3</a>", prependedText, appendedText, target, className, rel));
            str = Regex.Replace(str, @"([^https\:\/\/]|[^http:\/\/]|^)(www)\.([^\s|<]+)", string.Format("$1<a href='{0}http://$2.$3{1}' {2} {3} {4}>$2.$3</a>", prependedText, appendedText, target, className, rel));
            str = Regex.Replace(str, @"<([^a]|^\/a])([^<>]+)>", "&lt;$1$2&gt;");
            str = Regex.Replace(str, @"&lt;\/a&gt;", "</a>");
            str = Regex.Replace(str, "<(.)>", "&lt;$1&gt;");

            if (config.ReplaceNewLineWithBr)
                str = Regex.Replace(str, "\n", "<br />");
            return str;
        }
    }
}
