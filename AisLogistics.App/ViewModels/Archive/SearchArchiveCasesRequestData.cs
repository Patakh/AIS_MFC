using AisLogistics.App.ViewModels.Cases;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.ViewModels.Archive
{
    public class SearchArchiveCasesResponseData : SearchArchiveCasesRequestData
    {
        public SelectList OfficesList { get; internal set; }
        public SelectList ServicesList { get; internal set; }
    }

    /// <summary>
    /// Данные запроса поиска обращения
    /// </summary>
    public class SearchArchiveCasesRequestData
    {
        public SearchArchiveCasesRequestData()
        {

        }
        public int CustomerType { get; set; }
        public string CustomerNameLegal { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string CustomerName { get; set; }
        public string Snils { get; set; }
        public string Inn { get; set; }
        public string Serial { get; set; }
        public string Number { get; set; }
        public string Phone { get; set; }
        public int? Year { get; set; }
        public Guid? OfficeId { get; set; }
        public Guid? ServiceId { get; set; }
    }
}
