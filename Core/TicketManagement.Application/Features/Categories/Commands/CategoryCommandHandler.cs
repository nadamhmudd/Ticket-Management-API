namespace TicketManagement.Application.Features.Categories.Commands
{
    public class CategoryCommandHandler :
                          IRequestHandler<CreateCategoryCommand, Response<CategoryDto>>
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
        public async Task<Response<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Response<CategoryDto> createCategoryCommandResponse = new();

            #region Validation
            var validator = new CreateCategoryCommandValidator();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                createCategoryCommandResponse = new(validationResult.Errors);
            #endregion
            
            var category =  _mapper.Map<Category>(request);
           
            category = await _categoryRepository.AddAsync(category);
            
            createCategoryCommandResponse.Data = _mapper.Map<CategoryDto>(category);

            return createCategoryCommandResponse;
        }

        #endregion
    }
}
