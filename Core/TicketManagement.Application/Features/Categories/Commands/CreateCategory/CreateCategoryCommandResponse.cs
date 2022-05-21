namespace TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandResponse: Comman.BaseResponse
    {
        public CreateCategoryCommandResponse(): base()
        {
        }

        public CategoryDto Category { get; set; }
    }
}