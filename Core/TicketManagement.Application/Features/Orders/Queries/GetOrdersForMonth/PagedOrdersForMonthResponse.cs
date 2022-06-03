namespace TicketManagement.Application.Features.Orders.Queries
{
    public class PagedOrdersForMonthResponse
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<OrdersForMonthDto> OrdersForMonth{ get; set; }
    }
}