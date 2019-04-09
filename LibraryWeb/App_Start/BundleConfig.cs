using System.Web;
using System.Web.Optimization;

namespace LibraryWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/base").Include(
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery-validation.min.js",
                        "~/Scripts/moment.min.js",
                        "~/Scripts/daterangepicker.js",
                        "~/Scripts/jquery.autocomplete.min.js",
                        "~/Scripts/pnotify.custom.min.js",
                        "~/Scripts/datatables.min.js",
                        "~/Scripts/dataTables.bootstrap.min.js",
                        "~/Scripts/bootstrap-editable.min.js",
                        "~/Scripts/custom.min.js"
                        ));



            bundles.Add(new StyleBundle("~/Content/base").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome/css/font-awesome.min.css",
                      "~/Content/dataTables.bootstrap.min.css",
                      "~/Content/daterangepicker.css",
                      "~/Content/pnotify.custom.min.css",
                      "~/Content/bootstrap-editable.css",
                      "~/Content/custom.min.css"));
        }
    }
}
