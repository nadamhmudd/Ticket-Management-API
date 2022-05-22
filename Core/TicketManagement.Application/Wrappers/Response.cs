using FluentValidation.Results;

namespace TicketManagement.Application.Features.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
            Success = true;
            ValidationErrors = new List<string>();
        }
        public Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public Response(T data, string message = null)
        {
            Success = true;
            Message = message;
            Data = data;
        }
        public Response(List<ValidationFailure> errors, string message = null)
        {
            Success = false;
            Message = message;
            ValidationErrors = new List<string>();
            foreach (var error in errors)
                ValidationErrors?.Add(error.ErrorMessage);
        }

        public bool Success { get;  set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
        public T Data { get; set; }
    }
}
