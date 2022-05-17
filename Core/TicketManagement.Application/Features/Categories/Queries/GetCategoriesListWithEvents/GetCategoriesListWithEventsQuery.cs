namespace TicketManagement.Application.Features.Categories.Queries
{
    public class GetCategoriesListWithEventsQuery: IRequest<List<CategoryEventListResponse>>
    {
        public bool IncludeHistory { get; set; }
    }
}
