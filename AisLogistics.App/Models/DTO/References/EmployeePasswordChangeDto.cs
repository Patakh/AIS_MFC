namespace AisLogistics.App.Models.DTO.References
{
    public class EmployeePasswordChangeDto
    {
        public Guid EmployeeId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
