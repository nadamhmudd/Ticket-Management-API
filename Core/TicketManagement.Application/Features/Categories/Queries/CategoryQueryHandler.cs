using AutoMapper;
using TicketManagement.Application.Interfaces.Repositories;

namespace TicketManagement.Application.Features.Categories.Queries
{
    public class CategoryQueryHandler :
                                IRequestHandler<GetCategoriesListQuery, List<CategoryListResponse>>,
                                IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListResponse>>
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
        public async Task<List<CategoryListResponse>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var CategoriesList = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
            
            return _mapper.Map<List<CategoryListResponse>>(CategoriesList);
        }
        #endregion

        #region Get Categories List With Events
        public async Task<List<CategoryEventListResponse>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);

            return _mapper.Map<List<CategoryEventListResponse>>(list);
        } 
        #endregion

    }
}
