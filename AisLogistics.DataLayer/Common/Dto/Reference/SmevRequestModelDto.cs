using System;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class SmevRequestModelDto
    {
        public int Id { get; set; }
        public int OldId { get; set; }
        public int SSmevTypeRequestId { get; set; }
        public string RequestName { get; set; }
        public int CountDayExecution { get; set; }
        public string Path { get; set; }
        public string ServiceOrFunctionCode { get; set; }
        public Guid SSmevId { get; set; }
        public int SServicesWeekId { get; set; }
        public bool IsRequestActive { get; set; }
    }
}
