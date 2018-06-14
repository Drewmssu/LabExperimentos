using System.Web;
using System.Web.Optimization;
using System.Configuration;

namespace DemoExperimentos
{
    public static class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(ConfigurationManager.AppSettings["bundles-jquery"]).Include(
                        ConfigurationManager.AppSettings["scripts-jquery"]));

            bundles.Add(new ScriptBundle(ConfigurationManager.AppSettings["bundles-jqueryval"]).Include(
                        ConfigurationManager.AppSettings["jquery-validate"]));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle(ConfigurationManager.AppSettings["jquery-moder"]).Include(
                        ConfigurationManager.AppSettings["moder-scripts"]));

            bundles.Add(new ScriptBundle(ConfigurationManager.AppSettings["bundles-bootstrap"]).Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle(ConfigurationManager.AppSettings["content-css"]).Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
