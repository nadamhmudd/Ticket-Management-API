using FluentValidation.Results;

namespace TicketManagement.Application.Features.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
            Succeeded = true;
            ValidationErrors = new List<string>();
        }
        public Response(bool success, string message)
        {
            Succeeded = success;
            Message = message;
        }
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Response(List<ValidationFailure> errors, string message = null)
        {
            Succeeded = false;
            Message = message;
            ValidationErrors = new List<string>();
            foreach (var error in errors)
                ValidationErrors?.Add(error.ErrorMessage);
        }

        public bool Succeeded { get;  set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
        public T Data { get; set; }
    }
}
