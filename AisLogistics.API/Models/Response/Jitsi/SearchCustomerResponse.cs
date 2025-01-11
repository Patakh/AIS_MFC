using AisLogistics.API.Models.Dto;
using System.Runtime.Serialization;

namespace AisLogistics.API.Models.Request.Jitsi
{
    public class SearchCustomerResponse
    {
        public SearchCustomerDto Customers { get; set; }
    }
}
