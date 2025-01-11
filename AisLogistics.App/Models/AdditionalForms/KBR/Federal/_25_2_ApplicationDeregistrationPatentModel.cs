using AisLogistics.App.Models.AdditionalForms;
namespace AisLogistics.App.Models;


public sealed class _25_2_ApplicationDeregistrationPatentModel : AbstractAdditionalFormModel
{

    public _25_2_ApplicationDeregistrationPatentModel()
    {
        DataOfPatentList = new[]
        {
            new DataOfPatent()
        };
    }
    public string Code { get; set; }
    public int Justification { get; set; }
    public DateTime? DateOfOccurrenceOfCircumstances {  get; set; }
    public int SheetCount { get; set; }
    public DataOfPatent[] DataOfPatentList { get; set; }
    public class DataOfPatent
    {
        public string Number { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
