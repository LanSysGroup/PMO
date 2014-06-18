using System.ComponentModel.DataAnnotations;
using LanSysWebGIS.Web.Resources;

namespace LanSysWebGIS.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.Serialization;
    using System.ServiceModel.DomainServices.Server.ApplicationServices;
    using System.Web.Security;
    //using LanSysWebGIS.Web.Services;

    /// <summary>
    /// Class containing information about the authenticated user.
    /// </summary>
    public partial class User : UserBase
    {
        //// NOTE: Profile properties can be added for use in Silverlight application.
        //// To enable profiles, edit the appropriate section of web.config file.
        ////
        //// public string MyProfileProperty { get; set; }

        /// <summary>
        /// Gets and sets the friendly name of the user.
        /// </summary>
        //public string FriendlyName { get; set; }

        public String FirstName { get; set; }


        public String LastName { get; set; }

        //public UserOrganization Organization { get; set; }

        public String UserEmail { get; set; }

        public String Organization { get; set; }

        public String UserComment { get; set; }

        public string UserID { get; set; }

        public string IsChangePasswordNeeded { get; set; }

        //public ShoppingCart Organization { get; set; }
    }

    //public enum UserOrganization
    //{
    //    استانداری,
    //    آبفا
    //}

    //public enum UserRole
    //{
    //    عادی,
    //    ویرایشگر,
    //    مدیر,
    //    ادمین
    //}

    //[Serializable]
    //public class ShoppingCart
    //{
    //    public DateTime Created;
    //    public DateTime LastUpdated;
    //    public Dictionary<string, CartItem> CartItems = new Dictionary<string, CartItem>();
    //}

    //[Serializable]
    //public class CartItem
    //{
    //    public CartItem(int itemId, string itemName, double itemCost)
    //    {
    //        ID = itemId;
    //        Name = itemName;
    //        Cost = itemCost;
    //    }

    //    int ID;
    //    string Name;
    //    double Cost;
    //}

    //public class customclass
    //{

    //}



    //public enum States
    //{
    //    California,
    //    [Description("New Mexico")]
    //    NewMexico,
    //    [Description("New York")]
    //    NewYork,
    //    [Description("South Carolina")]
    //    SouthCarolina,
    //    Tennessee,
    //    Washington
    //}
}
