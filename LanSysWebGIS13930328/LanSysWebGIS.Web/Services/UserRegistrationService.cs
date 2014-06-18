using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LanSysWebGIS.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Web.Profile;
    using System.Web.Security;
    using LanSysWebGIS.Web.Models;
    using LanSysWebGIS.Web.Resources;

    // TODO: Switch to a secure endpoint when deploying the application.
    //       The user's name and password should only be passed using https.
    //       To do this, set the RequiresSecureEndpoint property on EnableClientAccessAttribute to true.
    //   
    //       [EnableClientAccess(RequiresSecureEndpoint = true)]
    //
    //       More information on using https with a Domain Service can be found on MSDN.

    /// <summary>
    /// Domain Service responsible for registering users.
    /// </summary>
    [EnableClientAccess]
    public class UserRegistrationService : DomainService
    {
        /// <summary>
        /// Role to which users will be added by default.
        /// </summary>
        //public const string DefaultRole = "Registered Users";

        public const string DefaultRole = Constants.ICOPMAS;

        //// NOTE: This is a sample code to get your application started.
        //// In the production code you should provide a mitigation against a denial of service attack by providing CAPTCHA control functionality or verifying user's email address.

        /// <summary>
        /// Adds a new user with the supplied <see cref="RegistrationData"/> and <paramref name="password"/>.
        /// </summary>
        /// <param name="user">The registration information for this user.</param>
        /// <param name="password">The password for the new user.</param>
        [Invoke(HasSideEffects = true)]
        public CreateUserStatus CreateUser(RegistrationData user,
            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            //[RegularExpression("^.*[^a-zA-Z0-9].*$", ErrorMessageResourceName = "ValidationErrorBadPasswordStrength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            //[StringLength(50, MinimumLength = 6, ErrorMessageResourceName = "ValidationErrorBadPasswordLength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            string password)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            // Run this BEFORE creating the user to make sure roles are enabled and the default role is available.
            //
            // If there is a problem with the role manager, it is better to fail now than to fail after the user is created.
            if (!Roles.RoleExists(UserRegistrationService.DefaultRole))
            {
                Roles.CreateRole(UserRegistrationService.DefaultRole);
            }

            // NOTE: ASP.NET by default uses SQL Server Express to create the user database. 
            // CreateUser will fail if you do not have SQL Server Express installed.
            MembershipCreateStatus createStatus;
            //Membership.CreateUser(user.UserName, password, user.Email, user.Question, user.Answer, true, null, out createStatus);
            Membership.CreateUser(user.UserName, password, user.Email, "yes?", "yes", true, null, out createStatus);

            if (createStatus != MembershipCreateStatus.Success)
            {
                return UserRegistrationService.ConvertStatus(createStatus);
            }



            string roleName = user.RoleName.ToString();

            if (String.IsNullOrEmpty(roleName))
            {
                roleName = DefaultRole;
            }

            Roles.AddUserToRole(user.UserName, roleName);

            //if (roleName == UserRegistrationService.DefaultRole)
            //{
            //    // Assign the user to the default role.
            //    // This will fail if role management is disabled.
            //    Roles.AddUserToRole(user.UserName, UserRegistrationService.DefaultRole);
            //}
            //else
            //{

            //}

            //if (user.RoleName.ToString() != Constants.Authenticated)
            //{
            //    //Roles.RemoveUserFromRole(user.UserName);

            //}

            // Set the friendly name (profile setting).
            // This will fail if the web.config is configured incorrectly.
            ProfileBase profile = ProfileBase.Create(user.UserName, true);
            //profile.SetPropertyValue("FriendlyName", user.FriendlyName);
            profile.SetPropertyValue("FirstName", user.FirstName);
            profile.SetPropertyValue("LastName", user.LastName);
            profile.SetPropertyValue("UserComment", user.UserComment);
            profile.SetPropertyValue("Organization", user.Organization);
            profile.SetPropertyValue("UserEmail", user.Email);
            profile.SetPropertyValue("UserRole", user.RoleName);
            //profile.SetPropertyValue("UserID", user.UserID);

            PMOService service = new PMOService();
            int maxUsersID = service.GetTblUsersMaxId();
            profile.SetPropertyValue("UserID", (maxUsersID + 1).ToString());

            profile.SetPropertyValue("IsChangePasswordNeeded", "True");

            profile.Save();

            //Create a tblUsers entity
            int userTypeID = -1;
            switch (user.RoleName)
            {
                case Constants.Administrator:
                    userTypeID = 1;
                    break;
                case Constants.Monitoring:
                    userTypeID = 2;
                    break;
                case Constants.ICZM:
                    userTypeID = 3;
                    break;
                case Constants.ICOPMAS:
                    userTypeID = 4;
                    break;
            }
            tblUsers newUser = new tblUsers()
            {
                UsersID = int.Parse(profile.GetPropertyValue("UserID").ToString()),
                UserName = user.LastName,
                UserID = user.UserName,
                UserPass = "123",
                UserTypeID = userTypeID
            };
            PMOManageEntities pmoManageEntities = new PMOManageEntities();
            pmoManageEntities.tblUsers.AddObject(newUser);
            pmoManageEntities.SaveChanges();

            return CreateUserStatus.Success;
        }

        private static CreateUserStatus ConvertStatus(MembershipCreateStatus createStatus)
        {
            switch (createStatus)
            {
                case MembershipCreateStatus.Success: return CreateUserStatus.Success;
                case MembershipCreateStatus.InvalidUserName: return CreateUserStatus.InvalidUserName;
                case MembershipCreateStatus.InvalidPassword: return CreateUserStatus.InvalidPassword;
                case MembershipCreateStatus.InvalidQuestion: return CreateUserStatus.InvalidQuestion;
                case MembershipCreateStatus.InvalidAnswer: return CreateUserStatus.InvalidAnswer;
                case MembershipCreateStatus.InvalidEmail: return CreateUserStatus.InvalidEmail;
                case MembershipCreateStatus.DuplicateUserName: return CreateUserStatus.DuplicateUserName;
                case MembershipCreateStatus.DuplicateEmail: return CreateUserStatus.DuplicateEmail;
                default: return CreateUserStatus.Failure;
            }
        }

        [Invoke]
        public string[] GetAllRoles()
        {
            return Roles.GetAllRoles();
        }


        /// <summary>
        /// Adds a new user with the supplied <see cref="RegistrationData"/> and <paramref name="password"/>.
        /// </summary>
        /// <param name="user">The registration information for this user.</param>
        /// <param name="password">The password for the new user.</param>
        [Invoke(HasSideEffects = true)]
        public bool ChangePassword(String userName, [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            //[RegularExpression("^.*[^a-zA-Z0-9].*$", ErrorMessageResourceName = "ValidationErrorBadPasswordStrength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            //[StringLength(50, MinimumLength = 6, ErrorMessageResourceName = "ValidationErrorBadPasswordLength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            string oldPassword,
            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            //[RegularExpression("^.*[^a-zA-Z0-9].*$", ErrorMessageResourceName = "ValidationErrorBadPasswordStrength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            //[StringLength(50, MinimumLength = 6, ErrorMessageResourceName = "ValidationErrorBadPasswordLength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            string newPassword)
        {
            if (userName == null)
            {
                //throw new ArgumentNullException("user");

            }
            else
            {
                if (Membership.ValidateUser(userName, oldPassword))
                {
                    MembershipUser memUser = Membership.GetUser(userName);

                    if (memUser == null)
                    {
                        return false;
                    }

                    if (memUser.IsLockedOut)
                    {
                        memUser.UnlockUser();
                    }

                    bool changedPasswordSuccessfully = memUser.ChangePassword(oldPassword, newPassword);

                    if (changedPasswordSuccessfully)
                    {
                        ProfileBase profile = ProfileBase.Create(userName, true);

                        //Update PMO Database (tblUser)
                        PMOService pmoService = new PMOService();

                        pmoService.ChangePmoPassword(int.Parse(profile.GetPropertyValue("UserID").ToString()), newPassword);

                        //Update profile
                        profile.SetPropertyValue("IsChangePasswordNeeded", "False");
                        profile.Save();

                        //tblUsers tblUser = pmoManageEntities.tblUsers.Where(i => i.UserID == profile.UserID);
                    }

                    return changedPasswordSuccessfully;
                }
            }

            return false;
        }

        /// <summary>
        /// Adds a new user with the supplied <see cref="RegistrationData"/> and <paramref name="password"/>.
        /// </summary>
        /// <param name="user">The registration information for this user.</param>
        /// <param name="password">The password for the new user.</param>
        [Invoke(HasSideEffects = true)]
        public bool ChangePasswordByAdmin(String userName,
            [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            //[RegularExpression("^.*[^a-zA-Z0-9].*$", ErrorMessageResourceName = "ValidationErrorBadPasswordStrength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            //[StringLength(50, MinimumLength = 6, ErrorMessageResourceName = "ValidationErrorBadPasswordLength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
            string newPassword)
        {
            if (userName == null)
            {
                //throw new ArgumentNullException("user");

            }
            else
            {
                MembershipUser memUser = Membership.GetUser(userName);

                if (memUser == null)
                {
                    return false;
                }

                if (memUser.IsLockedOut)
                {
                    memUser.UnlockUser();
                }

                string tempPassword = memUser.ResetPassword();

                bool changedPasswordSuccessfully = memUser.ChangePassword(tempPassword, newPassword);

                if (changedPasswordSuccessfully)
                {
                    ProfileBase profile = ProfileBase.Create(userName, true);

                    //Update PMO Database (tblUser)
                    PMOService pmoService = new PMOService();

                    pmoService.ChangePmoPassword(int.Parse(profile.GetPropertyValue("UserID").ToString()), newPassword);

                    //Update profile
                    profile.SetPropertyValue("IsChangePasswordNeeded", "False");
                    profile.Save();

                    //tblUsers tblUser = pmoManageEntities.tblUsers.Where(i => i.UserID == profile.UserID);
                }

                return changedPasswordSuccessfully;
            }

            return false;
        }


        //Send Mail
        [Invoke]
        public void SendEmail(string fromAddress,
                string toAddress, string bccAddress, string ccAddress,
                string subject, string body)
        {
            MailHelper.SendMailMessage(fromAddress, toAddress, bccAddress, ccAddress, subject, body);
        }

        [Invoke]
        [RequiresRole(Constants.Administrator)]
        public bool ResetPassword(string userName, string emailAddress)
        {
            bool isResetPasswordSuccessful = false;

            MembershipUser memUser = Membership.GetUser(userName);

            if (memUser == null)
            {
                return isResetPasswordSuccessful;
            }

            if (memUser.IsLockedOut)
            {
                memUser.UnlockUser();
            }

            string tempPassword = memUser.ResetPassword();

            string newPassword = Membership.GeneratePassword(10, 0);
            newPassword = Regex.Replace(newPassword, @"[^a-zA-Z0-9]", m => "9");

            isResetPasswordSuccessful = memUser.ChangePassword(tempPassword, newPassword);

            string emailBody = string.Format(
                    CultureInfo.CurrentUICulture,
                    RegistrationDataResources.EmailBodyPasswordResetSuccessfully, newPassword);

            string emailTemplate = string.Format(
                    CultureInfo.CurrentUICulture,
                    RegistrationDataResources.EmailTemplate, emailBody);

            SendEmail("LanSysGroup@gmail.com", emailAddress, null, null,
                                                          RegistrationDataResources.EmailSubjectPasswordResetSuccessfully, emailTemplate);

            return isResetPasswordSuccessful;
        }
    }

    /// <summary>
    /// An enumeration of the values that can be returned from <see cref="UserRegistrationService.CreateUser"/>
    /// </summary>
    public enum CreateUserStatus
    {
        Success = 0,
        InvalidUserName = 1,
        InvalidPassword = 2,
        InvalidQuestion = 3,
        InvalidAnswer = 4,
        InvalidEmail = 5,
        DuplicateUserName = 6,
        DuplicateEmail = 7,
        Failure = 8,
    }


}