namespace TicketManagement.Application.Features.Orders.Queries
{
    public class OrderQueryHandler :
        IRequestHandler<GetOrdersForMonthQuery, PagedOrdersForMonthResponse>
    {
        #region Props / Vars
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper; 
        #endregion

        #region Ctor
        public OrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        #endregion

        #region GetOrdersForMonth
        public async Task<PagedOrdersForMonthResponse> Handle(GetOrdersForMonthQuery request, CancellationToken cancellationToken)
        {
            var list = await _orderRepository.GetPagedOrdersForMonth(request.Date, request.Page, request.Size);
           
            if(!list.Any())
                throw new Exception($"There is no Orders has been found.");

            var orders = _mapper.Map<List<OrdersForMonthDto>>(list);

            var count = await _orderRepository.GetTotalCountOfOrdersForMonth(request.Date);
            
            return new PagedOrdersForMonthResponse() { Count = count, OrdersForMonth = orders, Page = request.Page, Size = request.Size };
        } 
        #endregion
    }
}
