namespace TicketManagement.Application.Features.Categories.Commands
{
    public class CategoryCommandHandler :
                          IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        #region Props / Vars
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor(s)
        public CategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        #endregion

        #region Create New Category
        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();

            #region Validation
            var validator = new CreateCategoryCommandValidator();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                createCategoryCommandResponse.Success = false;
                
                createCategoryCommandResponse.ValidationErrors = new List<string>();
              
                foreach (var error in validationResult.Errors)
                    createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            } 
            #endregion
            
            var category = new Category() { Name = request.Name };
           
            category = await _categoryRepository.AddAsync(category);
            
            createCategoryCommandResponse.Category = _mapper.Map<CategoryDto>(category);

            return createCategoryCommandResponse;
        }

        #endregion
    }
}
