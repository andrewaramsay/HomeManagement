using System.Web;
using System.Web.Optimization;

namespace HomeManagementMobile
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;
            var jqueryCdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.min.js";
            var jqueryUiCdnPath = "http://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.3/jquery-ui.min.js";
            var jqueryUiCssCdnPath = "http://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.3/themes/excite-bike/jquery-ui.css";
            var jqueryMobileCdnPath = "http://ajax.aspnetcdn.com/ajax/jquery.mobile/1.3.2/jquery.mobile-1.3.2.min.js";
            var jqueryMobileCssCdnPath = "http://ajax.aspnetcdn.com/ajax/jquery.mobile/1.3.2/jquery.mobile-1.3.2.min.css";

            bundles.Add(new ScriptBundle("~/bundles/jquery", jqueryCdnPath).Include(
                        "~/Scripts/jquery-1.*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui", jqueryUiCdnPath).Include(
                        "~/Scripts/jquery-ui*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquerymobile", jqueryMobileCdnPath).Include("~/Scripts/jquery.mobile*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/mobilecss", jqueryMobileCssCdnPath).Include("~/Content/jquery.mobile*"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css", jqueryUiCssCdnPath).Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}