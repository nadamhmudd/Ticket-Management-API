namespace TicketManagement.Application.Features.Categories.Queries
{
    public class GetCategoriesListWithEventsQuery: IRequest<List<CategoryEventsDto>>
    {
        public readonly bool IncludeHistory;

        public GetCategoriesListWithEventsQuery(bool includeHistory)
        {
            IncludeHistory = includeHistory;
        }
    }
}
