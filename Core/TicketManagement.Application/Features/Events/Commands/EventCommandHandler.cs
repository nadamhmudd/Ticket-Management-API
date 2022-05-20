namespace TicketManagement.Application.Features.Events.Commands
{
    public class EventCommandHandler :
                    IRequestHandler<CreateEventCommand, Guid>,
                    IRequestHandler<UpdateEventCommand>,
                    IRequestHandler<DeleteEventCommand>
    {
        #region Props / Vars
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepo; 
        #endregion

        #region Constructor(s)
        public EventCommandHandler(IMapper mapper, IEventRepository eventRepo)
        {
            _mapper = mapper;
            _eventRepo = eventRepo;
        }
        #endregion

        #region Create new Event
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Event>(request);
           
            @event = await _eventRepo.AddAsync(@event);

            return @event.Id;
        }
        #endregion

        #region Update Event
        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _eventRepo.GetByIdAsync(request.Id);

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
            
            await _eventRepo.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
        #endregion

        #region Delete Event
        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _eventRepo.GetByIdAsync(request.Id);

            await _eventRepo.DeleteAsync(eventToDelete);

            return Unit.Value;
        } 
        #endregion
    }
}
