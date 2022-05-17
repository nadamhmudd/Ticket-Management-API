using AutoMapper;
using TicketManagement.Application.Interfaces.Repositories;

namespace TicketManagement.Application.Features.Events.Queries
{
    public class EventQueryHandler :
                            IRequestHandler<GetEventsListQuery, List<EventsListResponse>>,
                            IRequestHandler<GetEventDetailQuery, EventDetailResponse>
    {
        #region Vars / Props
        private readonly IEventRepository _eventRepo;
        private readonly IMapper _mapper; 
        #endregion

        #region Constructor(s)
        public EventQueryHandler(IEventRepository eventRepo, IMapper mapper)
        {
            _eventRepo = eventRepo;
            _mapper = mapper;
        } 
        #endregion

        #region Get Events List Query
        public async Task<List<EventsListResponse>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var eventsList = (await _eventRepo.ListAllAsync()).OrderBy(e => e.Date);

            return _mapper.Map<List<EventsListResponse>>(eventsList);
        }
        #endregion

        #region  Get Event Detail Query
        public async Task<EventDetailResponse> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var eventFronDb = await _eventRepo.GetByIdAsync(id: request.Id, include: e => e.Category);

            //if (eventFronDb.Category is null)
            //    throw ArgumentNullException;

            var categoryDto = _mapper.Map<CategoryDto>(eventFronDb.Category);

            var eventDatailDto = _mapper.Map<EventDetailResponse>(eventFronDb);
            eventDatailDto.Category = categoryDto;

            return eventDatailDto;
        } 
        #endregion

    }
}
