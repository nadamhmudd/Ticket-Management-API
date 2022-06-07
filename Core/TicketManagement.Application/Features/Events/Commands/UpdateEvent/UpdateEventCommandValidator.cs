namespace TicketManagement.Application.Features.Events.Commands
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        #region Props / Vars
        private readonly IEventRepository _eventRepo;
        private readonly IAsyncRepository<Category> _categpryRepo;
        #endregion

        #region Constructor(s)
        public UpdateEventCommandValidator(IEventRepository eventRepo, IAsyncRepository<Category> categpryRepo)
        {
            _eventRepo = eventRepo;
            _categpryRepo = categpryRepo;
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

            RuleFor(e => e.Artist)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                ;

            RuleFor(e => e.ImageUrl)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                ;

            RuleFor(e => e.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                ;

            RuleFor(e => e.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(DateTime.Now)
                ;

            RuleFor(e => e)
               .MustAsync(EventNameAndDateUnique)
               .WithMessage("An event with the same name and date already exists.")
               ;

            RuleFor(e => e)
               .MustAsync(CategoryIdIsValid)
               .WithMessage("Invaild Category ID.")
               ;
        }
        #endregion

        #region Custom Validation Rules
        private async Task<bool> EventNameAndDateUnique(UpdateEventCommand e, CancellationToken token)
        {
            var matches = await _eventRepo.GetEventNameAndDate(e.Name, e.Date);
            return matches is null ? true 
                                    :matches.Id == e.Id ? true : false;
        }
        private async Task<bool> CategoryIdIsValid(UpdateEventCommand e, CancellationToken token)
        {
            return (await _categpryRepo.GetByIdAsync(e.CategoryId) != null);
        }
        #endregion
    }
}
