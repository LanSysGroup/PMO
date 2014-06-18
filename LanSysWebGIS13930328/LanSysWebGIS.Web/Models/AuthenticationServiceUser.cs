using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;

namespace LanSysWebGIS.Web.Models
{
    public class AuthenticationServiceUser
    {
        public string Comment { get; set; }

        //public UserOrganization Org { get; set; }

        [Editable(false)]
        public DateTime CreationDate { get; set; }

        [Key]
        [Editable(false, AllowInitialValue = true)]
        public string Email { get; set; }

        public bool IsApproved { get; set; }

        [Key]
        [Editable(false, AllowInitialValue = true)]
        public string UserName { get; set; }
        // ...

        public AuthenticationServiceUser() { }

        public AuthenticationServiceUser(MembershipUser user)
        {
            this.FromMembershipUser(user);
        }

        public void FromMembershipUser(MembershipUser user)
        {
            this.Comment = user.Comment;
            this.CreationDate = user.CreationDate;
            this.Email = user.Email;
            this.IsApproved = user.IsApproved;
            this.UserName = user.UserName;
            // ...
        }

        public MembershipUser ToMembershipUser()
        {
            MembershipUser user = Membership.GetUser(this.UserName);

            if (user.Comment != this.Comment) user.Comment = this.Comment;
            if (user.IsApproved != this.IsApproved) user.IsApproved = this.IsApproved;
            // ...

            return user;
        }


    }
}