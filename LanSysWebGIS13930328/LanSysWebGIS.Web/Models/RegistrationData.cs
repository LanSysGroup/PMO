using System;

namespace LanSysWebGIS.Web
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Security;
    using LanSysWebGIS.Web.Resources;
    //using LanSysWebGIS.Web.Services;

    /// <summary>
    /// Class containing the values and validation rules for user registration.
    /// </summary>
    public sealed partial class RegistrationData
    {
        /// <summary>
        /// Gets and sets the user name.
        /// </summary>
        //[Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        [Display(Order = 0, Name = "FirstNameLabel", ResourceType = typeof(RegistrationDataResources))]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets and sets the user name.
        /// </summary>
        //[Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        [Display(Order = 1, Name = "LastNameLabel", ResourceType = typeof(RegistrationDataResources))]
        public string LastName { get; set; }

        /// <summary>
        /// Gets and sets the user name.
        /// </summary>
        [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        [Display(Order = 2, Name = "UserNameLabel", ResourceType = typeof(RegistrationDataResources))]
        [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessageResourceName = "ValidationErrorInvalidUserName", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        //[StringLength(255, MinimumLength = 4, ErrorMessageResourceName = "ValidationErrorBadUserNameLength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        public string UserName { get; set; }

        /// <summary>
        /// Gets and sets the email address.
        /// </summary>
        //[Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        [Display(Order = 5, Name = "EmailLabel", ResourceType = typeof(RegistrationDataResources))]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                           ErrorMessageResourceName = "ValidationErrorInvalidEmail", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        public string Email { get; set; }

        ///// <summary>
        ///// Gets and sets the friendly name of the user.
        ///// </summary>
        //[Display(Order = 1, Name = "FriendlyNameLabel", Description = "FriendlyNameDescription", ResourceType = typeof(RegistrationDataResources))]
        //[StringLength(255, MinimumLength = 0, ErrorMessageResourceName = "ValidationErrorBadFriendlyNameLength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        //public string FriendlyName { get; set; }

        /// <summary>
        /// Gets and sets the organization name of the user.
        /// </summary>
        //[Required]
        //[Display(Order = 6, Name = "OrganizationNameLabel", ResourceType = typeof(RegistrationDataResources))]
        //public UserOrganization Organization { get; set; }

        [Required]
        [Display(Order = 6, Name = "OrganizationNameLabel", ResourceType = typeof(RegistrationDataResources))]
        public String Organization { get; set; }

        /// <summary>
        /// Gets and sets the role name of the user.
        /// </summary>
        //[Required]
        //[Display(Order = 7, Name = "RoleNameLabel", ResourceType = typeof(RegistrationDataResources))]
        //public UserRole RoleName { get; set; }

        [Required]
        [Display(Order = 7, Name = "RoleNameLabel", ResourceType = typeof(RegistrationDataResources))]
        public String RoleName { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Order = 8, Name = "UserCommentLabel", ResourceType = typeof(RegistrationDataResources))]
        public String UserComment { get; set; }

        [Editable(true)]
        //[Display(Order = 9, Name = "UserIDLabel", ResourceType = typeof(RegistrationDataResources))]
        [Display(AutoGenerateField = false)]
        public string UserID { get; set; }

        [Editable(true)]
        //[Display(Order = 8, Name = "UserIDLabel", ResourceType = typeof(RegistrationDataResources))]
        [Display(AutoGenerateField = false)]
        public string IsChangePasswordNeeded { get; set; }

        ///// <summary>
        ///// Gets and sets the security question.
        ///// </summary>
        //[Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        //[Display(Order = 5, Name = "SecurityQuestionLabel", ResourceType = typeof(RegistrationDataResources))]
        //public string Question { get; set; }

        ///// <summary>
        ///// Gets and sets the answer to the security question.
        ///// </summary>
        //[Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        //[Display(Order = 6, Name = "SecurityAnswerLabel", ResourceType = typeof(RegistrationDataResources))]
        //[StringLength(128, ErrorMessageResourceName = "ValidationErrorBadAnswerLength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        //public string Answer { get; set; }
    }
}
