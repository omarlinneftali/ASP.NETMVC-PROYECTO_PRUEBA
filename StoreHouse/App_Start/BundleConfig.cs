using System.Web;
using System.Web.Optimization;

namespace StoreHouse
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/modernizr-*",
                        "~/Scripts/DataTables/media/js/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/media/js/jquery.dataTables.bootstrap.min.js",
                        "~/Scripts/jquery.validate*"

                        ));

            

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",

                      "~/Content/site.css",

                      "~/Content/DataTables/media/css/jquery.dataTables.min.css"
                      ));
        }
    }
}
