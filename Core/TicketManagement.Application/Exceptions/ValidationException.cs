using FluentValidation.Results;

namespace TicketManagement.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValdationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
            //:base(String.Join(",", validationResult.Errors?.Select(e => e.ErrorMessage).ToList()))
        {
            ValdationErrors = validationResult.Errors?.Select(e => e.ErrorMessage).ToList();

            //ValdationErrors = Message?.Split(",").ToList();

            //ValdationErrors = new List<string>();
            //foreach (var validationError in validationResult.Errors)
            //{
            //    ValdationErrors.Add(validationError.ErrorMessage);
            //}
        }
    }
}
