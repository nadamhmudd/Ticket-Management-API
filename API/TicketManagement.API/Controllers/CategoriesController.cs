global using Microsoft.AspNetCore.Mvc;
global using MediatR;
using TicketManagement.Application.Features.Categories.Queries;
using TicketManagement.Application.Features.Categories.Commands;
using TicketManagement.Application.Features.Categories;

namespace TicketManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        #region Props / Vars
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Queries

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetCategoriesListQuery()));
        }


        [HttpGet("allwithevents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryEventsDto>>> GetCategoriesWithEvents(bool includeHistory)
        {
            return Ok(await _mediator.Send(new GetCategoriesListWithEventsQuery(includeHistory)));
        }

        #endregion

        #region Commands

        [HttpPost]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCommand)
        {
            return Ok(await _mediator.Send(createCommand));
        }

        #endregion
    }
}
