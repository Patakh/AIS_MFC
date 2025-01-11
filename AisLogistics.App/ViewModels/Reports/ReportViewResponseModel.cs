using System.Collections;

namespace AisLogistics.App.ViewModels.Reports
{
    public class ReportViewResponseModel
    {
        public ReportViewResponseModel() {
            //DataList = new List<object>();
        }
        public IList? DataList { get; set; }
        public string Data { get; set; }
    }
}
