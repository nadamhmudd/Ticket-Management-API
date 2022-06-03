namespace TicketManagement.Application.Features.Orders.Queries
{
    public class GetOrdersForMonthQuery : IRequest<PagedOrdersForMonthResponse>
    {
        #region Ctor
        public GetOrdersForMonthQuery(DateTime date, int page, int size)
        {
            Date = date;
            Page = page;
            Size = size;
        }
        #endregion
        
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
