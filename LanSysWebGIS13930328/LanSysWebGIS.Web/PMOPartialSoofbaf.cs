using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.DomainServices.EntityFramework;
using System.ServiceModel.DomainServices.Server;
using System.Web;

namespace LanSysWebGIS.Web
{
    public partial class PMOService
    {
        [Invoke]
        public int GetTblUsersMaxId()
        {
            return this.ObjectContext.tblUsers.Max(i => i.UsersID);
        }
        
        [Invoke]
        public void ChangePmoPassword(int userId, string newPassword)
        {
            PMOManageEntities pmoManageEntities = new PMOManageEntities();

            var singleOrDefault = pmoManageEntities.tblUsers.SingleOrDefault(i => i.UsersID == userId);
            if (singleOrDefault != null)
                singleOrDefault.UserPass = newPassword;

            pmoManageEntities.SaveChanges();
        }

        #region UserLogs
        public IQueryable<UserLogs> GetUserLogs()
        {
            return this.ObjectContext.UserLogs;
        }

        public void InsertUserLogs(UserLogs userLogs)
        {
            userLogs.Date = GetDate();
            userLogs.IP = GetIPAddress();
            userLogs.UserName = GetUserName();
            userLogs.WebBrowser = GetWebBrowserName();
            userLogs.WebBrowserVersion = GetWebBrowserVersion();

            if ((userLogs.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userLogs, EntityState.Added);
            }
            else
            {
                this.ObjectContext.UserLogs.AddObject(userLogs);
            }
        }

        public void UpdateUserLogs(UserLogs currentUserLogs)
        {
            this.ObjectContext.UserLogs.AttachAsModified(currentUserLogs, this.ChangeSet.GetOriginal(currentUserLogs));
        }

        public void DeleteUserLogs(UserLogs userLogs)
        {
            if ((userLogs.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userLogs, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.UserLogs.Attach(userLogs);
                this.ObjectContext.UserLogs.DeleteObject(userLogs);
            }
        }

        //Log Methods
        public static DateTime GetDate()
        {
            return DateTime.Now;
        }

        public static string GetUserName()
        {
            string username = HttpContext.Current.User.Identity.Name;

            //return System.Net.Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["remote_addr"]).HostName;

            return String.IsNullOrWhiteSpace(username) ? "Guest" : username;
            //return System.Net.Dns.GetHostByAddress(GetIPAddress()).HostName;
        }

        public static string GetIPAddress()
        {
            return HttpContext.Current.Request.UserHostName;
        }

        public static string GetWebBrowserName()
        {
            //string s1 = HttpContext.Current.Request.Browser.Platform;
            //string s2 = HttpContext.Current.Request.Browser.Type;

            //string s4 = HttpContext.Current.Request.Browser.MajorVersion.ToString();

            return HttpContext.Current.Request.Browser.Browser.ToString();
        }

        public static string GetWebBrowserVersion()
        {
            return HttpContext.Current.Request.Browser.Version;
        }

        //Only for Valid IPs
        public static string GetMachineName()
        {
            return System.Net.Dns.GetHostByAddress(HttpContext.Current.Request.ServerVariables["REMOTE_HOST"]).HostName;
        }
        #endregion
    }
}