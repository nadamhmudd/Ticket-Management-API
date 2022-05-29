using TicketManagement.Application.Features.Orders.Queries;

namespace TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Props /Vars
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Actions

        [HttpGet("/getpagedordersformonth", Name = "GetPagedOrdersForMonth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedOrdersForMonthVm>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            var getOrdersForMonthQuery = new GetOrdersForMonthQuery() { Date = date, Page = page, Size = size };
            var dtos = await _mediator.Send(getOrdersForMonthQuery);

            return Ok(dtos);
        } 

        #endregion
    }
}
