namespace TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        #region Vars
        private readonly ICategoryRepository _categoryRepo;
        #endregion

        public CreateCategoryCommandValidator(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;

            //ApplyValidationRules
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.")
                .MustAsync(CategoryNameUnique).WithMessage("A category with the same {PropertyName} already exists.")
            ;
        }

        #region Custom Validation Rules
        private async Task<bool> CategoryNameUnique(string name, CancellationToken token)
           => await _categoryRepo.IsUnique(name); 
        #endregion
    }
}
