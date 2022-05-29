using TicketManagement.Application.Features.Categories.Commands;
using TicketManagement.Application.Features.Events.Commands;
using TicketManagement.Application.Features.Events.Queries;
using TicketManagement.Application.Features.Orders.Queries;

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
            CreateMap<Event, EventDetailsDto>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Order, OrdersForMonthDto>().ReverseMap();

        }
    }
}
