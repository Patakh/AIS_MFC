using DocumentFormat.OpenXml.Presentation;
using System.ComponentModel.DataAnnotations.Schema;

namespace AisLogistics.App.Models.Reports
{
    public class ReportGeneralCount
    {
        public string out_mfc_name { get; set; }
        public string out_office_name { get; set; }
        public int out_received_count { get; set; }
        public int out_executed_count { get; set; }
        public int out_refusal_count { get; set; }
        public int out_consultation_count { get; set; }
        public int out_error_count { get; set; }
        public int out_issued_count { get; set; }
    }

    public class ReportReestrCount
    {
        public string out_office_name { get; set; }
        public string out_service_name { get; set; }
        public int out_received_count { get; set; }
        public int out_executed_count { get; set; }
        public int out_refusal_count { get; set; }
        public int out_consultation_count { get; set; }
        public int out_error_count { get; set; }
        public int out_issued_count { get; set; }
    }

    public class ReportReestrCountOffice
    {
        public string out_office_name { get; set; }
        public int out_received_count { get; set; }
        public int out_executed_count { get; set; }
        public int out_refusal_count { get; set; }
        public int out_consultation_count { get; set; }
        public int out_error_count { get; set; }
        public int out_issued_count { get; set; }
    }
    public class ReportReestrCountEmployees
    {
        public string out_employee_name { get; set; }
        public int out_received_count { get; set; }
        public int out_executed_count { get; set; }
        public int out_refusal_count { get; set; }
        public int out_consultation_count { get; set; }
        public int out_error_count { get; set; }
        public int out_issued_count { get; set; }
    }
    public class ReestrSmevByRequest
    {
        public string out_smev_name { get; set; }
        public string out_request_name { get; set; }
        public int out_request_count { get; set; }
        public int out_response_count { get; set; }
        public int out_error_count { get; set; }
    }
    public class ReestrSmevByOffice
    {
        public string out_office_name { get; set; }
        public int out_request_count { get; set; }
        public int out_response_count { get; set; }
        public int out_error_count { get; set; }
    }
    public class ReestrSmevByEmployees
    {
        public string out_employee_name { get; set; }
        public int out_request_count { get; set; }
        public int out_response_count { get; set; }
        public int out_error_count { get; set; }
    }
    public class ReportTopEmployees
    {
        public string out_employee_name { get; set; }
        public string out_office_name { get; set; }
        public int out_received_count { get; set; } 
        //public int? out_executed_count { get; set; }
        //public int? out_refusal_count { get; set; }
        public int out_consultation_count { get; set; } 
        //public int? out_error_count { get; set; }
        public int out_issued_count { get; set; } 
    }
    public class ReportSps
    {
        public string office_name { get; set; }
        public int services_count { get; set; }
    }

    public class ReportSpsOffice
    {
        public string service_name { get; set; }
        public int count { get; set; }
    }
}
