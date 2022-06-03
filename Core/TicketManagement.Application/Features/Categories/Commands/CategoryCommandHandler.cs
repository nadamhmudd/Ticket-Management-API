global using Microsoft.Extensions.Logging;

namespace TicketManagement.Application.Features.Categories.Commands
{
    public class CategoryCommandHandler :
                          IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        #region Props / Vars
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryCommandHandler> _logger;
        #endregion

        #region Constructor(s)
        public CategoryCommandHandler(IMapper mapper,
            ICategoryRepository categoryRepository, 
            ILogger<CategoryCommandHandler> logger)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        #endregion

        #region Create New Category
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                #region Validation
                var validator = new CreateCategoryCommandValidator(_categoryRepository);

                var validationResult = await validator.ValidateAsync(request);

                if (validationResult.Errors.Any())
                    throw new Exceptions.ValidationException(validationResult);
                #endregion

                var category = _mapper.Map<Category>(request);

                category = await _categoryRepository.AddAsync(category);

                return _mapper.Map<CategoryDto>(category);
            }
            catch (Exception ex)
            {
                if(ex.GetType() != typeof(Exceptions.ValidationException))
                    _logger.LogError(ex.Message);

                throw;
            }
            
        }
        #endregion
    }
}
