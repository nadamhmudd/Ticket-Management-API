namespace TicketManagement.Application.Features.Events.Commands
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        #region Constructor(s)
        public UpdateEventCommandValidator()
        {
            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage("{PropertyName} is required.")
                  .NotNull()
                  .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);

        }
        #endregion
    }
}
