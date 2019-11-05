using System.Web;
using System.Web.Optimization;

namespace SpeechConverter
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.4.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/mdb").Include(
                      "~/Scripts/mdb.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                      "~/Scripts/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                      "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/notification").Include(
                      "~/Scripts/notification.js"));

            bundles.Add(new ScriptBundle("~/bundles/loading").Include(
                      "~/Scripts/loadingoverlay.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                      "~/Scripts/datatables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable-select").Include(
                      "~/Scripts/dataTables.select.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                      "~/Scripts/toastr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable-bootstrap4").Include(
                      "~/Scripts/dataTables.bootstrap4.min.js"));
            //Responsive
            bundles.Add(new ScriptBundle("~/bundles/responsive-bootstrap").Include(
                      "~/Content/responsive.bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/responsive-bootstrap4").Include(
                      "~/Content/responsive.bootstrap4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/responsive-datatable").Include(
                      "~/Content/responsive.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/responsive-foundation").Include(
                      "~/Content/responsive.foundation.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/responsive-jquery-ui").Include(
                      "~/Content/responsive.jqueryui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/responsive-semanticui").Include(
                      "~/Content/responsive.semanticui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
                      "~/Content/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/validate").Include(
                      "~/Content/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive-ajax").Include(
                      "~/Content/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                      "~/Content/popper.min.js"));

            //Styles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/mdb").Include(
                      "~/Content/mdb.css"));

            bundles.Add(new StyleBundle("~/Content/mystyle").Include(
                      "~/Content/mystyle.css"));

            bundles.Add(new StyleBundle("~/Content/datatable").Include(
                      "~/Content/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Content/datatable-select").Include(
                      "~/Content/datatable-select.min.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-datatable").Include(
                      "~/Content/jquery.dataTables.min.css"));

            bundles.Add(new StyleBundle("~/Content/datatable-select").Include(
                      "~/Content/select.dataTables.min.css"));

            bundles.Add(new StyleBundle("~/Content/toastr").Include(
                      "~/Content/toastr.min.css"));
            bundles.Add(new StyleBundle("~/Content/datatable-bootstrap4").Include(
                      "~/Content/dataTables.bootstrap4.css"));

            bundles.Add(new StyleBundle("~/Content/responsive-bootstrap").Include(
                      "~/Content/responsive.bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/responsive-bootstrap4").Include(
                      "~/Content/responsive.bootstrap4.min.css"));

            bundles.Add(new StyleBundle("~/Content/responsive-datatable").Include(
                      "~/Content/responsive.dataTables.min.css"));

            bundles.Add(new StyleBundle("~/Content/responsive-foundation").Include(
                      "~/Content/responsive.foundation.min.css"));

            bundles.Add(new StyleBundle("~/Content/responsive-jquery-ui").Include(
                      "~/Content/responsive.jqueryui.min.css"));

            bundles.Add(new StyleBundle("~/Content/responsive-semanticui").Include(
                      "~/Content/responsive.semanticui.min.css"));
        }
    }
}
