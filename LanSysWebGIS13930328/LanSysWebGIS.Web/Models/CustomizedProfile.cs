using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LanSysWebGIS.Web.Resources;

namespace LanSysWebGIS.Web
{

    public partial class CustomizedProfile
    {
        //[Display(Order = 0, Name = "UserIDLabel", ResourceType = typeof(RegistrationDataResources))]
        //public string UserID { get; set; }

        [Editable(true)]
        //[Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        [Display(Order = 1, Name = "FirstNameLabel", ResourceType = typeof(RegistrationDataResources))]
        public string UserFirstName { get; set; }

        [Editable(true)]
        //[Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        [Display(Order = 2, Name = "LastNameLabel", ResourceType = typeof(RegistrationDataResources))]
        public string UserLastName { get; set; }

        [Key]
        [Editable(false)]
        [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        [Display(Order = 3, Name = "UserNameLabel", ResourceType = typeof(RegistrationDataResources))]
        public string UserName { get; set; }

        //[Editable(true)]
        //[Display(Order = 4, Name = "OrganizationNameLabel", ResourceType = typeof(RegistrationDataResources))]
        //public UserOrganization UserOrganization { get; set; }

        [Editable(true)]
        //[Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        [Display(Order = 4, Name = "EmailLabel", ResourceType = typeof(RegistrationDataResources))]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                           ErrorMessageResourceName = "ValidationErrorInvalidEmail", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        public String UserEmail { get; set; }

        [Editable(true)]
        [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        [Display(Order = 5, Name = "OrganizationNameLabel", ResourceType = typeof(RegistrationDataResources))]
        public String UserOrganization { get; set; }

        //[Editable(true)]
        //[Display(Order = 5, Name = "RoleNameLabel", ResourceType = typeof(RegistrationDataResources))]
        //public UserRole UserRole { get; set; }

        [Editable(true)]
        [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        [Display(Order = 6, Name = "RoleNameLabel", ResourceType = typeof(RegistrationDataResources))]
        public String UserRole { get; set; }

        [Editable(true)]
        [Display(Order = 7, Name = "UserCommentLabel", ResourceType = typeof(RegistrationDataResources))]
        public string UserComment { get; set; }

        [Editable(false)]
        [Display(Order = 8, Name = "UserIDLabel", ResourceType = typeof(RegistrationDataResources))]
        //[Display(AutoGenerateField = false)]
        public string UserID { get; set; }

        [Editable(true)]
        //[Display(Order = 8, Name = "UserIDLabel", ResourceType = typeof(RegistrationDataResources))]
        [Display(AutoGenerateField = false)]
        public string IsChangePasswordNeeded { get; set; }
    }
}