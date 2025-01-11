namespace AisLogistics.App.Models.DTO.ApplicantPersonalAccount
{
    public class ReestrApplicantDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string CustomerName => $"{LastName} {FirstName} {SecondName}";
        public DateTime? DocumentBirthDate { get; set; }
        public string DocumentBirthDateToString =>  DocumentBirthDate.HasValue ? DocumentBirthDate.Value.ToShortDateString() : string.Empty;
        public string CustomerAddress { get; set; }
        public string CustomerSnils { get; set; }
    }
}
