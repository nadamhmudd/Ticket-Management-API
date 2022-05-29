using AutoMapper;
using TicketManagement.App.Services;
using TicketManagement.App.ViewModels;

namespace TicketManagement.App.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            //Vms are coming in from the API, ViewModel are the local entities in Blazor
            CreateMap<EventDto, EventListViewModel>().ReverseMap();
            CreateMap<EventDetailsDto, EventDetailViewModel>().ReverseMap();

            CreateMap<EventDetailViewModel, CreateEventCommand>().ReverseMap();
            CreateMap<EventDetailViewModel, UpdateEventCommand>().ReverseMap();

            CreateMap<CategoryDto, EventNestedViewModel>().ReverseMap();

            CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryEventsDto, CategoryEventsViewModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryViewModel>().ReverseMap();

            CreateMap<PagedOrdersForMonthVm, PagedOrderForMonthViewModel>().ReverseMap();
            CreateMap<OrdersForMonthDto, OrdersForMonthListViewModel>().ReverseMap();
        }
    }
}
