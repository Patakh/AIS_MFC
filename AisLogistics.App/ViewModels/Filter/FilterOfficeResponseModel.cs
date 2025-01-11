namespace AisLogistics.App.ViewModels.Filter
{
    public class FilterOfficeResponseModel
    {
        public FilterOfficeResponseModel() 
        {
            OfficesId = new List<Guid>();
            OfficesName = new List<string>();
        }
        public List<Guid> OfficesId { get; set; }
        public List<string> OfficesName { get; set; }
        public bool IsType { get; set; } 
        public int? TypeId { get; set; }
    }
}
