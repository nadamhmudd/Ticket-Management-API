global using FluentValidation;

namespace TicketManagement.Application.Features.Events.Commands
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        #region Props / Vars
        private readonly IEventRepository _eventRepo;
        #endregion

        #region Constructor(s)
        public CreateEventCommandValidator(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;

            ApplyValidationRules();
        }
        #endregion

        #region Basic Validation Rules
        private void ApplyValidationRules()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                ;

            RuleFor(e => e.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                ;

            RuleFor(e => e.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now)
                ;

            RuleFor(e => e)
               .MustAsync(EventNameAndDateUnique)
               .WithMessage("An event with the same name and date already exists.")
               ;
        }
        #endregion

        #region Custom Validation Rules
        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)
        {
            return !(await _eventRepo.IsEventNameAndDateUnique(e.Name, e.Date));
        }
        #endregion
    }
}
