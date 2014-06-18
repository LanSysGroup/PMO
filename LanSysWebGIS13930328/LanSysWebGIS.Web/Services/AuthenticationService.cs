using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Hosting;
using System.ServiceModel.DomainServices.Server;
using System.ServiceModel.DomainServices.Server.ApplicationServices;
using System.Web.Profile;
using System.Web.Security;
using LanSysWebGIS.Web.Models;
using LanSysWebGIS.Web.Resources;

namespace LanSysWebGIS.Web
{
    // TODO: Switch to a secure endpoint when deploying the application.
    //       The user's name and password should only be passed using https.
    //       To do this, set the RequiresSecureEndpoint property on EnableClientAccessAttribute to true.
    //   
    //       [EnableClientAccess(RequiresSecureEndpoint = true)]
    //
    //       More information on using https with a Domain Service can be found on MSDN.

    /// <summary>
    /// Domain Service responsible for authenticating users when they log on to the application.
    ///
    /// Most of the functionality is already provided by the AuthenticationBase class.
    /// </summary>
    [EnableClientAccess(RequiresSecureEndpoint = false)]
    public class AuthenticationService : AuthenticationBase<User>
    {
        [RequiresRole(Constants.Administrator)]
        public IEnumerable<AuthenticationServiceUser> GetAllUsers()
        {
            return Membership.GetAllUsers().Cast<MembershipUser>().Select(u => new AuthenticationServiceUser(u));
        }

        [Query]
        [RequiresRole(Constants.Administrator)]
        public IEnumerable<AuthenticationServiceUser> MyGetUser(string username)
        {
            //return Membership.GetAllUsers().Cast<MembershipUser>().Select(u => new AuthenticationServiceUser(u));
            AuthenticationServiceUser user = new AuthenticationServiceUser(Membership.GetUser(username));

            List<AuthenticationServiceUser> list = new List<AuthenticationServiceUser>();

            list.Add(user);

            return list;
        }

        [Query]
        [RequiresRole(Constants.Administrator)]
        public IEnumerable<CustomizedProfile> GetAllProfiles()
        {
            IEnumerable<AuthenticationServiceUser> allUsers = GetAllUsers();

            Dictionary<string, List<string>> user2profile = new Dictionary<string, List<string>>();

            foreach (var user in allUsers)
            {
                string[] roles = Roles.GetRolesForUser(user.UserName);

                ProfileBase profile = ProfileBase.Create(user.UserName, true);

                //profile.SetPropertyValue("IsChangePasswordNeeded", "True");
                //profile.Save();

                List<string> attributes = new List<string>();
                attributes.Add(profile.GetPropertyValue("FirstName").ToString());
                attributes.Add(profile.GetPropertyValue("LastName").ToString());
                attributes.Add(profile.GetPropertyValue("Organization").ToString());
                attributes.Add(roles[0]);
                attributes.Add(profile.GetPropertyValue("UserComment").ToString());
                attributes.Add(profile.GetPropertyValue("UserEmail").ToString());
                attributes.Add(profile.GetPropertyValue("UserID").ToString());
                attributes.Add(profile.GetPropertyValue("IsChangePasswordNeeded").ToString());

                user2profile.Add(user.UserName, attributes);

                

                //profiles.Add(attributes);

                //MembershipUser t = new MembershipUser();
                //t.ResetPassword();

            }

            var result = (from authenticationServiceUser in allUsers
                          select new CustomizedProfile()
                          {
                              UserName = authenticationServiceUser.UserName,
                              UserFirstName = user2profile[authenticationServiceUser.UserName][0],
                              UserLastName = user2profile[authenticationServiceUser.UserName][1],
                              //UserOrganization = SelectOrganization(user2profile[authenticationServiceUser.UserName][2]),
                              //UserRole = SelectRole(user2profile[authenticationServiceUser.UserName][3]),
                              UserOrganization = user2profile[authenticationServiceUser.UserName][2],
                              UserRole = user2profile[authenticationServiceUser.UserName][3],
                              UserComment = user2profile[authenticationServiceUser.UserName][4],
                              UserEmail = user2profile[authenticationServiceUser.UserName][5],
                              UserID = user2profile[authenticationServiceUser.UserName][6],
                              IsChangePasswordNeeded = user2profile[authenticationServiceUser.UserName][7]
                          }
                         );
            return result;
        }

        [Query]
        [RequiresRole(Constants.Administrator)]
        public IEnumerable<CustomizedProfile> GetProfile(String userName)
        {
            AuthenticationServiceUser user = Membership.FindUsersByName(userName).Cast<MembershipUser>().Select(u => new AuthenticationServiceUser(u)).FirstOrDefault();

            string[] roles = Roles.GetRolesForUser(user.UserName);

            ProfileBase profile = ProfileBase.Create(user.UserName, true);

            List<string> attributes = new List<string>();
            attributes.Add(profile.GetPropertyValue("FirstName").ToString());
            attributes.Add(profile.GetPropertyValue("LastName").ToString());
            attributes.Add(profile.GetPropertyValue("Organization").ToString());
            attributes.Add(roles[0]);
            attributes.Add(profile.GetPropertyValue("UserComment").ToString());
            attributes.Add(profile.GetPropertyValue("UserEmail").ToString());
            attributes.Add(profile.GetPropertyValue("UserID").ToString());
            attributes.Add(profile.GetPropertyValue("IsChangePasswordNeeded").ToString());

            Dictionary<string, List<string>> user2profile = new Dictionary<string, List<string>>();

            user2profile.Add(user.UserName, attributes);



            //foreach (var user in allUsers)
            //{


            //    //profiles.Add(attributes);

            //    //MembershipUser t = new MembershipUser();
            //    //t.ResetPassword();

            //}

            CustomizedProfile customizedProfile = new CustomizedProfile()
            {
                UserName = user.UserName,
                UserFirstName = user2profile[user.UserName][0],
                UserLastName = user2profile[user.UserName][1],
                //UserOrganization = SelectOrganization(user2profile[authenticationServiceUser.UserName][2]),
                //UserRole = SelectRole(user2profile[authenticationServiceUser.UserName][3]),
                UserOrganization = user2profile[user.UserName][2],
                UserRole = user2profile[user.UserName][3],
                UserComment = user2profile[user.UserName][4],
                UserEmail = user2profile[user.UserName][5],
                UserID = user2profile[user.UserName][6],
                IsChangePasswordNeeded = user2profile[user.UserName][7]
            };

            //var result = (from authenticationServiceUser in user
            //              select new CustomizedProfile()
            //              {

            //              }
            //             );

            List<CustomizedProfile> customizedProfiles = new List<CustomizedProfile>();
            customizedProfiles.Add(customizedProfile);

            return customizedProfiles;
        }


        //[Invoke]
        //public void DeleteUser(string userName)
        //{
        //    Membership.DeleteUser(userName);
        //}

        [RequiresRole(Constants.Administrator)]
        public void DeleteUser(AuthenticationServiceUser user)
        {
            //Membership.DeleteUser(user.UserName);
        }

        [RequiresRole(Constants.Administrator)]
        public void UpdateUser(AuthenticationServiceUser user)
        {
            //Membership.UpdateUser(user.ToMembershipUser());
        }

        [Invoke]
        [RequiresRole(Constants.Administrator)]
        public void UpdateProfile(CustomizedProfile newProfile)
        {
            //String userName = newProfile.UserName;

            //ProfileBase profile = ProfileBase.Create(userName, true);

            //profile.SetPropertyValue("FirstName",newProfile.UserFirstName);
            //profile.SetPropertyValue("LastName", newProfile.UserLastName);
            //profile.SetPropertyValue("Organization", newProfile.UserOrganization);

            //Roles.RemoveUserFromRole(userName, Roles.GetRolesForUser(userName)[0]);
            //Roles.AddUserToRole(userName, newProfile.UserRole);

            //profile.SetPropertyValue("UserComment", newProfile.UserComment);

            //profile.Save();

        }



        [Delete]
        public void DeleteExistingUser(CustomizedProfile profile)
        {
            //throw new NotImplementedException("Not supported");
            Membership.DeleteUser(profile.UserName);
        }

        [Insert]
        public void InsertNewUser(CustomizedProfile profile)
        {
            throw new NotImplementedException("Not supported");
        }

        [Update]
        public void UpdateCurrentUser(CustomizedProfile newProfile)
        {
            //throw new NotImplementedException("Not supported");
            String userName = newProfile.UserName;

            ProfileBase profile = ProfileBase.Create(userName, true);

            profile.SetPropertyValue("FirstName", newProfile.UserFirstName);
            profile.SetPropertyValue("LastName", newProfile.UserLastName);

            profile.SetPropertyValue("UserEmail", newProfile.UserEmail);
            MembershipUser membershipUser = Membership.GetUser(userName);
            membershipUser.Email = newProfile.UserEmail;
            Membership.UpdateUser(membershipUser);
            
            profile.SetPropertyValue("Organization", newProfile.UserOrganization);

            profile.SetPropertyValue("UserRole", newProfile.UserRole);
            Roles.RemoveUserFromRole(userName, Roles.GetRolesForUser(userName)[0]);
            Roles.AddUserToRole(userName, newProfile.UserRole);

            profile.SetPropertyValue("UserComment", newProfile.UserComment);

            profile.SetPropertyValue("UserID", newProfile.UserID);

            profile.SetPropertyValue("IsChangePasswordNeeded", newProfile.IsChangePasswordNeeded);

            profile.Save();
        }


        [Query]
        [RequiresRole(Constants.Administrator)]
        public IEnumerable<CustomizedProfile> GetOnlineUsers()
        {
            IEnumerable<CustomizedProfile> allProfiles = GetAllProfiles();

            return allProfiles.Where(user => Membership.GetUser(user.UserName).IsOnline);

            //List<CustomizedProfile> onlineUsers = new List<CustomizedProfile>();

            //foreach (var customizedProfile in allProfiles)
            //{
            //    if
            //}
        }



        //[Query]
        //public int GetNumberOfOnlineUsers()





        //public void UpdateUser(AuthenticationServiceUser user)
        //{
        //    ProfileBase profile = ProfileBase.Create(user.UserName, true);
        //    //profile.SetPropertyValue("FriendlyName", user.FriendlyName);
        //    profile.SetPropertyValue("FirstName", user.FirstName);
        //    profile.SetPropertyValue("LastName", user.LastName);
        //    profile.SetPropertyValue("UserComment", user.UserComment);


        //    //ShoppingCart bookCart = new ShoppingCart();
        //    //bookCart.CartItems.Add("Contoso", new CartItem(37843, "Widget", 49.99));
        //    //bookCart.CartItems.Add("Microsoft", new
        //    //    CartItem(39232, "Software", 49.99));


        //    profile.SetPropertyValue("Organization", user.Organization);
        //    profile.Save();
        //}

        //public UserOrganization SelectOrganization(string organization)
        //{
        //    UserOrganization org = new UserOrganization();

        //    if (!UserOrganization.TryParse(organization, true, out org))
        //    {
        //        return UserOrganization.استانداری;
        //    }

        //    return org;
        //}

        //public UserRole SelectRole(string role)
        //{
        //    UserRole r = new UserRole();

        //    if (!UserRole.TryParse(role, true, out r))
        //    {
        //        return UserRole.عادی;
        //    }

        //    return r;
        //}
    }
}
