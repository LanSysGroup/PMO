
namespace LanSysWebGIS.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies UserLogsMetadata as the class
    // that carries additional metadata for the UserLogs class.
    [MetadataTypeAttribute(typeof(UserLogs.UserLogsMetadata))]
    public partial class UserLogs
    {

        // This class allows you to attach custom attributes to properties
        // of the UserLogs class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class UserLogsMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private UserLogsMetadata()
            {
            }

            public string Action { get; set; }

            public string ActionDesc { get; set; }

            public Nullable<DateTime> Date { get; set; }

            public long ID { get; set; }

            public string IP { get; set; }

            public string UserName { get; set; }

            public string WebBrowser { get; set; }

            public string WebBrowserVersion { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ApplicationsMetadata as the class
    // that carries additional metadata for the Applications class.
    [MetadataTypeAttribute(typeof(Applications.ApplicationsMetadata))]
    public partial class Applications
    {

        // This class allows you to attach custom attributes to properties
        // of the Applications class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ApplicationsMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ApplicationsMetadata()
            {
            }

            public Guid ApplicationId { get; set; }

            public string ApplicationName { get; set; }

            public string Description { get; set; }

            public EntityCollection<Memberships> Memberships { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Deliver_DelHgDetailMetadata as the class
    // that carries additional metadata for the Deliver_DelHgDetail class.
    [MetadataTypeAttribute(typeof(Deliver_DelHgDetail.Deliver_DelHgDetailMetadata))]
    public partial class Deliver_DelHgDetail
    {

        // This class allows you to attach custom attributes to properties
        // of the Deliver_DelHgDetail class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Deliver_DelHgDetailMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Deliver_DelHgDetailMetadata()
            {
            }

            public int DelHgID { get; set; }

            public string FromDate { get; set; }

            public int ID { get; set; }

            public string InfoDesc { get; set; }

            public string ToDate { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Deliver_DelHoghooghiMetadata as the class
    // that carries additional metadata for the Deliver_DelHoghooghi class.
    [MetadataTypeAttribute(typeof(Deliver_DelHoghooghi.Deliver_DelHoghooghiMetadata))]
    public partial class Deliver_DelHoghooghi
    {

        // This class allows you to attach custom attributes to properties
        // of the Deliver_DelHoghooghi class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Deliver_DelHoghooghiMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Deliver_DelHoghooghiMetadata()
            {
            }

            public string Company { get; set; }

            public string DeliverDate { get; set; }

            public string Deliverer { get; set; }

            public int ID { get; set; }

            public string LetterNo { get; set; }

            public string ReqDate { get; set; }

            public string Requester { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Deliver_DelStuMetadata as the class
    // that carries additional metadata for the Deliver_DelStu class.
    [MetadataTypeAttribute(typeof(Deliver_DelStu.Deliver_DelStuMetadata))]
    public partial class Deliver_DelStu
    {

        // This class allows you to attach custom attributes to properties
        // of the Deliver_DelStu class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Deliver_DelStuMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Deliver_DelStuMetadata()
            {
            }

            public string DeliverDate { get; set; }

            public string Deliverer { get; set; }

            public int ID { get; set; }

            public string LetterNo { get; set; }

            public string ReqDate { get; set; }

            public string Requester { get; set; }

            public string University { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Deliver_DelStuDetailMetadata as the class
    // that carries additional metadata for the Deliver_DelStuDetail class.
    [MetadataTypeAttribute(typeof(Deliver_DelStuDetail.Deliver_DelStuDetailMetadata))]
    public partial class Deliver_DelStuDetail
    {

        // This class allows you to attach custom attributes to properties
        // of the Deliver_DelStuDetail class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Deliver_DelStuDetailMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Deliver_DelStuDetailMetadata()
            {
            }

            public int DelStuID { get; set; }

            public string FromDate { get; set; }

            public int ID { get; set; }

            public string InfoDesc { get; set; }

            public string ToDate { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Deliver_ReqHgDetailMetadata as the class
    // that carries additional metadata for the Deliver_ReqHgDetail class.
    [MetadataTypeAttribute(typeof(Deliver_ReqHgDetail.Deliver_ReqHgDetailMetadata))]
    public partial class Deliver_ReqHgDetail
    {

        // This class allows you to attach custom attributes to properties
        // of the Deliver_ReqHgDetail class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Deliver_ReqHgDetailMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Deliver_ReqHgDetailMetadata()
            {
            }

            public string FromDate { get; set; }

            public int ID { get; set; }

            public string InfoDesc { get; set; }

            public int ReqHgID { get; set; }

            public string ToDate { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Deliver_ReqHoghoghiMetadata as the class
    // that carries additional metadata for the Deliver_ReqHoghoghi class.
    [MetadataTypeAttribute(typeof(Deliver_ReqHoghoghi.Deliver_ReqHoghoghiMetadata))]
    public partial class Deliver_ReqHoghoghi
    {

        // This class allows you to attach custom attributes to properties
        // of the Deliver_ReqHoghoghi class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Deliver_ReqHoghoghiMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Deliver_ReqHoghoghiMetadata()
            {
            }

            public string Company { get; set; }

            public int ID { get; set; }

            public string LetterNo { get; set; }

            public string ProjectDesc { get; set; }

            public string Region { get; set; }

            public string ReqDate { get; set; }

            public string Requester { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Deliver_ReqStuMetadata as the class
    // that carries additional metadata for the Deliver_ReqStu class.
    [MetadataTypeAttribute(typeof(Deliver_ReqStu.Deliver_ReqStuMetadata))]
    public partial class Deliver_ReqStu
    {

        // This class allows you to attach custom attributes to properties
        // of the Deliver_ReqStu class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Deliver_ReqStuMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Deliver_ReqStuMetadata()
            {
            }

            public string ApproveDate { get; set; }

            public string Branch { get; set; }

            public string DefendDate { get; set; }

            public int ID { get; set; }

            public string LetterNo { get; set; }

            public string Ostad { get; set; }

            public string ProjTitle { get; set; }

            public string Region { get; set; }

            public string Requester { get; set; }

            public string StuLevel { get; set; }

            public string University { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Deliver_ReqStuDetailMetadata as the class
    // that carries additional metadata for the Deliver_ReqStuDetail class.
    [MetadataTypeAttribute(typeof(Deliver_ReqStuDetail.Deliver_ReqStuDetailMetadata))]
    public partial class Deliver_ReqStuDetail
    {

        // This class allows you to attach custom attributes to properties
        // of the Deliver_ReqStuDetail class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Deliver_ReqStuDetailMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Deliver_ReqStuDetailMetadata()
            {
            }

            public string FromDate { get; set; }

            public int ID { get; set; }

            public string InfoDesc { get; set; }

            public int ReqStuID { get; set; }

            public string ToDate { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DocFileMetadata as the class
    // that carries additional metadata for the DocFile class.
    [MetadataTypeAttribute(typeof(DocFile.DocFileMetadata))]
    public partial class DocFile
    {

        // This class allows you to attach custom attributes to properties
        // of the DocFile class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DocFileMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DocFileMetadata()
            {
            }

            public Nullable<DateTime> fromDate { get; set; }

            public Nullable<DateTime> toDate { get; set; }

            public Nullable<double> LatX { get; set; }

            public Nullable<double> LongY { get; set; }

            public string AddedByUserName { get; set; }

            public Nullable<DateTime> DateAdded { get; set; }

            public int FieldId { get; set; }

            public string FileExt { get; set; }

            public int FileID { get; set; }

            public string FileName { get; set; }

            public string FilePath { get; set; }

            public Nullable<bool> Flag { get; set; }

            public Nullable<int> SubjectID { get; set; }

            public string Title { get; set; }


        }
    }

    // The MetadataTypeAttribute identifies DocFileUserLogMetadata as the class
    // that carries additional metadata for the DocFileUserLog class.
    [MetadataTypeAttribute(typeof(DocFileUserLog.DocFileUserLogMetadata))]
    public partial class DocFileUserLog
    {

        // This class allows you to attach custom attributes to properties
        // of the DocFileUserLog class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DocFileUserLogMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DocFileUserLogMetadata()
            {
            }

            public Nullable<DateTime> DateVisited { get; set; }

            public Nullable<int> FileId { get; set; }

            public int Id { get; set; }

            public Nullable<int> UserId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DocKeyWordMetadata as the class
    // that carries additional metadata for the DocKeyWord class.
    [MetadataTypeAttribute(typeof(DocKeyWord.DocKeyWordMetadata))]
    public partial class DocKeyWord
    {

        // This class allows you to attach custom attributes to properties
        // of the DocKeyWord class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DocKeyWordMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DocKeyWordMetadata()
            {
            }

            public int FileId { get; set; }

            public int KeyWordId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DocLocationTreeMetadata as the class
    // that carries additional metadata for the DocLocationTree class.
    [MetadataTypeAttribute(typeof(DocLocationTree.DocLocationTreeMetadata))]
    public partial class DocLocationTree
    {

        // This class allows you to attach custom attributes to properties
        // of the DocLocationTree class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DocLocationTreeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DocLocationTreeMetadata()
            {
            }

            public Nullable<int> DocLocTypeId { get; set; }

            public int FieldId { get; set; }

            public int LocationId { get; set; }

            public string LocEName { get; set; }

            public string LocFName { get; set; }

            public Nullable<int> ParentLocationId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DocLocationTypeMetadata as the class
    // that carries additional metadata for the DocLocationType class.
    [MetadataTypeAttribute(typeof(DocLocationType.DocLocationTypeMetadata))]
    public partial class DocLocationType
    {

        // This class allows you to attach custom attributes to properties
        // of the DocLocationType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DocLocationTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DocLocationTypeMetadata()
            {
            }

            public int FieldId { get; set; }

            public int Id { get; set; }

            public string LocType { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DocSubjectLocationFilterMetadata as the class
    // that carries additional metadata for the DocSubjectLocationFilter class.
    [MetadataTypeAttribute(typeof(DocSubjectLocationFilter.DocSubjectLocationFilterMetadata))]
    public partial class DocSubjectLocationFilter
    {

        // This class allows you to attach custom attributes to properties
        // of the DocSubjectLocationFilter class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DocSubjectLocationFilterMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DocSubjectLocationFilterMetadata()
            {
            }

            public int FieldId { get; set; }

            public int ID { get; set; }

            public int LocationID { get; set; }

            public int SubjectID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DocSubjectTreeMetadata as the class
    // that carries additional metadata for the DocSubjectTree class.
    [MetadataTypeAttribute(typeof(DocSubjectTree.DocSubjectTreeMetadata))]
    public partial class DocSubjectTree
    {

        // This class allows you to attach custom attributes to properties
        // of the DocSubjectTree class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DocSubjectTreeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DocSubjectTreeMetadata()
            {
            }

            [Include]
            [Association("dbo.SubjectOstan", "SubjectID", "ID")]
            public EntityCollection<Ostan> Ostan { get; set; }

            public string SubjectEName { get; set; }

            public string SubjectFName { get; set; }

            public int SubjectID { get; set; }

            public int SubjectParentID { get; set; }

            [Include]
            [Association("dbo.SubjectDataType", "SubjectID", "ID")]
            public EntityCollection<tblDataType> tblDataType { get; set; }

            [Include]
            [Association("dbo.SubjectInfoType", "SubjectID", "ID")]
            public EntityCollection<tblInfoType> tblInfoType { get; set; }

            [Include]
            [Association("dbo.SubjectPort", "SubjectID", "ID")]
            public EntityCollection<tblPorts> tblPorts { get; set; }

            public Nullable<int> TitleID { get; set; }

            [Include]
            [Association("dbo.SubjectZone", "SubjectID", "ID")]
            public EntityCollection<Zone> Zone { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DocSubjectUserFilterMetadata as the class
    // that carries additional metadata for the DocSubjectUserFilter class.
    [MetadataTypeAttribute(typeof(DocSubjectUserFilter.DocSubjectUserFilterMetadata))]
    public partial class DocSubjectUserFilter
    {

        // This class allows you to attach custom attributes to properties
        // of the DocSubjectUserFilter class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DocSubjectUserFilterMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DocSubjectUserFilterMetadata()
            {
            }

            public int SubjectId { get; set; }

            public int UserId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DocTitleTreeMetadata as the class
    // that carries additional metadata for the DocTitleTree class.
    [MetadataTypeAttribute(typeof(DocTitleTree.DocTitleTreeMetadata))]
    public partial class DocTitleTree
    {

        // This class allows you to attach custom attributes to properties
        // of the DocTitleTree class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DocTitleTreeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DocTitleTreeMetadata()
            {
            }

            public string BasePath { get; set; }

            public string FromDate { get; set; }

            public Nullable<int> ParentTitleId { get; set; }

            public EntityCollection<tblProjectMap> tblProjectMap { get; set; }

            public string TitleEName { get; set; }

            public string TitleFName { get; set; }

            public int TitleId { get; set; }

            public Nullable<int> TitleTypeId { get; set; }

            public string ToDate { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DocTitleUserFilterMetadata as the class
    // that carries additional metadata for the DocTitleUserFilter class.
    [MetadataTypeAttribute(typeof(DocTitleUserFilter.DocTitleUserFilterMetadata))]
    public partial class DocTitleUserFilter
    {

        // This class allows you to attach custom attributes to properties
        // of the DocTitleUserFilter class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DocTitleUserFilterMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DocTitleUserFilterMetadata()
            {
            }

            public int TitleId { get; set; }

            public int UserId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DocTreeMetadata as the class
    // that carries additional metadata for the DocTree class.
    [MetadataTypeAttribute(typeof(DocTree.DocTreeMetadata))]
    public partial class DocTree
    {

        // This class allows you to attach custom attributes to properties
        // of the DocTree class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DocTreeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DocTreeMetadata()
            {
            }

            public string DocEName { get; set; }

            public string DocFName { get; set; }

            public int DocID { get; set; }

            public int DocParentID { get; set; }

            public int FieldId { get; set; }

            public int ProjectID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies EskelehStrucTypeMetadata as the class
    // that carries additional metadata for the EskelehStrucType class.
    [MetadataTypeAttribute(typeof(EskelehStrucType.EskelehStrucTypeMetadata))]
    public partial class EskelehStrucType
    {

        // This class allows you to attach custom attributes to properties
        // of the EskelehStrucType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class EskelehStrucTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private EskelehStrucTypeMetadata()
            {
            }

            public int ID { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ICOPMAS_AttachMetadata as the class
    // that carries additional metadata for the ICOPMAS_Attach class.
    [MetadataTypeAttribute(typeof(ICOPMAS_Attach.ICOPMAS_AttachMetadata))]
    public partial class ICOPMAS_Attach
    {

        // This class allows you to attach custom attributes to properties
        // of the ICOPMAS_Attach class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ICOPMAS_AttachMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ICOPMAS_AttachMetadata()
            {
            }

            public string FileExt { get; set; }

            public string FileName { get; set; }

            public string FilePath { get; set; }

            public int ICOPID { get; set; }

            public ICOPMAS_Spec ICOPMAS_Spec { get; set; }

            public int ID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ICOPMAS_KeywordMetadata as the class
    // that carries additional metadata for the ICOPMAS_Keyword class.
    [MetadataTypeAttribute(typeof(ICOPMAS_Keyword.ICOPMAS_KeywordMetadata))]
    public partial class ICOPMAS_Keyword
    {

        // This class allows you to attach custom attributes to properties
        // of the ICOPMAS_Keyword class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ICOPMAS_KeywordMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ICOPMAS_KeywordMetadata()
            {
            }

            public int ICOPID { get; set; }

            public ICOPMAS_Spec ICOPMAS_Spec { get; set; }

            public int ID { get; set; }

            public string Keyword { get; set; }

            public string Keyword_En { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ICOPMAS_SeasonMetadata as the class
    // that carries additional metadata for the ICOPMAS_Season class.
    [MetadataTypeAttribute(typeof(ICOPMAS_Season.ICOPMAS_SeasonMetadata))]
    public partial class ICOPMAS_Season
    {

        // This class allows you to attach custom attributes to properties
        // of the ICOPMAS_Season class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ICOPMAS_SeasonMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ICOPMAS_SeasonMetadata()
            {
            }

            public EntityCollection<ICOPMAS_Spec> ICOPMAS_Spec { get; set; }

            public int ID { get; set; }

            public string Name { get; set; }

            public Nullable<int> TypeID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ICOPMAS_SpecMetadata as the class
    // that carries additional metadata for the ICOPMAS_Spec class.
    [MetadataTypeAttribute(typeof(ICOPMAS_Spec.ICOPMAS_SpecMetadata))]
    public partial class ICOPMAS_Spec
    {

        // This class allows you to attach custom attributes to properties
        // of the ICOPMAS_Spec class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ICOPMAS_SpecMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ICOPMAS_SpecMetadata()
            {
            }

            public EntityCollection<ICOPMAS_Attach> ICOPMAS_Attach { get; set; }

            public EntityCollection<ICOPMAS_Keyword> ICOPMAS_Keyword { get; set; }

            public ICOPMAS_Season ICOPMAS_Season { get; set; }

            public EntityCollection<ICOPMAS_Writer> ICOPMAS_Writer { get; set; }

            public int ID { get; set; }

            public string Name_En { get; set; }

            public string Name_FA { get; set; }

            public int SeasonID { get; set; }

            public int SubjectID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ICOPMAS_TypeMetadata as the class
    // that carries additional metadata for the ICOPMAS_Type class.
    [MetadataTypeAttribute(typeof(ICOPMAS_Type.ICOPMAS_TypeMetadata))]
    public partial class ICOPMAS_Type
    {

        // This class allows you to attach custom attributes to properties
        // of the ICOPMAS_Type class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ICOPMAS_TypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ICOPMAS_TypeMetadata()
            {
            }

            public int ID { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ICOPMAS_WriterMetadata as the class
    // that carries additional metadata for the ICOPMAS_Writer class.
    [MetadataTypeAttribute(typeof(ICOPMAS_Writer.ICOPMAS_WriterMetadata))]
    public partial class ICOPMAS_Writer
    {

        // This class allows you to attach custom attributes to properties
        // of the ICOPMAS_Writer class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ICOPMAS_WriterMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ICOPMAS_WriterMetadata()
            {
            }

            public int ICOPID { get; set; }

            public ICOPMAS_Spec ICOPMAS_Spec { get; set; }

            public int ID { get; set; }

            public string WriterName { get; set; }

            public string WriterName_En { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies KeyWordListMetadata as the class
    // that carries additional metadata for the KeyWordList class.
    [MetadataTypeAttribute(typeof(KeyWordList.KeyWordListMetadata))]
    public partial class KeyWordList
    {

        // This class allows you to attach custom attributes to properties
        // of the KeyWordList class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class KeyWordListMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private KeyWordListMetadata()
            {
            }

            public int FieldId { get; set; }

            public int Id { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Log_UserActionMetadata as the class
    // that carries additional metadata for the Log_UserAction class.
    [MetadataTypeAttribute(typeof(Log_UserAction.Log_UserActionMetadata))]
    public partial class Log_UserAction
    {

        // This class allows you to attach custom attributes to properties
        // of the Log_UserAction class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Log_UserActionMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Log_UserActionMetadata()
            {
            }

            public DateTime ActionDate { get; set; }

            public string ActionDesc { get; set; }

            public string ActionType { get; set; }

            public string ApplicationName { get; set; }

            public int ID { get; set; }

            public int UserID { get; set; }

            public string UserName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Log_UserInOutMetadata as the class
    // that carries additional metadata for the Log_UserInOut class.
    [MetadataTypeAttribute(typeof(Log_UserInOut.Log_UserInOutMetadata))]
    public partial class Log_UserInOut
    {

        // This class allows you to attach custom attributes to properties
        // of the Log_UserInOut class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Log_UserInOutMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Log_UserInOutMetadata()
            {
            }

            public string ApplicationName { get; set; }

            public int ID { get; set; }

            public Nullable<DateTime> InTime { get; set; }

            public string IP { get; set; }

            public Nullable<DateTime> OutTime { get; set; }

            public int UserID { get; set; }

            public string UserName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies MembershipsMetadata as the class
    // that carries additional metadata for the Memberships class.
    [MetadataTypeAttribute(typeof(Memberships.MembershipsMetadata))]
    public partial class Memberships
    {

        // This class allows you to attach custom attributes to properties
        // of the Memberships class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class MembershipsMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private MembershipsMetadata()
            {
            }

            public Guid ApplicationId { get; set; }

            public Applications Applications { get; set; }

            public string Comment { get; set; }

            public DateTime CreateDate { get; set; }

            public string Email { get; set; }

            public int FailedPasswordAnswerAttemptCount { get; set; }

            public DateTime FailedPasswordAnswerAttemptWindowsStart { get; set; }

            public int FailedPasswordAttemptCount { get; set; }

            public DateTime FailedPasswordAttemptWindowStart { get; set; }

            public bool IsApproved { get; set; }

            public bool IsLockedOut { get; set; }

            public DateTime LastLockoutDate { get; set; }

            public DateTime LastLoginDate { get; set; }

            public DateTime LastPasswordChangedDate { get; set; }

            public string Password { get; set; }

            public string PasswordAnswer { get; set; }

            public int PasswordFormat { get; set; }

            public string PasswordQuestion { get; set; }

            public string PasswordSalt { get; set; }

            public Guid UserId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Mojavez_AttachMetadata as the class
    // that carries additional metadata for the Mojavez_Attach class.
    [MetadataTypeAttribute(typeof(Mojavez_Attach.Mojavez_AttachMetadata))]
    public partial class Mojavez_Attach
    {

        // This class allows you to attach custom attributes to properties
        // of the Mojavez_Attach class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Mojavez_AttachMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Mojavez_AttachMetadata()
            {
            }

            public int AttachID { get; set; }

            public string Ferestandeh { get; set; }

            public int FieldId { get; set; }

            public string Girandeh { get; set; }

            public string Keywords { get; set; }

            public string LetterDate { get; set; }

            public string LetterNo { get; set; }

            public int PlanID { get; set; }

            public string RegDate { get; set; }

            public string RegNo { get; set; }

            public string RelatedDocs { get; set; }

            public string Subject { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Mojavez_Attach_FilesMetadata as the class
    // that carries additional metadata for the Mojavez_Attach_Files class.
    [MetadataTypeAttribute(typeof(Mojavez_Attach_Files.Mojavez_Attach_FilesMetadata))]
    public partial class Mojavez_Attach_Files
    {

        // This class allows you to attach custom attributes to properties
        // of the Mojavez_Attach_Files class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Mojavez_Attach_FilesMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Mojavez_Attach_FilesMetadata()
            {
            }

            public int AttachID { get; set; }

            public int FileID { get; set; }

            public string FileName { get; set; }

            public string FilePath { get; set; }

            public int PlanID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Mojavez_DocTypeMetadata as the class
    // that carries additional metadata for the Mojavez_DocType class.
    [MetadataTypeAttribute(typeof(Mojavez_DocType.Mojavez_DocTypeMetadata))]
    public partial class Mojavez_DocType
    {

        // This class allows you to attach custom attributes to properties
        // of the Mojavez_DocType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Mojavez_DocTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Mojavez_DocTypeMetadata()
            {
            }

            public int FieldId { get; set; }

            public int Id { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Mojavez_DocTypeRelationMetadata as the class
    // that carries additional metadata for the Mojavez_DocTypeRelation class.
    [MetadataTypeAttribute(typeof(Mojavez_DocTypeRelation.Mojavez_DocTypeRelationMetadata))]
    public partial class Mojavez_DocTypeRelation
    {

        // This class allows you to attach custom attributes to properties
        // of the Mojavez_DocTypeRelation class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Mojavez_DocTypeRelationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Mojavez_DocTypeRelationMetadata()
            {
            }

            public int DocTypeId { get; set; }

            public int FieldId { get; set; }

            public int Id { get; set; }

            public int RequestTypeId { get; set; }

            public int UsageTypeId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Mojavez_PlanDocMetadata as the class
    // that carries additional metadata for the Mojavez_PlanDoc class.
    [MetadataTypeAttribute(typeof(Mojavez_PlanDoc.Mojavez_PlanDocMetadata))]
    public partial class Mojavez_PlanDoc
    {

        // This class allows you to attach custom attributes to properties
        // of the Mojavez_PlanDoc class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Mojavez_PlanDocMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Mojavez_PlanDocMetadata()
            {
            }

            public Nullable<int> DocId { get; set; }

            public string FileDesc { get; set; }

            public string FileName { get; set; }

            public int Id { get; set; }

            public Nullable<bool> NoNeed { get; set; }

            public int PlanId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Mojavez_PlanSpecMetadata as the class
    // that carries additional metadata for the Mojavez_PlanSpec class.
    [MetadataTypeAttribute(typeof(Mojavez_PlanSpec.Mojavez_PlanSpecMetadata))]
    public partial class Mojavez_PlanSpec
    {

        // This class allows you to attach custom attributes to properties
        // of the Mojavez_PlanSpec class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Mojavez_PlanSpecMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Mojavez_PlanSpecMetadata()
            {
            }

            public Nullable<bool> AbandaziExist { get; set; }

            public string AbandaziType { get; set; }

            public string Address { get; set; }

            public string Consultant { get; set; }

            public Nullable<bool> DockExist { get; set; }

            public Nullable<double> DockHeight { get; set; }

            public Nullable<double> DockLen { get; set; }

            public Nullable<double> DockWidth { get; set; }

            public Nullable<double> DolphinExist { get; set; }

            public Nullable<double> DolphinHeight { get; set; }

            public Nullable<double> DolphinLen { get; set; }

            public Nullable<double> DolphinWidth { get; set; }

            public Nullable<double> E1 { get; set; }

            public Nullable<double> E2 { get; set; }

            public Nullable<double> E3 { get; set; }

            public string Email { get; set; }

            public Nullable<double> EskelehDepth { get; set; }

            public Nullable<bool> EskelehExist { get; set; }

            public Nullable<double> EskelehLen { get; set; }

            public Nullable<double> EskelehWidth { get; set; }

            public Nullable<double> EstehsalArea { get; set; }

            public Nullable<bool> EstehsalExist { get; set; }

            public Nullable<double> EstehsalLen { get; set; }

            public Nullable<double> EstehsalWidth { get; set; }

            public string Fax { get; set; }

            public string Field { get; set; }

            public int FieldId { get; set; }

            public string Grade { get; set; }

            public int Id { get; set; }

            public string InvestAmount { get; set; }

            public Nullable<bool> IsClosed { get; set; }

            public Nullable<bool> LairoobiExist { get; set; }

            public Nullable<double> LairoobiVol { get; set; }

            public string ManagerEmail { get; set; }

            public string ManagerMobile { get; set; }

            public string ManagerName { get; set; }

            public Nullable<bool> MojShekanExist { get; set; }

            public Nullable<double> MojShekanMainLen { get; set; }

            public Nullable<double> MojShekanSubLen { get; set; }

            public Nullable<double> N1 { get; set; }

            public Nullable<double> N2 { get; set; }

            public Nullable<double> N3 { get; set; }

            public string Name { get; set; }

            public Nullable<int> OstanId { get; set; }

            public string ParvandehNo { get; set; }

            public Nullable<int> PersonelCount { get; set; }

            public string Phone { get; set; }

            public string PlanGoals { get; set; }

            public bool PlanGoalsAttached { get; set; }

            public string PlanSummary { get; set; }

            public bool PlanSummaryAttached { get; set; }

            public string RegisterDate { get; set; }

            public string Requester { get; set; }

            public string RequesterAddress { get; set; }

            public Nullable<bool> SakooExist { get; set; }

            public Nullable<double> SakooLen { get; set; }

            public Nullable<double> SakooWidth { get; set; }

            public Nullable<bool> SayerExist { get; set; }

            public string SayerProp { get; set; }

            public Nullable<int> ShahrestanId { get; set; }

            public Nullable<double> ShenavarAbkhor { get; set; }

            public Nullable<double> ShenavarLen { get; set; }

            public Nullable<double> ShenavarMaxCapacity { get; set; }

            public string ShenavarType { get; set; }

            public Nullable<double> ShenavarWidth { get; set; }

            public string WebSite { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Mojavez_RequestTypeMetadata as the class
    // that carries additional metadata for the Mojavez_RequestType class.
    [MetadataTypeAttribute(typeof(Mojavez_RequestType.Mojavez_RequestTypeMetadata))]
    public partial class Mojavez_RequestType
    {

        // This class allows you to attach custom attributes to properties
        // of the Mojavez_RequestType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Mojavez_RequestTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Mojavez_RequestTypeMetadata()
            {
            }

            public int FieldId { get; set; }

            public int Id { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Mojavez_UsageTypeMetadata as the class
    // that carries additional metadata for the Mojavez_UsageType class.
    [MetadataTypeAttribute(typeof(Mojavez_UsageType.Mojavez_UsageTypeMetadata))]
    public partial class Mojavez_UsageType
    {

        // This class allows you to attach custom attributes to properties
        // of the Mojavez_UsageType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Mojavez_UsageTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Mojavez_UsageTypeMetadata()
            {
            }

            public int FieldId { get; set; }

            public int Id { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies MojshekanStrucTypeMetadata as the class
    // that carries additional metadata for the MojshekanStrucType class.
    [MetadataTypeAttribute(typeof(MojshekanStrucType.MojshekanStrucTypeMetadata))]
    public partial class MojshekanStrucType
    {

        // This class allows you to attach custom attributes to properties
        // of the MojshekanStrucType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class MojshekanStrucTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private MojshekanStrucTypeMetadata()
            {
            }

            public int ID { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies OrganizationsMetadata as the class
    // that carries additional metadata for the Organizations class.
    [MetadataTypeAttribute(typeof(Organizations.OrganizationsMetadata))]
    public partial class Organizations
    {

        // This class allows you to attach custom attributes to properties
        // of the Organizations class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class OrganizationsMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private OrganizationsMetadata()
            {
            }

            public int ID { get; set; }

            public string NameEn { get; set; }

            public string NameFa { get; set; }

            public EntityCollection<SpatialServices> SpatialServices { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies OstanMetadata as the class
    // that carries additional metadata for the Ostan class.
    [MetadataTypeAttribute(typeof(Ostan.OstanMetadata))]
    public partial class Ostan
    {

        // This class allows you to attach custom attributes to properties
        // of the Ostan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class OstanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private OstanMetadata()
            {
            }

            public EntityCollection<DocSubjectTree> DocSubjectTree { get; set; }

            public int ID { get; set; }

            public string OSTAN_ENG { get; set; }

            public string OSTAN_NAM { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ParamDefinitionMetadata as the class
    // that carries additional metadata for the ParamDefinition class.
    [MetadataTypeAttribute(typeof(ParamDefinition.ParamDefinitionMetadata))]
    public partial class ParamDefinition
    {

        // This class allows you to attach custom attributes to properties
        // of the ParamDefinition class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ParamDefinitionMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ParamDefinitionMetadata()
            {
            }

            public int FieldId { get; set; }

            public string ParameterDesc { get; set; }

            public int ParameterID { get; set; }

            public string ParameterValue { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PortEskelehMetadata as the class
    // that carries additional metadata for the PortEskeleh class.
    [MetadataTypeAttribute(typeof(PortEskeleh.PortEskelehMetadata))]
    public partial class PortEskeleh
    {

        // This class allows you to attach custom attributes to properties
        // of the PortEskeleh class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PortEskelehMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PortEskelehMetadata()
            {
            }

            public Nullable<int> BolardCount { get; set; }

            public Nullable<double> Capacity { get; set; }

            public Nullable<double> Depth { get; set; }

            public int EskelehID { get; set; }

            public string EskelehNo { get; set; }

            public Nullable<int> FenderCount { get; set; }

            public Nullable<double> Len { get; set; }

            public int PortID { get; set; }

            public Nullable<int> StructureTypeID { get; set; }

            public string UseType { get; set; }

            public Nullable<double> Width { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PortInfoMetadata as the class
    // that carries additional metadata for the PortInfo class.
    [MetadataTypeAttribute(typeof(PortInfo.PortInfoMetadata))]
    public partial class PortInfo
    {

        // This class allows you to attach custom attributes to properties
        // of the PortInfo class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PortInfoMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PortInfoMetadata()
            {
            }

            public Nullable<bool> Active { get; set; }

            public string Comment { get; set; }

            public Nullable<bool> Deactive { get; set; }

            public Nullable<double> E { get; set; }

            public string EndUser { get; set; }

            public Nullable<int> MadeYear { get; set; }

            public Nullable<double> N { get; set; }

            public string Owner { get; set; }

            public int PortID { get; set; }

            public Nullable<int> UseTypeID { get; set; }

            public Nullable<int> UseYear { get; set; }

            public string Vagozari { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PortMojshekanMetadata as the class
    // that carries additional metadata for the PortMojshekan class.
    [MetadataTypeAttribute(typeof(PortMojshekan.PortMojshekanMetadata))]
    public partial class PortMojshekan
    {

        // This class allows you to attach custom attributes to properties
        // of the PortMojshekan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PortMojshekanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PortMojshekanMetadata()
            {
            }

            public string ChannelDepth { get; set; }

            public string ChannelLen { get; set; }

            public string Coordinates { get; set; }

            public Nullable<double> LangargahDepth { get; set; }

            public Nullable<bool> Liroobi { get; set; }

            public Nullable<double> MainLen { get; set; }

            public string NeededLiroobi { get; set; }

            public Nullable<double> PoolArea { get; set; }

            public Nullable<double> PoolDiameter { get; set; }

            public int PortID { get; set; }

            public string Signs { get; set; }

            public Nullable<int> StructureTypeID { get; set; }

            public Nullable<double> SubLen { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PortSpecMetadata as the class
    // that carries additional metadata for the PortSpec class.
    [MetadataTypeAttribute(typeof(PortSpec.PortSpecMetadata))]
    public partial class PortSpec
    {

        // This class allows you to attach custom attributes to properties
        // of the PortSpec class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PortSpecMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PortSpecMetadata()
            {
            }

            public Nullable<double> DistToLocation { get; set; }

            public string FillDate { get; set; }

            public string Location { get; set; }

            public Nullable<bool> LocInKhalij { get; set; }

            public Nullable<bool> LocInKhor { get; set; }

            public Nullable<bool> LocSea { get; set; }

            public int PortID { get; set; }

            public Nullable<int> RoadTypeID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PortStructureMetadata as the class
    // that carries additional metadata for the PortStructure class.
    [MetadataTypeAttribute(typeof(PortStructure.PortStructureMetadata))]
    public partial class PortStructure
    {

        // This class allows you to attach custom attributes to properties
        // of the PortStructure class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PortStructureMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PortStructureMetadata()
            {
            }

            public Nullable<bool> Ab { get; set; }

            public Nullable<bool> Atashneshani { get; set; }

            public Nullable<double> BackArea { get; set; }

            public Nullable<bool> Bargh { get; set; }

            public Nullable<bool> Borj { get; set; }

            public Nullable<double> CoveredStoreArea { get; set; }

            public Nullable<bool> Fans { get; set; }

            public int FieldId { get; set; }

            public Nullable<bool> Harigh { get; set; }

            public Nullable<bool> Hesar { get; set; }

            public Nullable<bool> Marz { get; set; }

            public Nullable<bool> Negahbani { get; set; }

            public Nullable<double> OfficialArea { get; set; }

            public Nullable<double> OpenStoredArea { get; set; }

            public Nullable<bool> Payaneh { get; set; }

            public Nullable<int> PortID { get; set; }

            public Nullable<bool> Restooran { get; set; }

            public Nullable<bool> Roshanaee { get; set; }

            public Nullable<double> SiteArea { get; set; }

            public Nullable<bool> TajhizatDarya { get; set; }

            public Nullable<bool> TajhizatKhoshki { get; set; }

            public Nullable<bool> TajhizatMokhaberat { get; set; }

            public Nullable<bool> Tamirgah { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ProfilesMetadata as the class
    // that carries additional metadata for the Profiles class.
    [MetadataTypeAttribute(typeof(Profiles.ProfilesMetadata))]
    public partial class Profiles
    {

        // This class allows you to attach custom attributes to properties
        // of the Profiles class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ProfilesMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ProfilesMetadata()
            {
            }

            public DateTime LastUpdatedDate { get; set; }

            public string PropertyNames { get; set; }

            public byte[] PropertyValueBinary { get; set; }

            public string PropertyValueStrings { get; set; }

            public Guid UserId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ProjectsMetadata as the class
    // that carries additional metadata for the Projects class.
    [MetadataTypeAttribute(typeof(Projects.ProjectsMetadata))]
    public partial class Projects
    {

        // This class allows you to attach custom attributes to properties
        // of the Projects class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ProjectsMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ProjectsMetadata()
            {
            }

            public string BasePath { get; set; }

            public string CnnString { get; set; }

            public string ProjectFile { get; set; }

            public int ProjectID { get; set; }

            public string ProjectName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies RoadTypeMetadata as the class
    // that carries additional metadata for the RoadType class.
    [MetadataTypeAttribute(typeof(RoadType.RoadTypeMetadata))]
    public partial class RoadType
    {

        // This class allows you to attach custom attributes to properties
        // of the RoadType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class RoadTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private RoadTypeMetadata()
            {
            }

            public int ID { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ShahrestanMetadata as the class
    // that carries additional metadata for the Shahrestan class.
    [MetadataTypeAttribute(typeof(Shahrestan.ShahrestanMetadata))]
    public partial class Shahrestan
    {

        // This class allows you to attach custom attributes to properties
        // of the Shahrestan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ShahrestanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ShahrestanMetadata()
            {
            }

            public string BAKHSH_ENG { get; set; }

            public string BAKHSH_NAM { get; set; }

            public int FieldId { get; set; }

            public int ID { get; set; }

            public string OSTAN_ENG { get; set; }

            public Nullable<int> Ostan_Id { get; set; }

            public string OSTAN_NAM { get; set; }

            public string SHAHR_ENG { get; set; }

            public string SHAHR_NAM { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SpatialServicesMetadata as the class
    // that carries additional metadata for the SpatialServices class.
    [MetadataTypeAttribute(typeof(SpatialServices.SpatialServicesMetadata))]
    public partial class SpatialServices
    {

        // This class allows you to attach custom attributes to properties
        // of the SpatialServices class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SpatialServicesMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SpatialServicesMetadata()
            {
            }

            public int ID { get; set; }

            public string Name { get; set; }

            public EntityCollection<Organizations> Organizations { get; set; }

            public string Url { get; set; }

            public Nullable<bool> Visible { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SubjectLinkMetadata as the class
    // that carries additional metadata for the SubjectLink class.
    [MetadataTypeAttribute(typeof(SubjectLink.SubjectLinkMetadata))]
    public partial class SubjectLink
    {

        // This class allows you to attach custom attributes to properties
        // of the SubjectLink class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SubjectLinkMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SubjectLinkMetadata()
            {
            }

            public string LayerName { get; set; }

            public int LinkID { get; set; }

            public int SubjectID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies tblDataTypeMetadata as the class
    // that carries additional metadata for the tblDataType class.
    [MetadataTypeAttribute(typeof(tblDataType.tblDataTypeMetadata))]
    public partial class tblDataType
    {

        // This class allows you to attach custom attributes to properties
        // of the tblDataType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblDataTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private tblDataTypeMetadata()
            {
            }

            public EntityCollection<DocSubjectTree> DocSubjectTree { get; set; }

            public int ID { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies tblInfoTypeMetadata as the class
    // that carries additional metadata for the tblInfoType class.
    [MetadataTypeAttribute(typeof(tblInfoType.tblInfoTypeMetadata))]
    public partial class tblInfoType
    {

        // This class allows you to attach custom attributes to properties
        // of the tblInfoType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblInfoTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private tblInfoTypeMetadata()
            {
            }

            public EntityCollection<DocSubjectTree> DocSubjectTree { get; set; }

            public int ID { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies tblMissionMetadata as the class
    // that carries additional metadata for the tblMission class.
    [MetadataTypeAttribute(typeof(tblMission.tblMissionMetadata))]
    public partial class tblMission
    {

        // This class allows you to attach custom attributes to properties
        // of the tblMission class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblMissionMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private tblMissionMetadata()
            {
            }

            public string Comments { get; set; }

            public string EndDate { get; set; }

            public int LocationID { get; set; }

            public int MissionID { get; set; }

            public string Personel { get; set; }

            public string PreparedBy { get; set; }

            public string Pupose { get; set; }

            public string StartDate { get; set; }

            public string Subject { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies tblOstanMetadata as the class
    // that carries additional metadata for the tblOstan class.
    [MetadataTypeAttribute(typeof(tblOstan.tblOstanMetadata))]
    public partial class tblOstan
    {

        // This class allows you to attach custom attributes to properties
        // of the tblOstan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblOstanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private tblOstanMetadata()
            {
            }

            public int ID { get; set; }

            public string Name_Fa { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies tblPortsMetadata as the class
    // that carries additional metadata for the tblPorts class.
    [MetadataTypeAttribute(typeof(tblPorts.tblPortsMetadata))]
    public partial class tblPorts
    {

        // This class allows you to attach custom attributes to properties
        // of the tblPorts class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblPortsMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private tblPortsMetadata()
            {
            }

            public EntityCollection<DocSubjectTree> DocSubjectTree { get; set; }

            public int ID { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies tblProjectMapMetadata as the class
    // that carries additional metadata for the tblProjectMap class.
    [MetadataTypeAttribute(typeof(tblProjectMap.tblProjectMapMetadata))]
    public partial class tblProjectMap
    {

        // This class allows you to attach custom attributes to properties
        // of the tblProjectMap class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblProjectMapMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private tblProjectMapMetadata()
            {
            }

            public int CPEDPrjID { get; set; }

            public DocTitleTree DocTitleTree { get; set; }

            public int PrjID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies tblUsersMetadata as the class
    // that carries additional metadata for the tblUsers class.
    [MetadataTypeAttribute(typeof(tblUsers.tblUsersMetadata))]
    public partial class tblUsers
    {

        // This class allows you to attach custom attributes to properties
        // of the tblUsers class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class tblUsersMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private tblUsersMetadata()
            {
            }

            public int FieldId { get; set; }

            public string UserID { get; set; }

            public string UserName { get; set; }

            public string UserPass { get; set; }

            public int UsersID { get; set; }

            public Nullable<int> UserTypeID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TitleLocationMetadata as the class
    // that carries additional metadata for the TitleLocation class.
    [MetadataTypeAttribute(typeof(TitleLocation.TitleLocationMetadata))]
    public partial class TitleLocation
    {

        // This class allows you to attach custom attributes to properties
        // of the TitleLocation class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TitleLocationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TitleLocationMetadata()
            {
            }

            public int FieldId { get; set; }

            public int LocationID { get; set; }

            public int TitleID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TitleSpecMetadata as the class
    // that carries additional metadata for the TitleSpec class.
    [MetadataTypeAttribute(typeof(TitleSpec.TitleSpecMetadata))]
    public partial class TitleSpec
    {

        // This class allows you to attach custom attributes to properties
        // of the TitleSpec class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TitleSpecMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TitleSpecMetadata()
            {
            }

            public int FieldId { get; set; }

            public string TitleDesc { get; set; }

            public Nullable<int> TitleID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TreeLayerMetadata as the class
    // that carries additional metadata for the TreeLayer class.
    [MetadataTypeAttribute(typeof(TreeLayer.TreeLayerMetadata))]
    public partial class TreeLayer
    {

        // This class allows you to attach custom attributes to properties
        // of the TreeLayer class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TreeLayerMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TreeLayerMetadata()
            {
            }

            public string Code { get; set; }

            public int FieldId { get; set; }

            public string NameEn { get; set; }

            public string NameFa { get; set; }

            public int OBJECTID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies UserAccessMetadata as the class
    // that carries additional metadata for the UserAccess class.
    [MetadataTypeAttribute(typeof(UserAccess.UserAccessMetadata))]
    public partial class UserAccess
    {

        // This class allows you to attach custom attributes to properties
        // of the UserAccess class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class UserAccessMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private UserAccessMetadata()
            {
            }

            public int AccessTypeID { get; set; }

            public int DocID { get; set; }

            public int FieldId { get; set; }

            public int UsersID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies UsersInRolesMetadata as the class
    // that carries additional metadata for the UsersInRoles class.
    [MetadataTypeAttribute(typeof(UsersInRoles.UsersInRolesMetadata))]
    public partial class UsersInRoles
    {

        // This class allows you to attach custom attributes to properties
        // of the UsersInRoles class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class UsersInRolesMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private UsersInRolesMetadata()
            {
            }

            public Guid RoleId { get; set; }

            public Guid UserId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies UserTypeMetadata as the class
    // that carries additional metadata for the UserType class.
    [MetadataTypeAttribute(typeof(UserType.UserTypeMetadata))]
    public partial class UserType
    {

        // This class allows you to attach custom attributes to properties
        // of the UserType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class UserTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private UserTypeMetadata()
            {
            }

            public int FieldId { get; set; }

            public string UserTypeDesc { get; set; }

            public int UserTypeID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vportMetadata as the class
    // that carries additional metadata for the vport class.
    [MetadataTypeAttribute(typeof(vport.vportMetadata))]
    public partial class vport
    {

        // This class allows you to attach custom attributes to properties
        // of the vport class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vportMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vportMetadata()
            {
            }

            public Nullable<double> DistToLocation { get; set; }

            public string EndUser { get; set; }

            public string Location { get; set; }

            public string Owner { get; set; }

            public int PortID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwAllPlanMetadata as the class
    // that carries additional metadata for the vwAllPlan class.
    [MetadataTypeAttribute(typeof(vwAllPlan.vwAllPlanMetadata))]
    public partial class vwAllPlan
    {

        // This class allows you to attach custom attributes to properties
        // of the vwAllPlan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwAllPlanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwAllPlanMetadata()
            {
            }

            public Nullable<double> E1 { get; set; }

            public Nullable<double> E2 { get; set; }

            public Nullable<double> E3 { get; set; }

            public Nullable<double> N1 { get; set; }

            public Nullable<double> N2 { get; set; }

            public Nullable<double> N3 { get; set; }

            public string شماره_پرونده { get; set; }

            public string کاربری { get; set; }

            public string متقاضی { get; set; }

            public string نام_طرح { get; set; }

            public string نوع_درخواست { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwDocFileListMetadata as the class
    // that carries additional metadata for the vwDocFileList class.
    [MetadataTypeAttribute(typeof(vwDocFileList.vwDocFileListMetadata))]
    public partial class vwDocFileList
    {

        // This class allows you to attach custom attributes to properties
        // of the vwDocFileList class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwDocFileListMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwDocFileListMetadata()
            {
            }

            public int FileID { get; set; }

            public string FullName { get; set; }

            public int TitleId { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwFileListMetadata as the class
    // that carries additional metadata for the vwFileList class.
    [MetadataTypeAttribute(typeof(vwFileList.vwFileListMetadata))]
    public partial class vwFileList
    {

        // This class allows you to attach custom attributes to properties
        // of the vwFileList class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwFileListMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwFileListMetadata()
            {
            }

            public string عنوان_طرح_پروژه { get; set; }

            public string موضوع { get; set; }

            public string نام_فایل { get; set; }

            public string نوع_فایل { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwIcopmasReportMetadata as the class
    // that carries additional metadata for the vwIcopmasReport class.
    [MetadataTypeAttribute(typeof(vwIcopmasReport.vwIcopmasReportMetadata))]
    public partial class vwIcopmasReport
    {

        // This class allows you to attach custom attributes to properties
        // of the vwIcopmasReport class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwIcopmasReportMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwIcopmasReportMetadata()
            {
            }

            public int ID { get; set; }

            public string Keyword_En { get; set; }

            public string Keyword_FA { get; set; }

            public string Name { get; set; }

            public string Name_En { get; set; }

            public string Name_FA { get; set; }

            public string Type { get; set; }

            public Nullable<int> TypeID { get; set; }

            public string Writer_En { get; set; }

            public string Writer_Fa { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwLinkDocsMetadata as the class
    // that carries additional metadata for the vwLinkDocs class.
    [MetadataTypeAttribute(typeof(vwLinkDocs.vwLinkDocsMetadata))]
    public partial class vwLinkDocs
    {

        // This class allows you to attach custom attributes to properties
        // of the vwLinkDocs class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwLinkDocsMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwLinkDocsMetadata()
            {
            }

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

            [Display(AutoGenerateField = false)]
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
        }
    }

    // The MetadataTypeAttribute identifies vwMojavez_AttachMetadata as the class
    // that carries additional metadata for the vwMojavez_Attach class.
    [MetadataTypeAttribute(typeof(vwMojavez_Attach.vwMojavez_AttachMetadata))]
    public partial class vwMojavez_Attach
    {

        // This class allows you to attach custom attributes to properties
        // of the vwMojavez_Attach class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwMojavez_AttachMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwMojavez_AttachMetadata()
            {
            }

            public string FilePath { get; set; }

            public string تاریخ_ثبت { get; set; }

            public string تاریخ_نامه { get; set; }

            public string شماره_ثبت { get; set; }

            public string شماره_نامه { get; set; }

            public string فرستنده { get; set; }

            public int کد_طرح { get; set; }

            public int کد_فایل { get; set; }

            public string کلمات_کلیدی { get; set; }

            public string گیرنده { get; set; }

            public string مستندات_مرتبط { get; set; }

            public string موضوع { get; set; }

            public string نام_فایل { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwMojavezReportMetadata as the class
    // that carries additional metadata for the vwMojavezReport class.
    [MetadataTypeAttribute(typeof(vwMojavezReport.vwMojavezReportMetadata))]
    public partial class vwMojavezReport
    {

        // This class allows you to attach custom attributes to properties
        // of the vwMojavezReport class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwMojavezReportMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwMojavezReportMetadata()
            {
            }

            public int Id { get; set; }

            public string استان { get; set; }

            public string اهداف { get; set; }

            public bool پیوست { get; set; }

            public string حوزه { get; set; }

            public string خلاصه { get; set; }

            public string درخواست_کننده { get; set; }

            public string شماره_پرونده { get; set; }

            public string شهر { get; set; }

            public string کاربری { get; set; }

            public string مشاور { get; set; }

            public string نام { get; set; }

            public string نوع_درخواست { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwPlanReportMetadata as the class
    // that carries additional metadata for the vwPlanReport class.
    [MetadataTypeAttribute(typeof(vwPlanReport.vwPlanReportMetadata))]
    public partial class vwPlanReport
    {

        // This class allows you to attach custom attributes to properties
        // of the vwPlanReport class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwPlanReportMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwPlanReportMetadata()
            {
            }

            public int Id { get; set; }

            public Nullable<bool> IsClosed { get; set; }

            public Nullable<int> Mode { get; set; }

            public string استان { get; set; }

            public string تاریخ_تنظیم { get; set; }

            public string شماره_پرونده { get; set; }

            public string شهرستان { get; set; }

            public string عنوان { get; set; }

            public string متقاضی { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwUsageTypeMetadata as the class
    // that carries additional metadata for the vwUsageType class.
    [MetadataTypeAttribute(typeof(vwUsageType.vwUsageTypeMetadata))]
    public partial class vwUsageType
    {

        // This class allows you to attach custom attributes to properties
        // of the vwUsageType class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwUsageTypeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwUsageTypeMetadata()
            {
            }

            public int Id { get; set; }

            public string Name { get; set; }

            public int ReqID { get; set; }

            public string ReqName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ZoneMetadata as the class
    // that carries additional metadata for the Zone class.
    [MetadataTypeAttribute(typeof(Zone.ZoneMetadata))]
    public partial class Zone
    {

        // This class allows you to attach custom attributes to properties
        // of the Zone class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ZoneMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ZoneMetadata()
            {
            }

            public EntityCollection<DocSubjectTree> DocSubjectTree { get; set; }

            public int ID { get; set; }

            public string Name { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies EmployeesInfoMetadata as the class
    // that carries additional metadata for the EmployeesInfo class.
    [MetadataTypeAttribute(typeof(EmployeesInfo.EmployeesInfoMetadata))]
    public partial class EmployeesInfo
    {

        // This class allows you to attach custom attributes to properties
        // of the EmployeesInfo class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class EmployeesInfoMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private EmployeesInfoMetadata()
            {
            }

            public string Bandar { get; set; }

            public Nullable<DateTime> BirthDate { get; set; }

            public string Birthplace { get; set; }

            public string CodeMelli { get; set; }

            public string DoreAmoozeshi { get; set; }

            public string Edareh { get; set; }

            public string FatherName { get; set; }

            public string FirstName { get; set; }

            public string Gerayesh { get; set; }

            public string HomeTel { get; set; }

            public int ID { get; set; }

            public string LastName { get; set; }

            public string Madrak { get; set; }

            public string MadrakPicture { get; set; }

            public string Maharat { get; set; }

            public string Mobile { get; set; }

            public string NoeGharardad { get; set; }

            public string OrgEmail { get; set; }

            public string PersonalEmail { get; set; }

            public string PersonalPicture { get; set; }

            public string PersonelID { get; set; }

            public string Reshte { get; set; }

            public Nullable<double> SabeghehKar { get; set; }

            public Nullable<double> SabeghehSazman { get; set; }

            public Nullable<double> SabegheMohandesiSavahel { get; set; }

            public Nullable<int> SaleMadrak { get; set; }

            public Nullable<int> SaleShoroo { get; set; }

            public string Universty { get; set; }

            public string WorkTel { get; set; }

            public string Zaban { get; set; }
        }
    }
}
