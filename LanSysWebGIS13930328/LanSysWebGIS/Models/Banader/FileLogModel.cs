using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using LanSysWebGIS.Web;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.Models;
using LanSysWebGIS.Helpers;
using System.ComponentModel.DataAnnotations;

namespace LanSysWebGIS.Models.Banader
{
    public class FileLogModel
    {
        [Display(AutoGenerateField = false)]
        public string FileName { get; set; }

        [Display(AutoGenerateField = false)]
        public int FileID { get; set; }

        [Display(AutoGenerateField = false)]
        public string AddedByUserName { get; set; }

        [Display(AutoGenerateField = false)]
        public DateTime? DateAdded { get; set; }

        [Display(AutoGenerateField = false)]
        public int UserID { get; set; }

        [Display(Name = "مشاهده توسط", Order = 0)]
        public string ViewedBy
        {
            get
            {
                return App.allUsers.FirstOrDefault(i => i.UsersID == this.UserID).UserName;
            }
        }

        [Display(Name = "در تاریخ", Order = 1)]
        public DateTime DateViewed { get; set; }

        public FileLogModel()
        {
        }
    }
}
