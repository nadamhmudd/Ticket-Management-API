using TicketManagement.Application.Features.Orders.Queries;

namespace TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [Authorize(Roles = SD.Role_Admin)]
        public async Task<ActionResult<PagedOrdersForMonthResponse>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            return Ok(await _mediator.Send(
                new GetOrdersForMonthQuery(date, page, size)));
        }
        #endregion
    }
}
