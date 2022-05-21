global using AutoMapper;
global using TicketManagement.Application.Interfaces.Repositories;
using TicketManagement.Application.Features.Categories;

namespace TicketManagement.Application.Features.Events.Queries
{
    public class EventQueryHandler :
                            IRequestHandler<GetEventsListQuery, List<EventDto>>,
                            IRequestHandler<GetEventDetailQuery, EventDto>
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
        public async Task<List<EventDto>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var eventsList = (await _eventRepo.ListAllAsync()).OrderBy(e => e.Date);

            return _mapper.Map<List<EventDto>>(eventsList);
        }
        #endregion

        #region  Get Event Detail Query
        public async Task<EventDto> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var eventFronDb = await _eventRepo.GetByIdAsync(id: request.Id, include: e => e.Category);

            if (eventFronDb is null || eventFronDb.Category is null)
                throw new Exceptions.NotFoundException(nameof(Event), request.Id);

            var categoryDto = _mapper.Map<CategoryDto>(eventFronDb.Category);

            var eventDatailDto = _mapper.Map<EventDto>(eventFronDb);
            eventDatailDto.Category = categoryDto;

            return eventDatailDto;
        } 
        #endregion

    }
}
