#region Using Statements
global using Microsoft.AspNetCore.Mvc;
global using MediatR;
global using TicketManagement.Application.Features.Wrappers;
global using TicketManagement.Application.DTOs;
using TicketManagement.Application.Features.Categories.Queries;
using TicketManagement.Application.Features.Categories.Commands; 
#endregion

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
        public async Task<ActionResult<Response<List<CategoryDto>>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetCategoriesListQuery()));
        }


        [HttpGet("allwithevents")]
        public async Task<ActionResult<Response<List<CategoryEventsDto>>>> GetCategoriesWithEvents(bool includeHistory)
        {
            return Ok(await _mediator.Send(new GetCategoriesListWithEventsQuery(includeHistory)));
        }

        #endregion

        #region Commands

        [HttpPost]
        public async Task<ActionResult<Response<CategoryDto>>> Create([FromBody] CreateCategoryCommand createCommand)
        {
            return Ok(await _mediator.Send(createCommand));
        }

        #endregion
    }
}
