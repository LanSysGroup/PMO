using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LanSysWebGIS.Web
{
    /// <summary>
    /// Summary description for WebMethodsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebMethodsService : System.Web.Services.WebService
    {
        [WebMethod]
        public string DeleteFile(string path)
        {
            if (File.Exists(path) == true)
            {
                File.Delete(path);
            }

            return "";
        }

        [WebMethod]
        public DateTime GetDate()
        {
            return DateTime.Now;
        }

        [WebMethod]
        public void AccessFile(string path)
        {
            HttpContext.Current.Response.Redirect(path, false);
        }
    }
}
