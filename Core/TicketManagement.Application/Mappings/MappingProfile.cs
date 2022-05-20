using AutoMapper;
using TicketManagement.Application.Features.Categories.Queries;
using TicketManagement.Application.Features.Events.Commands;
using TicketManagement.Application.Features.Events.Queries;

namespace TicketManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventsListResponse>().ReverseMap();
            CreateMap<Event, EventDetailResponse>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListResponse>().ReverseMap();
            CreateMap<Category, CategoryEventListResponse>().ReverseMap();
        }
    }
}
