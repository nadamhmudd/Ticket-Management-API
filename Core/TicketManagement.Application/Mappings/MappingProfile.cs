using TicketManagement.Application.Features.Categories;
using TicketManagement.Application.Features.Categories.Commands;
using TicketManagement.Application.Features.Categories.Queries;
using TicketManagement.Application.Features.Events;
using TicketManagement.Application.Features.Events.Commands;

namespace TicketManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryEventsDto>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();

            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();

        }
    }
}
