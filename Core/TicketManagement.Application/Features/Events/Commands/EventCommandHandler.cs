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
            var validator = new CreateEventCommandValidator(_eventRepo);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new Exceptions.ValidationException(validationResult);

            var @event = _mapper.Map<Event>(request);
           
            @event = await _eventRepo.AddAsync(@event);

            return @event.Id;
        }
        #endregion

        #region Update Event
        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _eventRepo.GetByIdAsync(request.Id);

            #region Validation
            if (eventToUpdate is null)
                throw new Exceptions.NotFoundException(nameof(Event), request.Id);

            var validator = new UpdateEventCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new Exceptions.ValidationException(validationResult); 
            #endregion

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
            
            await _eventRepo.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
        #endregion

        #region Delete Event
        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _eventRepo.GetByIdAsync(request.Id);

            if (eventToDelete is null)
                throw new Exceptions.NotFoundException(nameof(Event), request.Id);

            await _eventRepo.DeleteAsync(eventToDelete);

            return Unit.Value;
        } 
        #endregion
    }
}
