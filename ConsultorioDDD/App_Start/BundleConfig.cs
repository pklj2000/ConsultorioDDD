using System.Web;
using System.Web.Optimization;

namespace ConsultorioDDD
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                        "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/sitecss").Include(
                        "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/momentjs").Include(
                         "~/Scripts/moment-with-locales.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepickerjs").Include(
                         "~/Scripts/bootstrap-datetimepicker.min.js"));

            bundles.Add(new StyleBundle("~/bundles/datepickercss").Include(
                     "~/Content/bootstrap-datetimepicker-build.less"));
        }
    }
}
