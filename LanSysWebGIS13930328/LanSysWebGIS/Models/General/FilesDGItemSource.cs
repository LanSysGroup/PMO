using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LanSysWebGIS.Models
{
    public class FilesDGItemSource
    {
        [Display(AutoGenerateField = false)]
        public string filePath { get; set; }

        [Display(Name = "نام عارضه", Order = 0)]
        public string ObjectName { get; set; }

        [Display(Name = "موضوع", Order = 1)]
        public string Subject { get; set; }

        [Display(Name = "نام فایل", Order = 2)]
        public string FileName { get; set; }

        [Display(Name = "کد عارضه", Order = 3)]
        public string ObjCode { get; set; }

        [Display(Name = "نام لایه", Order = 4)]
        public string LayerName { get; set; }
    }
}
