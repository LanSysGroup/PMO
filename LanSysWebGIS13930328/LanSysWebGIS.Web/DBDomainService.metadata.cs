[Display(Name = "نام فایل", Order = 1)]
            public string FileName { get; set; }

            [Display(Name = "نوع اطلاعات", Order = 2)]
            public string InfoName { get; set; }

            [Display(Name = "نوع داده", Order = 3)]
            public string DataName { get; set; }

            [Display(Name = "دسته بندی موضوعی", Order = 4)]
            public string SubjectFName { get; set; }

            [Display(Name = "دسته بندی کلان", Order = 5)]
            public string TitleFName { get; set; }

            [Display(Name = "استان", Order = 6)]
            public string OstanName { get; set; }

            [Display(Name = "بندر", Order = 7)]
            public string PortName { get; set; }

            [Display(Name = "ناحیه", Order = 8)]
            public string ZoneName { get; set; }

            [Display(Name = "شرح فایل", Order = 9)]
            public string FullName { get; set; }

            [Display(Name = "فرمت فایل", Order = 10)]
            public string FileExt { get; set; }







            [Display(AutoGenerateField = false)]
            public string SubjectEName { get; set; }

            public Nullable<int> DataID { get; set; }

            [Display(AutoGenerateField = false)]
            public string FileFullName { get; set; }

            [Display(AutoGenerateField = false)]
            public Nullable<int> InfoID { get; set; }

            [Display(AutoGenerateField = false)]
            public Nullable<int> LinkID { get; set; }

            [Display(AutoGenerateField = false)]
            public Nullable<int> OstanID { get; set; }

            [Display(AutoGenerateField = false)]
            public Nullable<int> PortID { get; set; }
            
            [Display(AutoGenerateField = false)]
            public Nullable<int> PrjID { get; set; }

            [Display(AutoGenerateField = false)]
            public int SubjectID { get; set; }

            [Display(AutoGenerateField = false)]
            public int SubjectParentID { get; set; }

            [Display(AutoGenerateField = false)]
            public Nullable<int> TitleID { get; set; }

            [Display(AutoGenerateField = false)]
            public Nullable<int> ZoneID { get; set; }