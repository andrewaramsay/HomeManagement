﻿using System.Web;
using System.Web.Optimization;

namespace HomeManagement.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                .Include("~/Scripts/jquery-ui-{version}.js")
                .Include("~/Scripts/jquery-ui-timepicker-addon.js")
                .Include("~/Scripts/extend-jquery-ui-theme.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery.unobtrusive*")
                .Include("~/Scripts/jquery.validate*")
                );

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*")
                );

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css")
                );

            bundles.Add(new StyleBundle("~/Content/themes/base/css")
                //.Include("~/Content/themes/base/jquery.ui.core.css")
                //.Include("~/Content/themes/base/jquery.ui.resizable.css")
                //.Include("~/Content/themes/base/jquery.ui.selectable.css")
                //.Include("~/Content/themes/base/jquery.ui.accordion.css")
                //.Include("~/Content/themes/base/jquery.ui.autocomplete.css")
                //.Include("~/Content/themes/base/jquery.ui.button.css")
                //.Include("~/Content/themes/base/jquery.ui.dialog.css")
                //.Include("~/Content/themes/base/jquery.ui.slider.css")
                //.Include("~/Content/themes/base/jquery.ui.tabs.css")
                //.Include("~/Content/themes/base/jquery.ui.datepicker.css")
                //.Include("~/Content/themes/base/jquery.ui.progressbar.css")
                //.Include("~/Content/themes/base/jquery.ui.theme.css")
                .Include("~/Content/themes/dot-luv/jquery-ui-1.10.3.custom.css")
                .Include("~/Content/themes/base/jquery-ui-timepicker-addon.css")
                );
        }
    }
}