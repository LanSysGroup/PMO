using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LanSysWebGIS.Web.Models
{
    public class AuthenticationServiceRole
    {
        public AuthenticationServiceRole() { }

        public AuthenticationServiceRole(string rolename)
        {
            RoleName = rolename;
        }

        [Key]
        [Editable(true, AllowInitialValue = true)]
        public string RoleName { get; set; }
    }
}