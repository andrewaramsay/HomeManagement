using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtensions
    {

        public static MvcHtmlString Button(this HtmlHelper helper, string innerHtml, object htmlAttributes)
        {
            return Button(helper, innerHtml, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string innerHtml, IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button");
            builder.InnerHtml = innerHtml;
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }


        public static MvcHtmlString Script(this UrlHelper url, string scriptName)
        {

            var builder = new TagBuilder("script");
            builder.Attributes.Add("src", url.Content(string.Format("~/Scripts/{0}", scriptName)));
            builder.Attributes.Add("type", "text/javascript");
            return MvcHtmlString.Create(string.Format("{0}{1}", builder.ToString(TagRenderMode.StartTag), builder.ToString(TagRenderMode.EndTag)));
        }

        public static MvcHtmlString Css(this UrlHelper url, string cssName)
        {
            var builder = new TagBuilder("link");
            builder.Attributes.Add("href", url.Content(string.Format("~/Content/{0}", cssName)));
            builder.Attributes.Add("rel", "stylesheet");
            builder.Attributes.Add("type", "text/css");
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));

        }

        public static MvcHtmlString CssTheme(this UrlHelper url, string cssName, string themeName = "base")
        {
            return url.Css(string.Format("themes/{0}/{1}", themeName, cssName));
        }
    }
}