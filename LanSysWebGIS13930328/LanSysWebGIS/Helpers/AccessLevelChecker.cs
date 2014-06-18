using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LanSysWebGIS.Web;
using LanSysWebGIS.Assets.Resources;

namespace LanSysWebGIS.Helpers
{
    public static class AccessLevelChecker
    {
        public static bool CheckAuthentication(params string[] roles)
        {
            if (WebContext.Current.User.IsAuthenticated)
            {
                IEnumerable<string> userRoles = WebContext.Current.User.Roles;

                foreach (var role in userRoles)
                {
                    foreach (var item in roles)
                    {
                        if (item == role)
                        {
                            return true;
                        }
                    }
                }
            }

            throw new Exception(ApplicationStrings.msgNotProperAccessLevel);
        }

        public static bool CheckAdmin()
        {
            if (WebContext.Current.User.IsAuthenticated)
            {
                if (App.IsAdmin(int.Parse(WebContext.Current.User.UserID)))
                {
                    return true;
                }
            }

            throw new Exception(ApplicationStrings.msgNotProperAccessLevel);
        }
    }
}
