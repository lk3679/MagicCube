﻿using System.Web;
using System.Web.Optimization;

namespace EG_MagicCube
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/select2.full.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/font-awesome/font-awesome.min.css",
                      "~/Content/site.css", 
                      "~/Content/jquery.fileupload.css",
                      "~/Content/imageviewer.css",
                      "~/Content/select2.css"));

            bundles.Add(new ScriptBundle("~/bundles/lazyload").Include(
                      "~/Scripts/jquery.lazyload.js"));

            bundles.Add(new ScriptBundle("~/bundles/eslite").Include(
                      "~/Scripts/eslitemg.js"));
        }
    }
}
