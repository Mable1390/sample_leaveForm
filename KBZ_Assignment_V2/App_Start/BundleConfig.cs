using System.Web;
using System.Web.Optimization;

namespace KBZ_Assignment_V2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css", 
                      "~/Content/fullcalendar.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
              "~/Scripts/knockout-3.4.2.js",
              "~/Scripts/app.js"));   
            bundles.Add(new ScriptBundle("~/bundles/emp").Include(
              "~/Scripts/knockout-3.4.2.js",
              "~/Scripts/emp.js"));
            bundles.Add(new ScriptBundle("~/bundles/holiday").Include(
              "~/Scripts/knockout-3.4.2.js",
              "~/Scripts/holiday.js"));
            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
              "~/Scripts/jquery-3.3.1.min.js",
              "~/Scripts/moment.min.js",             
              "~/Scripts/fullcalendar.js"));
        }
    }
}
