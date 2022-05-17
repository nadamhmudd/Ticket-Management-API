using AutoMapper;
using TicketManagement.Application.Features.Events.Queries;

namespace TicketManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventsListResponse>().ReverseMap();
            CreateMap<Event, EventDetailResponse>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
