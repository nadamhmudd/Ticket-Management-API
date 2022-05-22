global using TicketManagement.Application.Features.Wrappers;
global using TicketManagement.Application.DTOs;

namespace TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Response<CategoryDto>>
    {
        public string Name { get; set; }
    }
}
