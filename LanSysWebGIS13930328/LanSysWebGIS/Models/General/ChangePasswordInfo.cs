using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.ServiceModel.DomainServices.Client.ApplicationServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LanSysWebGIS.Web.Resources;

namespace LanSysWebGIS.Models
{
    public partial class ChangePasswordInfo : ComplexObject
    {
        private OperationBase currentOperation;

        /// <summary>
        /// Gets or sets a function that returns the password.
        /// </summary>
        internal Func<string> OldPasswordAccessor { get; set; }

        /// <summary>
        /// Gets and sets the password.
        /// </summary>
        [Required(ErrorMessageResourceName = "ValidationErrorRequiredField",
            ErrorMessageResourceType = typeof(ValidationErrorResources))]
        [Display(Order = 0, Name = "CurrentPasswordLabel", ResourceType = typeof(RegistrationDataResources))]
        //[RegularExpression("^.*[^a-zA-Z0-9].*$", ErrorMessageResourceName = "ValidationErrorBadPasswordStrength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        //[StringLength(50, MinimumLength = 6, ErrorMessageResourceName = "ValidationErrorBadPasswordLength",
        //    ErrorMessageResourceType = typeof(ValidationErrorResources))]
        public string OldPassword 
        {
            get
            {
                return (this.OldPasswordAccessor == null) ? string.Empty : this.OldPasswordAccessor();
            }

            set
            {
                this.ValidateProperty("OldPassword", value);
                //CheckPasswordConfirmation();

                // Do not store the password in a private field as it should not be stored in memory in plain-text.
                // Instead, the supplied PasswordAccessor serves as the backing store for the value.

                this.RaisePropertyChanged("OldPassword");
            }
        }

        /// <summary>
        /// Gets or sets a function that returns the password.
        /// </summary>
        internal Func<string> NewPasswordAccessor { get; set; }

        /// <summary>
        /// Gets and sets the password.
        /// </summary>
        [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        //[Display(Order = 1, Name = "NewPasswordLabel", Description = "PasswordDescription", ResourceType = typeof(RegistrationDataResources))]
        [Display(Order = 1, Name = "NewPasswordLabel", ResourceType = typeof(RegistrationDataResources))]
        //[RegularExpression("^.*[^a-zA-Z0-9].*$", ErrorMessageResourceName = "ValidationErrorBadPasswordStrength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        //[StringLength(50, MinimumLength = 6, ErrorMessageResourceName = "ValidationErrorBadPasswordLength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        public string NewPassword
        {
            get
            {
                return (this.NewPasswordAccessor == null) ? string.Empty : this.NewPasswordAccessor();
            }

            set
            {
                //this.ValidateProperty("NewPassword", value);
                this.CheckPasswordConfirmation();

                // Do not store the password in a private field as it should not be stored in memory in plain-text.
                // Instead, the supplied PasswordAccessor serves as the backing store for the value.

                this.RaisePropertyChanged("NewPassword");
            }
        }

        /// <summary>
        /// Gets or sets a function that returns the password confirmation.
        /// </summary>
        internal Func<string> PasswordConfirmationAccessor { get; set; }

        /// <summary>
        /// Gets and sets the password confirmation string.
        /// </summary>
        [Required(ErrorMessageResourceName = "ValidationErrorRequiredField", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        [Display(Order = 2, Name = "NewPasswordConfirmationLabel", ResourceType = typeof(RegistrationDataResources))]
        //[RegularExpression("^.*[^a-zA-Z0-9].*$", ErrorMessageResourceName = "ValidationErrorBadPasswordStrength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        //[StringLength(50, MinimumLength = 6, ErrorMessageResourceName = "ValidationErrorBadPasswordLength", ErrorMessageResourceType = typeof(ValidationErrorResources))]
        public string NewPasswordConfirmation
        {
            get
            {
                return (this.PasswordConfirmationAccessor == null) ? string.Empty : this.PasswordConfirmationAccessor();
            }

            set
            {
                this.ValidateProperty("NewPasswordConfirmation", value);
                this.CheckPasswordConfirmation();

                // Do not store the password in a private field as it should not be stored in memory in plain-text.  
                // Instead, the supplied PasswordAccessor serves as the backing store for the value.

                this.RaisePropertyChanged("NewPasswordConfirmation");
            }
        }

        /// <summary>
        /// Gets or sets the current registration or login operation.
        /// </summary>
        internal OperationBase CurrentOperation
        {
            get
            {
                return this.currentOperation;
            }
            set
            {
                if (this.currentOperation != value)
                {
                    if (this.currentOperation != null)
                    {
                        this.currentOperation.Completed -= (s, e) => this.CurrentOperationChanged();
                    }

                    this.currentOperation = value;

                    if (this.currentOperation != null)
                    {
                        this.currentOperation.Completed += (s, e) => this.CurrentOperationChanged();
                    }

                    this.CurrentOperationChanged();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user is presently being registered or logged in.
        /// </summary>
        //[Display(AutoGenerateField = false)]
        //public bool IsRegistering
        //{
        //    get
        //    {
        //        return this.CurrentOperation != null && !this.CurrentOperation.IsComplete;
        //    }
        //}

        /// <summary>
        /// Helper method for when the current operation changes.
        /// Used to raise appropriate property change notifications.
        /// </summary>
        private void CurrentOperationChanged()
        {
            this.RaisePropertyChanged("IsRegistering");
        }

        /// <summary>
        /// Checks to ensure the password and confirmation match.
        /// If they don't match, a validation error is added.
        /// </summary>
        private void CheckPasswordConfirmation()
        {
            // If either of the passwords has not yet been entered, then don't test for equality between the fields.
            // The Required attribute will ensure a value has been entered for both fields.
            if (string.IsNullOrWhiteSpace(this.NewPassword)
                || string.IsNullOrWhiteSpace(this.NewPasswordConfirmation))
            {
                return;
            }

            // If the values are different, then add a validation error with both members specified
            if (this.NewPassword != this.NewPasswordConfirmation)
            {
                this.ValidationErrors.Add(new ValidationResult(ValidationErrorResources.ValidationErrorPasswordConfirmationMismatch, new string[] { "NewPasswordConfirmation", "NewPassword" }));
            }
        }

        ///// <summary>
        ///// Perform logic after the UserName value has been entered.
        ///// </summary>
        ///// <param name="userName">The user name value that was entered.</param>
        ///// <remarks>
        ///// Allow the form to indicate when the value has been completely entered.
        ///// Using the OnUserNameChanged method can lead to a premature call before the user has finished entering the value in the form.
        ///// </remarks>
        //internal void UserNameEntered(string userName)
        //{
        //    // Auto-Fill FriendlyName to match UserName for new entities when there is not a friendly name specified
        //    //if (string.IsNullOrWhiteSpace(this.FriendlyName))
        //    //{
        //    //    this.FriendlyName = userName;
        //    //}
        //}


        [Display(AutoGenerateField = false)]
        public string UserName { get; set; }

        /// <summary>
        /// Gets a value indicating whether the user is presently being registered or logged in.
        /// </summary>
        [Display(AutoGenerateField = false)]
        public bool IsRegistering
        {
            get
            {
                return this.CurrentOperation != null && !this.CurrentOperation.IsComplete;
            }
        }

        [Display(AutoGenerateField = false)]
        public bool _IsChangingPasswordHelper;

        /// <summary>
        /// Gets a value indicating whether the user is presently being registered or logged in.
        /// </summary>
        [Display(AutoGenerateField = false)]
        public bool IsChangingPasswordHelper
        {
            get { return this._IsChangingPasswordHelper; }
            set
            {
                this._IsChangingPasswordHelper = value;
                this.RaisePropertyChanged("IsChangingPassword");
            }

        }


        /// <summary>
        /// Gets a value indicating whether the user is presently being registered or logged in.
        /// </summary>
        [Display(AutoGenerateField = false)]
        public bool IsChangingPassword
        {
            get
            {
                return this.IsChangingPasswordHelper;
            }
        }

        [Display(AutoGenerateField = false)]
        public bool RememberMe { get; set; }
        

        /// <summary>
        /// Creates a new <see cref="LoginParameters"/> initialized with this entity's data (IsPersistent will default to false).
        /// </summary>
        public LoginParameters ToLoginParameters()
        {
            return new LoginParameters(this.UserName, this.OldPassword, false, null);
        }
    }
}
