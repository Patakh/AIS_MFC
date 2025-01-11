namespace AisLogistics.App.Models;

/// <summary>
/// Зачисление в образовательное учреждение
public class _28_1_EnrollmentEducationalInstitutionModel
{
    public string ShefFIO { get; set; }
    public string MOUNumber { get; set; }
    public string ChildFIO { get; set; }
    public string ChildBirdsDate { get; set; }
    public string InClass { get; set; }
    public string MOU { get; set; }
    public string DOU { get; set; }
    public string MedicalCard { get; set; }
    public string BirthCertificate { get; set; }
    public string Other { get; set; }
    public Person Mother { get; set; }
    public Person Father { get; set; }
    public class Person
    {
        public string PlaceWork { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
    }

}
