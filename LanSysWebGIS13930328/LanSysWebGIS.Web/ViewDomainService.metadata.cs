
namespace LanSysWebGIS.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies vwJamiat_BlockMetadata as the class
    // that carries additional metadata for the vwJamiat_Block class.
    [MetadataTypeAttribute(typeof(vwJamiat_Block.vwJamiat_BlockMetadata))]
    public partial class vwJamiat_Block
    {

        // This class allows you to attach custom attributes to properties
        // of the vwJamiat_Block class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwJamiat_BlockMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwJamiat_BlockMetadata()
            {
            }

            public string Ident { get; set; }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwJamiat_EghamatMetadata as the class
    // that carries additional metadata for the vwJamiat_Eghamat class.
    [MetadataTypeAttribute(typeof(vwJamiat_Eghamat.vwJamiat_EghamatMetadata))]
    public partial class vwJamiat_Eghamat
    {

        // This class allows you to attach custom attributes to properties
        // of the vwJamiat_Eghamat class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwJamiat_EghamatMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwJamiat_EghamatMetadata()
            {
            }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwJamiat_JensiatMetadata as the class
    // that carries additional metadata for the vwJamiat_Jensiat class.
    [MetadataTypeAttribute(typeof(vwJamiat_Jensiat.vwJamiat_JensiatMetadata))]
    public partial class vwJamiat_Jensiat
    {

        // This class allows you to attach custom attributes to properties
        // of the vwJamiat_Jensiat class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwJamiat_JensiatMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwJamiat_JensiatMetadata()
            {
            }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwJamiat_MahaleKarYaTahsilMetadata as the class
    // that carries additional metadata for the vwJamiat_MahaleKarYaTahsil class.
    [MetadataTypeAttribute(typeof(vwJamiat_MahaleKarYaTahsil.vwJamiat_MahaleKarYaTahsilMetadata))]
    public partial class vwJamiat_MahaleKarYaTahsil
    {

        // This class allows you to attach custom attributes to properties
        // of the vwJamiat_MahaleKarYaTahsil class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwJamiat_MahaleKarYaTahsilMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwJamiat_MahaleKarYaTahsilMetadata()
            {
            }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwJamiat_MahaleTavalodMetadata as the class
    // that carries additional metadata for the vwJamiat_MahaleTavalod class.
    [MetadataTypeAttribute(typeof(vwJamiat_MahaleTavalod.vwJamiat_MahaleTavalodMetadata))]
    public partial class vwJamiat_MahaleTavalod
    {

        // This class allows you to attach custom attributes to properties
        // of the vwJamiat_MahaleTavalod class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwJamiat_MahaleTavalodMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwJamiat_MahaleTavalodMetadata()
            {
            }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwJamiat_savadMetadata as the class
    // that carries additional metadata for the vwJamiat_savad class.
    [MetadataTypeAttribute(typeof(vwJamiat_savad.vwJamiat_savadMetadata))]
    public partial class vwJamiat_savad
    {

        // This class allows you to attach custom attributes to properties
        // of the vwJamiat_savad class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwJamiat_savadMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwJamiat_savadMetadata()
            {
            }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwJamiat_ShahrYaDehestanMetadata as the class
    // that carries additional metadata for the vwJamiat_ShahrYaDehestan class.
    [MetadataTypeAttribute(typeof(vwJamiat_ShahrYaDehestan.vwJamiat_ShahrYaDehestanMetadata))]
    public partial class vwJamiat_ShahrYaDehestan
    {

        // This class allows you to attach custom attributes to properties
        // of the vwJamiat_ShahrYaDehestan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwJamiat_ShahrYaDehestanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwJamiat_ShahrYaDehestanMetadata()
            {
            }

            public string Ident { get; set; }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwJamiat_ShoghlMetadata as the class
    // that carries additional metadata for the vwJamiat_Shoghl class.
    [MetadataTypeAttribute(typeof(vwJamiat_Shoghl.vwJamiat_ShoghlMetadata))]
    public partial class vwJamiat_Shoghl
    {

        // This class allows you to attach custom attributes to properties
        // of the vwJamiat_Shoghl class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwJamiat_ShoghlMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwJamiat_ShoghlMetadata()
            {
            }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwJamiat_TaaholMetadata as the class
    // that carries additional metadata for the vwJamiat_Taahol class.
    [MetadataTypeAttribute(typeof(vwJamiat_Taahol.vwJamiat_TaaholMetadata))]
    public partial class vwJamiat_Taahol
    {

        // This class allows you to attach custom attributes to properties
        // of the vwJamiat_Taahol class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwJamiat_TaaholMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwJamiat_TaaholMetadata()
            {
            }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwJamiatKol_SenMetadata as the class
    // that carries additional metadata for the vwJamiatKol_Sen class.
    [MetadataTypeAttribute(typeof(vwJamiatKol_Sen.vwJamiatKol_SenMetadata))]
    public partial class vwJamiatKol_Sen
    {

        // This class allows you to attach custom attributes to properties
        // of the vwJamiatKol_Sen class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwJamiatKol_SenMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwJamiatKol_SenMetadata()
            {
            }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwJamiatMard_SenMetadata as the class
    // that carries additional metadata for the vwJamiatMard_Sen class.
    [MetadataTypeAttribute(typeof(vwJamiatMard_Sen.vwJamiatMard_SenMetadata))]
    public partial class vwJamiatMard_Sen
    {

        // This class allows you to attach custom attributes to properties
        // of the vwJamiatMard_Sen class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwJamiatMard_SenMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwJamiatMard_SenMetadata()
            {
            }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwJamiatZan_SenMetadata as the class
    // that carries additional metadata for the vwJamiatZan_Sen class.
    [MetadataTypeAttribute(typeof(vwJamiatZan_Sen.vwJamiatZan_SenMetadata))]
    public partial class vwJamiatZan_Sen
    {

        // This class allows you to attach custom attributes to properties
        // of the vwJamiatZan_Sen class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwJamiatZan_SenMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwJamiatZan_SenMetadata()
            {
            }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwKhanevar_ShahryaDehestanMetadata as the class
    // that carries additional metadata for the vwKhanevar_ShahryaDehestan class.
    [MetadataTypeAttribute(typeof(vwKhanevar_ShahryaDehestan.vwKhanevar_ShahryaDehestanMetadata))]
    public partial class vwKhanevar_ShahryaDehestan
    {

        // This class allows you to attach custom attributes to properties
        // of the vwKhanevar_ShahryaDehestan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwKhanevar_ShahryaDehestanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwKhanevar_ShahryaDehestanMetadata()
            {
            }

            public string Ident { get; set; }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies vwMasahatZirBanaMetadata as the class
    // that carries additional metadata for the vwMasahatZirBana class.
    [MetadataTypeAttribute(typeof(vwMasahatZirBana.vwMasahatZirBanaMetadata))]
    public partial class vwMasahatZirBana
    {

        // This class allows you to attach custom attributes to properties
        // of the vwMasahatZirBana class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class vwMasahatZirBanaMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private vwMasahatZirBanaMetadata()
            {
            }

            public string X_Value { get; set; }

            public Nullable<double> Y_Value { get; set; }
        }
    }
}
