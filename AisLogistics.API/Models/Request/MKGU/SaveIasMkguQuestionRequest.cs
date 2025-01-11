using System.ComponentModel.DataAnnotations;

namespace AisLogistics.API.Models.Request
{
    public class SaveIasMkguQuestionRequest : IValidatableObject
    {
        [Required]
        public string DCasesId { get; set; }
        public List<IasMkguInfomatAnswer> Answer { get; set; }
        public string? Comment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Answer is null or { Count: 0})
            {
                errors.Add(new ValidationResult("Коллекция не может быть пустой", new List<string>() { "Answer" }));
            }

            return errors;
        }

    }

    public class IasMkguInfomatAnswer
    {
        public int QuestionId { get; set; }

        public int AnswerId { get; set; }
    }
}
