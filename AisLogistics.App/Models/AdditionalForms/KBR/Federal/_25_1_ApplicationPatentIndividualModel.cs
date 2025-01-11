namespace AisLogistics.App.Models;

public sealed class _25_1_ApplicationPatentIndividualModel : AbstractAdditionalFormModel
{
    public string Code { get; set; }
    public string OgrnIP {  get; set; } 
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public int SheetCount { get; set; }
    public string TypesOfActivities { get; set; }
    public string CodeTypesOfActivity { get; set; }
    public int BusinessdType { get; set; }
    public int AverageNumberOfEmployees { get; set; } = 0;
    public int TaxRate { get; set; }
    public string ReferenceToRuleLaw { get; set; }
    public string SubjectCode { get; set; }
    public string TaxCodeForBusinessActivities { get; set; }
    public string ObjectTypeCode { get; set; }
    public int FeatureOfObject { get; set; }
    public decimal AreaOfObject { get; set; }
    public int CodeSubjectOfRussianFederation { get; set; }
    public int TypeMunicipality { get; set; }
    public string MunicipalityName { get; set; }
    public int TypeSettlement { get; set; }
    public string SettlementName { get; set; }
    public string LocalityType { get; set; }
    public string LocalityName { get; set; }
    public string ElementOfPlanningStructureType { get; set; }
    public string ElementOfPlanningStructureName { get; set; }
    public string ElementOfRoadNetworkType { get; set; }
    public string ElementOfRoadNetworkName { get; set; }
    public string NumberGroundArea { get; set; }
    public string BuildType { get; set; }
    public string BuildNumber { get; set; }
    public string ApartmentsType { get; set; }
    public string ApartmentsNumber { get; set; }
    public string RoomType { get; set; }
    public string RoomNumber { get; set; }
    public string CodeTransport {  get; set; }
    public class Transport
    {
        public string? IdentificationNumber { get; set; }
        public string? Brand { get; set; }
        public string? RegistrationMark { get; set; }
        public string? LoadCapacity { get; set; }
        public string? Number { get; set; }
    }

    public Transport[] TransportInfo { get; set; } = Array.Empty<Transport>();
}