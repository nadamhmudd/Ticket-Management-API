using TicketManagement.Application.Interfaces;

namespace TicketManagement.Application.Features.Categories.Queries
{
    public class CategoryQueryHandler :
                                IRequestHandler<GetCategoriesListQuery, Response<List<CategoryDto>>>,
                                IRequestHandler<GetCategoriesListWithEventsQuery, Response<List<CategoryEventsDto>>>
    {
        #region Vars / Props
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor(s)
        public CategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        #endregion

        #region Get Categories List
        public async Task<Response<List<CategoryDto>>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var CategoriesList = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
            
            return new Response<List<CategoryDto>>(_mapper.Map<List<CategoryDto>>(CategoriesList));
        }
        #endregion

        #region Get Categories List With Events
        public async Task<Response<List<CategoryEventsDto>>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);

            return new Response<List<CategoryEventsDto>>(_mapper.Map<List<CategoryEventsDto>>(list));
        } 
        #endregion
    }
}
