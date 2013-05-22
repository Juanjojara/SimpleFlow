using System.Web;

namespace SimpleFlow
{
    /// <summary>
    /// Summary description for downloadfile
    /// </summary>
    public class downloadfile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=Facebook analytics.xlsm");
            context.Response.WriteFile(System.Web.HttpContext.Current.Server.MapPath(@"\SimpleFlow\AppFiles\Facebook analytics.xlsm"));
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    //public class AverageHandler : IHttpHandler
    //{
    //    public bool IsReusable
    //    { get { return true; } }
    //    public void ProcessRequest(HttpContext context)
    //    {
    //        context.Response.Clear();
    //        context.Response.ContentType = "application/octet-stream";
    //        context.Response.AddHeader("Content-Disposition", "attachment; filename=sample1.xlsx");
    //        context.Response.WriteFile(System.Web.HttpContext.Current.Server.MapPath(@"\ValidatorTester\downloadfiles\sample1.xlsx"));
    //        context.Response.End();
    //    }
    //}
}