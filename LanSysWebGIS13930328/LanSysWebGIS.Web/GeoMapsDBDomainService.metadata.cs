
namespace LanSysWebGIS.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies LayersWithDocMetadata as the class
    // that carries additional metadata for the LayersWithDoc class.
    [MetadataTypeAttribute(typeof(LayersWithDoc.LayersWithDocMetadata))]
    public partial class LayersWithDoc
    {

        // This class allows you to attach custom attributes to properties
        // of the LayersWithDoc class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class LayersWithDocMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private LayersWithDocMetadata()
            {
            }

            public int Id { get; set; }

            public string LayerName { get; set; }
        }
    }
}
