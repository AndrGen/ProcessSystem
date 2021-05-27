using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProcessSystem.Contracts
{
    public class RegisterRequest: IBaseRequest
    {
        public string Channel { get; set; }
        public string Url { get; set; }
        public IList<string> EventTypesList { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Channel))
                errors.Add(new ValidationResult("Имя витрины должно быть задано"));

            if (string.IsNullOrWhiteSpace(Url))
                errors.Add(new ValidationResult("Url для ответа пустой"));

            if (EventTypesList == null || EventTypesList.Count == 0)
                errors.Add(new ValidationResult("Список событий подписки пустой"));

            return errors;
        }
    }
}
