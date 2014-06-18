
namespace LanSysWebGIS.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies DetailsOfCO2Metadata as the class
    // that carries additional metadata for the DetailsOfCO2 class.
    [MetadataTypeAttribute(typeof(DetailsOfCO2.DetailsOfCO2Metadata))]
    public partial class DetailsOfCO2
    {

        // This class allows you to attach custom attributes to properties
        // of the DetailsOfCO2 class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DetailsOfCO2Metadata
        {

            // Metadata classes are not meant to be instantiated.
            private DetailsOfCO2Metadata()
            {
            }

            public Nullable<double> AmountOfInjection { get; set; }

            public Nullable<double> BoundMaxLatitude { get; set; }

            public Nullable<double> BoundMaxLongitude { get; set; }

            public Nullable<double> BoundMinLatitude { get; set; }

            public Nullable<double> BoundMinLongitude { get; set; }

            public string ContractingParty { get; set; }

            public Nullable<double> CumulativeStorage { get; set; }

            public Nullable<DateTime> DataOfLastMonitoringReport { get; set; }

            public Nullable<DateTime> DateOfFirstInjection { get; set; }

            public Nullable<DateTime> DateOfLastInjection { get; set; }

            public Nullable<DateTime> DateOfReporting { get; set; }

            [Include]
            [ForeignKey("hyd.DetailsOfCO2Chamical")]
            public EntityCollection<DetailsOfCO2Chamical> DetailsOfCO2Chamical { get; set; }

            [Include]
            [ForeignKey("hyd.DetailsOfCO2InjectionWell")]
            public EntityCollection<DetailsOfCO2InjectionWell> DetailsOfCO2InjectionWell { get; set; }

            public int Id { get; set; }

            public Nullable<double> LCLPIDSiteNumber { get; set; }

            public Nullable<double> MaxStorageDepth { get; set; }

            public Nullable<double> MinStorageDepth { get; set; }

            public string NameOfStorageProject { get; set; }

            public Nullable<double> ReportingYear { get; set; }

            public string SummaryOfMonitoring { get; set; }

            public string TypeOfGeologicalFormation { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DetailsOfCO2ChamicalMetadata as the class
    // that carries additional metadata for the DetailsOfCO2Chamical class.
    [MetadataTypeAttribute(typeof(DetailsOfCO2Chamical.DetailsOfCO2ChamicalMetadata))]
    public partial class DetailsOfCO2Chamical
    {

        // This class allows you to attach custom attributes to properties
        // of the DetailsOfCO2Chamical class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DetailsOfCO2ChamicalMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DetailsOfCO2ChamicalMetadata()
            {
            }

            public string Compound { get; set; }

            public DetailsOfCO2 DetailsOfCO2 { get; set; }

            public int DetailsOfCO2Id { get; set; }

            public int Id { get; set; }

            public Nullable<double> PercentOfStream { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DetailsOfCO2InjectionWellMetadata as the class
    // that carries additional metadata for the DetailsOfCO2InjectionWell class.
    [MetadataTypeAttribute(typeof(DetailsOfCO2InjectionWell.DetailsOfCO2InjectionWellMetadata))]
    public partial class DetailsOfCO2InjectionWell
    {

        // This class allows you to attach custom attributes to properties
        // of the DetailsOfCO2InjectionWell class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DetailsOfCO2InjectionWellMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DetailsOfCO2InjectionWellMetadata()
            {
            }

            public DetailsOfCO2 DetailsOfCO2 { get; set; }

            public int DetailsOfCO2Id { get; set; }

            public int Id { get; set; }

            public string InjectionWell { get; set; }

            public Nullable<bool> IsActive { get; set; }

            public Nullable<double> Latitude { get; set; }

            public Nullable<double> Longitude { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies DetailsOfDepositMetadata as the class
    // that carries additional metadata for the DetailsOfDeposit class.
    [MetadataTypeAttribute(typeof(DetailsOfDeposit.DetailsOfDepositMetadata))]
    public partial class DetailsOfDeposit
    {

        // This class allows you to attach custom attributes to properties
        // of the DetailsOfDeposit class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class DetailsOfDepositMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private DetailsOfDepositMetadata()
            {
            }

            public string BulkyWaste { get; set; }

            public string CarbonDioxide { get; set; }

            public string DepositSite { get; set; }

            public string DredgedMaterial { get; set; }

            public string FishWaste { get; set; }

            public int Id { get; set; }

            public string InertMaterial { get; set; }

            public Nullable<bool> IsActive { get; set; }

            public Nullable<double> Latitude { get; set; }

            public Nullable<double> Longitude { get; set; }

            public string Notes { get; set; }

            public string OperationTypeCapital { get; set; }

            public string OperationTypeMaintanance { get; set; }

            public string OrganicMaterial { get; set; }

            public string OriginNameOfWaterSystem { get; set; }

            public string Platforms { get; set; }

            public string Sewage { get; set; }

            public string TotalQuantityDryWeight { get; set; }

            public string TotalQuantityNumber { get; set; }

            public string Vessel { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies MashinAlatVaTajhizatMetadata as the class
    // that carries additional metadata for the MashinAlatVaTajhizat class.
    [MetadataTypeAttribute(typeof(MashinAlatVaTajhizat.MashinAlatVaTajhizatMetadata))]
    public partial class MashinAlatVaTajhizat
    {

        // This class allows you to attach custom attributes to properties
        // of the MashinAlatVaTajhizat class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class MashinAlatVaTajhizatMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private MashinAlatVaTajhizatMetadata()
            {
            }

            public int Id { get; set; }

            public Nullable<bool> IsAmadeBeKar { get; set; }

            public Nullable<bool> IsEstijari { get; set; }

            public Nullable<bool> IsMashgoolBeKar { get; set; }

            public Nullable<bool> IsMelki { get; set; }

            public string Molahezat { get; set; }

            public string NameMashinYaTajhiz { get; set; }

            public Peymankar Peymankar { get; set; }

            public Nullable<int> PeymankarId { get; set; }

            public Nullable<double> SaleSakht { get; set; }

            public Nullable<double> ShomareSafePorseshName { get; set; }

            public Nullable<DateTime> TarikhErsalForm { get; set; }

            public Nullable<double> TedadSafehayePorseshName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PersonsMetadata as the class
    // that carries additional metadata for the Persons class.
    [MetadataTypeAttribute(typeof(Persons.PersonsMetadata))]
    public partial class Persons
    {

        // This class allows you to attach custom attributes to properties
        // of the Persons class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PersonsMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PersonsMetadata()
            {
            }

            public string Daneshgah { get; set; }

            public string DarsadSahm { get; set; }

            public int Id { get; set; }

            public string IsMortabet { get; set; }

            public string Keshvar { get; set; }

            public string KodeMelli { get; set; }

            public string KodeSherkat { get; set; }

            public Nullable<double> MablagSahm { get; set; }

            public string MadrakTahsili { get; set; }

            public string Nam { get; set; }

            public string NameKhanevadegi { get; set; }

            public string NamePedar { get; set; }

            [Include]
            [ForeignKey("hyd.PersonsSavabeg")]
            public EntityCollection<PersonsSavabeg> PersonsSavabeg { get; set; }

            public Peymankar Peymankar { get; set; }

            public Nullable<int> PeymankarId { get; set; }

            public string ReshteyeTahsili { get; set; }

            public Nullable<double> SaleAkhz { get; set; }

            public string Semat { get; set; }

            public string ShomarePerseneli { get; set; }

            public Nullable<double> ShomareSafePorseshName { get; set; }

            public string ShomareShenasname { get; set; }

            public Nullable<int> TajrobeSanavati { get; set; }

            public Nullable<DateTime> TarikhErsalForm { get; set; }

            public Nullable<double> TedadeSahm { get; set; }

            public Nullable<double> TedadSafehayePorseshName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PersonsSavabegMetadata as the class
    // that carries additional metadata for the PersonsSavabeg class.
    [MetadataTypeAttribute(typeof(PersonsSavabeg.PersonsSavabegMetadata))]
    public partial class PersonsSavabeg
    {

        // This class allows you to attach custom attributes to properties
        // of the PersonsSavabeg class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PersonsSavabegMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PersonsSavabegMetadata()
            {
            }

            public Nullable<DateTime> AzTarikhe { get; set; }

            public int Id { get; set; }

            public Nullable<double> Modat { get; set; }

            public string MozooeKar { get; set; }

            public string NameDastgah { get; set; }

            public Nullable<int> PersonId { get; set; }

            public Persons Persons { get; set; }

            public string Semat { get; set; }

            public Nullable<double> ShomareSafePorseshName { get; set; }

            public Nullable<DateTime> TarikhErsalForm { get; set; }

            public Nullable<DateTime> TaTarikhe { get; set; }

            public Nullable<double> TedadSafehayePorseshName { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PeymanhaMetadata as the class
    // that carries additional metadata for the Peymanha class.
    [MetadataTypeAttribute(typeof(Peymanha.PeymanhaMetadata))]
    public partial class Peymanha
    {

        // This class allows you to attach custom attributes to properties
        // of the Peymanha class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PeymanhaMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PeymanhaMetadata()
            {
            }

            public int Id { get; set; }

            public Nullable<double> MablagePeyman { get; set; }

            public Nullable<DateTime> MablageSooratVaziat { get; set; }

            public string MahalEjra { get; set; }

            public string MozooePeyman { get; set; }

            public string NameKarfarma { get; set; }

            public Peymankar Peymankar { get; set; }

            public Nullable<int> PeymankarId { get; set; }

            public Nullable<double> SahmeAmaliyatLayroobi { get; set; }

            public Nullable<double> ShomareSafePorseshName { get; set; }

            public Nullable<DateTime> TarikheDaryaftSooratVaziat { get; set; }

            public Nullable<DateTime> TarikhePayan { get; set; }

            public Nullable<DateTime> TarikhErsalForm { get; set; }

            public Nullable<DateTime> TarikheShoro { get; set; }

            public Nullable<double> TedadSafehayePorseshName { get; set; }

            public string VaziatPeyman { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PeymankarMetadata as the class
    // that carries additional metadata for the Peymankar class.
    [MetadataTypeAttribute(typeof(Peymankar.PeymankarMetadata))]
    public partial class Peymankar
    {

        // This class allows you to attach custom attributes to properties
        // of the Peymankar class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PeymankarMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PeymankarMetadata()
            {
            }

            public Nullable<double> EmtiyazMashinalat { get; set; }

            public Nullable<double> Gardeshmali { get; set; }

            public int Id { get; set; }

            public string KodeSherkat { get; set; }

            public string MahaleSabt { get; set; }

            [Include]
            [ForeignKey("hyd.MashinAlatVaTajhizat")]
            public EntityCollection<MashinAlatVaTajhizat> MashinAlatVaTajhizat { get; set; }

            public string NameGabliPeymankar1 { get; set; }

            public string NameGabliPeymankar2 { get; set; }

            public string NameKamelePeymankar { get; set; }

            public string NeshaniSherkat { get; set; }

            public string NoeMalekiyatDaftarMarkazi { get; set; }

            public string NoeSabt { get; set; }

            [Include]
            [ForeignKey("hyd.Persons")]
            public EntityCollection<Persons> Persons { get; set; }

            [Include]
            [ForeignKey("hyd.Peymanha")]
            public EntityCollection<Peymanha> Peymanha { get; set; }

            public Nullable<double> SatheZirbanayeDaftarMarkazi { get; set; }

            public Nullable<double> ShomareSabt { get; set; }

            public Nullable<double> ShomareSafePorseshName { get; set; }

            public string ShomareTelefonDaftarMarkazi { get; set; }

            public Nullable<DateTime> TarikhErsalForm { get; set; }

            public Nullable<DateTime> TarikhSabt { get; set; }

            public Nullable<DateTime> TarikhTasis { get; set; }

            public Nullable<double> TavanMaliBolandModat { get; set; }

            public Nullable<double> TavanMaliJari { get; set; }

            public Nullable<int> TedadGovahinameha { get; set; }

            public Nullable<double> TedadKarkonanFani { get; set; }

            public Nullable<double> TedadKarkonanKhadamati { get; set; }

            public Nullable<double> TedadKarkonanModir { get; set; }

            public Nullable<double> TedadSafehayePorseshName { get; set; }

            public Nullable<int> TedadSalhayeFaaliyat { get; set; }

            public Nullable<double> TedadShoraka { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ProjectIdentificationMetadata as the class
    // that carries additional metadata for the ProjectIdentification class.
    [MetadataTypeAttribute(typeof(ProjectIdentification.ProjectIdentificationMetadata))]
    public partial class ProjectIdentification
    {

        // This class allows you to attach custom attributes to properties
        // of the ProjectIdentification class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ProjectIdentificationMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ProjectIdentificationMetadata()
            {
            }

            public Nullable<double> bilAbkhorBarj { get; set; }

            public Nullable<double> bilHajmeBucket { get; set; }

            public Nullable<double> bilHajmeMasaleh { get; set; }

            public string bilLayroobMalek { get; set; }

            public Nullable<double> bilMasrafSookht { get; set; }

            public Nullable<double> bilMaxHajmeBucket { get; set; }

            public Nullable<double> bilMaxOmgh { get; set; }

            public string bilNameLayroob { get; set; }

            public Nullable<double> ContractCost { get; set; }

            public Nullable<DateTime> ContractFinishDate { get; set; }

            public Nullable<int> ContractPeriod { get; set; }

            public Nullable<DateTime> ContractStartDate { get; set; }

            public Nullable<double> cutAbkhorLayroob { get; set; }

            public Nullable<double> cutGhodrateCutter { get; set; }

            public Nullable<double> cutGhodratePomp { get; set; }

            public string cutLayroobMalek { get; set; }

            public Nullable<double> cutMaharLangarCount { get; set; }

            public Nullable<double> cutMaharLangarWeight { get; set; }

            public Nullable<double> cutMaharSpad { get; set; }

            public Nullable<double> cutMasrafSookht { get; set; }

            public Nullable<double> cutMaxOmgh { get; set; }

            public Nullable<double> cutMinOmgh { get; set; }

            public string cutNameLayroob { get; set; }

            public string Description { get; set; }

            public Nullable<double> disDaryaFasele { get; set; }

            public Nullable<double> disDaryaLat { get; set; }

            public Nullable<double> disDaryaLong { get; set; }

            public string disDaryaNameMahdoode { get; set; }

            public Nullable<double> disDaryaOmgheMahdoode { get; set; }

            public Nullable<double> disDaryaZaman { get; set; }

            public Nullable<bool> disKhoshkiNiazeTasbit { get; set; }

            public Nullable<double> disKhoshkiNo1Fasele { get; set; }

            public Nullable<double> disKhoshkiNo1Hajm { get; set; }

            public Nullable<double> disKhoshkiNo1Masahat { get; set; }

            public Nullable<double> disKhoshkiNo1Tool { get; set; }

            public Nullable<double> disKhoshkiNo2Fasele { get; set; }

            public Nullable<double> disKhoshkiNo2Hajm { get; set; }

            public Nullable<double> disKhoshkiNo2Masahat { get; set; }

            public Nullable<double> disKhoshkiNo2Tool { get; set; }

            public Nullable<double> disKhoshkiNo3Fasele { get; set; }

            public Nullable<double> disKhoshkiNo3Hajm { get; set; }

            public Nullable<double> disKhoshkiNo3Masahat { get; set; }

            public Nullable<double> disKhoshkiNo3Tool { get; set; }

            public Nullable<double> equCountBilMechanici { get; set; }

            public Nullable<double> equCountBouldoser { get; set; }

            public Nullable<double> equCountDGPS { get; set; }

            public Nullable<double> equCountDiesel { get; set; }

            public Nullable<double> equCountEcosounder { get; set; }

            public Nullable<double> equCountGhayegh { get; set; }

            public Nullable<double> equCountJaresaghil { get; set; }

            public Nullable<double> equCountKamionCompressi { get; set; }

            public Nullable<double> equCountKamionJaresaghildar { get; set; }

            public Nullable<double> equCountKhateLoole { get; set; }

            public Nullable<double> equCountLoader { get; set; }

            public Nullable<double> equCountNivo { get; set; }

            public Nullable<double> equCountRTK { get; set; }

            public Nullable<double> equCountSpeedometer { get; set; }

            public Nullable<double> equCountTankerAb { get; set; }

            public Nullable<double> equCountTankerSookht { get; set; }

            public Nullable<double> equCountTideGuage { get; set; }

            public Nullable<double> equCountTotalStation { get; set; }

            public string geoLayer1AmalkardeLayroob { get; set; }

            public string geoLayer1JenseKhak { get; set; }

            public string geoLayer1LaroobPishnahadi { get; set; }

            public string geoLayer1LayroobeBekarGerefte { get; set; }

            public string geoLayer1SPT { get; set; }

            public Nullable<double> geoLayer1TarazeEbtedaei { get; set; }

            public Nullable<double> geoLayer1TarazeEntehaei { get; set; }

            public Nullable<double> geoLayer1ZekhamatLayer { get; set; }

            public string geoLayer2AmalkardeLayroob { get; set; }

            public string geoLayer2JenseKhak { get; set; }

            public string geoLayer2LaroobPishnahadi { get; set; }

            public string geoLayer2LayroobeBekarGerefte { get; set; }

            public string geoLayer2SPT { get; set; }

            public Nullable<double> geoLayer2TarazeEbtedaei { get; set; }

            public Nullable<double> geoLayer2TarazeEntehaei { get; set; }

            public Nullable<double> geoLayer2ZekhamatLayer { get; set; }

            public string geoLayer3AmalkardeLayroob { get; set; }

            public string geoLayer3JenseKhak { get; set; }

            public string geoLayer3LaroobPishnahadi { get; set; }

            public string geoLayer3LayroobeBekarGerefte { get; set; }

            public string geoLayer3SPT { get; set; }

            public Nullable<double> geoLayer3TarazeEbtedaei { get; set; }

            public Nullable<double> geoLayer3TarazeEntehaei { get; set; }

            public Nullable<double> geoLayer3ZekhamatLayer { get; set; }

            public Nullable<double> HajmeLayroobi { get; set; }

            public Nullable<double> hypAbkhorLayroob { get; set; }

            public Nullable<double> hypHajmeMakhzan { get; set; }

            public string hypLayroobMalek { get; set; }

            public Nullable<double> hypMasrafSookht { get; set; }

            public Nullable<double> hypMaxOmgh { get; set; }

            public string hypNameLayroob { get; set; }

            public int Id { get; set; }

            public Nullable<bool> IsBarjKeshi { get; set; }

            public Nullable<bool> IsBiloBarooj { get; set; }

            public Nullable<bool> IsCanalDastrasi { get; set; }

            public Nullable<bool> IsContineri { get; set; }

            public Nullable<bool> IsCutterSucktion { get; set; }

            public Nullable<bool> IsDarBarejJanebi { get; set; }

            public Nullable<bool> IsEhdasi { get; set; }

            public Nullable<bool> IsFallebar { get; set; }

            public Nullable<bool> IsHozcheAramesh { get; set; }

            public Nullable<bool> IsHyperSucktion { get; set; }

            public Nullable<bool> IsJahateAssemble { get; set; }

            public Nullable<bool> IsKalayeOmomi { get; set; }

            public Nullable<bool> IsLenj { get; set; }

            public Nullable<bool> IsMakhzan { get; set; }

            public Nullable<bool> IsMosaferi { get; set; }

            public Nullable<bool> IsNafti { get; set; }

            public Nullable<bool> IsNaghshebardari { get; set; }

            public Nullable<bool> IsNegahdari { get; set; }

            public Nullable<bool> IsPayeEskele { get; set; }

            public Nullable<bool> IsPomp { get; set; }

            public Nullable<bool> IsTamighi { get; set; }

            public Nullable<bool> IsTavaneJabejaei { get; set; }

            public Nullable<bool> IsYadakKeshi { get; set; }

            public string MahdodeLayroobi { get; set; }

            public string MoshaverName { get; set; }

            public Nullable<double> mulFazayeKhali { get; set; }

            public Nullable<double> mulHajmeMakhzanAb { get; set; }

            public Nullable<double> mulHajmeMakhzanSookht { get; set; }

            public Nullable<double> mulJaresaghil { get; set; }

            public Nullable<double> mulWinch { get; set; }

            public Nullable<double> NesbateTarazBeMLLW { get; set; }

            public Nullable<double> NesbateTarazeCD { get; set; }

            public Nullable<double> OmgheAbkhorShenavareTarh { get; set; }

            public string PeymankarName { get; set; }

            public string ProjectName { get; set; }

            public string ProjectPurpose { get; set; }

            public string ProjectTechSpec { get; set; }

            public Nullable<double> savHajmeAmaliat { get; set; }

            public Nullable<bool> savIsEhdasi { get; set; }

            public Nullable<bool> savIsNegahdari { get; set; }

            public Nullable<bool> savLayroobiGhabli { get; set; }

            public string savMoshakhasateLayroob { get; set; }

            public string savMoshaver { get; set; }

            public string savPeymankar { get; set; }

            public Nullable<double> savSaleLayroobiGhabli { get; set; }

            public byte[] Token { get; set; }

            public Nullable<int> UserId { get; set; }

            public Nullable<double> VosateMahdodeLayroobi { get; set; }

            public Nullable<double> yadAbkhor { get; set; }

            public Nullable<double> yadArz { get; set; }

            public Nullable<double> yadGhodratMotor { get; set; }

            public Nullable<double> yadHajmeMakhzanAb { get; set; }

            public Nullable<double> yadHajmeMakhzanSookht { get; set; }

            public Nullable<double> yadKesheshMaharband { get; set; }

            public Nullable<double> yadTool { get; set; }

            public Nullable<double> ZarfiateShenavareTarh { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SummaryOfPermitsMetadata as the class
    // that carries additional metadata for the SummaryOfPermits class.
    [MetadataTypeAttribute(typeof(SummaryOfPermits.SummaryOfPermitsMetadata))]
    public partial class SummaryOfPermits
    {

        // This class allows you to attach custom attributes to properties
        // of the SummaryOfPermits class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SummaryOfPermitsMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SummaryOfPermitsMetadata()
            {
            }

            public string BNote { get; set; }

            public Nullable<int> BOperation { get; set; }

            public Nullable<int> BPermit { get; set; }

            public Nullable<int> BTonnes { get; set; }

            public string CNote { get; set; }

            public Nullable<int> COperation { get; set; }

            public Nullable<int> CPermit { get; set; }

            public Nullable<int> CTonnes { get; set; }

            public string DNote { get; set; }

            public Nullable<int> DOperation { get; set; }

            public Nullable<int> DPermit { get; set; }

            public Nullable<int> DTonnes { get; set; }

            public string FNote { get; set; }

            public Nullable<int> FOperation { get; set; }

            public Nullable<int> FPermit { get; set; }

            public Nullable<int> FTonnes { get; set; }

            public Nullable<int> Id { get; set; }

            public string INote { get; set; }

            public Nullable<int> IOperation { get; set; }

            public Nullable<int> IPermit { get; set; }

            public Nullable<int> ITonnes { get; set; }

            public string ONote { get; set; }

            public Nullable<int> OOperation { get; set; }

            public Nullable<int> OPermit { get; set; }

            public Nullable<int> OTonnes { get; set; }

            public string PNote { get; set; }

            public Nullable<int> POperation { get; set; }

            public Nullable<int> PPermit { get; set; }

            public Nullable<int> PTonnes { get; set; }

            public string SNote { get; set; }

            public Nullable<int> SOperation { get; set; }

            public Nullable<int> SPermit { get; set; }

            public Nullable<int> STonnes { get; set; }

            public string VNote { get; set; }

            public Nullable<int> VOperation { get; set; }

            public Nullable<int> VPermit { get; set; }

            public Nullable<int> VTonnes { get; set; }

            public Nullable<int> Year { get; set; }
        }
    }
}
