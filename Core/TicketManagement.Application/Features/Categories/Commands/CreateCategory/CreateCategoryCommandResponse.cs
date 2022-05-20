global using TicketManagement.Application.Responses;

namespace TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandResponse: BaseResponse
    {
        public CreateCategoryCommandResponse(): base()
        {
        }

        public CategoryDto Category { get; set; }
    }
}