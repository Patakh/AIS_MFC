using System.ComponentModel.DataAnnotations;

namespace AisLogistics.API.Models.Request.PersonalAccount
{
    public class CasesExecutionInfoRequest : IValidatableObject
    {
        [Required(ErrorMessage = "Номер телефона обязателен для заполнения")]
        public string PhoneNumber { get; set; }

        private string DigitPhoneNumber()
        {
            var strDigit = PhoneNumber.Where(char.IsDigit);
            if (strDigit is not null && strDigit.Any())
            {
                return string.Join("", PhoneNumber.Where(char.IsDigit))[1..];
            }
            else return string.Empty;
        }

        public string InputMaskPhoneNumber() => string.Format("{0:+7(###) ###-##-##}", Convert.ToInt64(DigitPhoneNumber()));

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (DigitPhoneNumber().Length < 10)
            {
                errors.Add(new ValidationResult("Неправильный формат номера", new List<string>() { "PhoneNumber" }));
            }

            return errors;
        }
    }
}
