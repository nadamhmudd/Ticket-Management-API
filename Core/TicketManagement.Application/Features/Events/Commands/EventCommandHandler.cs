using Microsoft.Extensions.Logging;

namespace TicketManagement.Application.Features.Events.Commands
{
    public class EventCommandHandler :
                    IRequestHandler<CreateEventCommand, Response<EventDto>>,
                    IRequestHandler<UpdateEventCommand, Response<EventDto>>,
                    IRequestHandler<DeleteEventCommand, Response<EventDto>>
    {
        #region Props / Vars
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepo; 
        private readonly ILogger<EventCommandHandler> _logger;
        #endregion

        #region Constructor(s)
        public EventCommandHandler(IMapper mapper, IEventRepository eventRepo, ILogger<EventCommandHandler> logger)
        {
            _mapper = mapper;
            _eventRepo = eventRepo;
            _logger = logger;
        }
        #endregion

        #region Create new Event
        public async Task<Response<EventDto>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var createEventResponse = new Response<EventDto>();

            #region Validation
            var validator = new CreateEventCommandValidator(_eventRepo);

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                /* return*/
                createEventResponse = new(validationResult.Errors);
                //throw new Exceptions.ValidationException(validationResult);
            } 
            #endregion

            var @event = _mapper.Map<Event>(request);
           
            @event = await _eventRepo.AddAsync(@event);

            createEventResponse.Data = _mapper.Map<EventDto>(@event);

            return createEventResponse;
        }
        #endregion

        #region Update Event
        public async Task<Response<EventDto>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var updateEventResponse = new Response<EventDto>();

            var eventToUpdate = await _eventRepo.GetByIdAsync(request.Id);

            if (eventToUpdate is null)
                throw new Exceptions.NotFoundException(nameof(Event), request.Id);

            #region Validation
            var validator = new UpdateEventCommandValidator();
            
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                updateEventResponse = new(validationResult.Errors);
               // throw new Exceptions.ValidationException(validationResult);
            }
            #endregion

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
            
            var @event = await _eventRepo.UpdateAsync(eventToUpdate);

            updateEventResponse.Data = _mapper.Map<EventDto>(@event);

            return updateEventResponse;
        }
        #endregion

        #region Delete Event
        public async Task<Response<EventDto>> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var deleteEventResponse = new Response<EventDto>();

            var eventToDelete = await _eventRepo.GetByIdAsync(request.Id);

            if (eventToDelete is null)
                throw new Exceptions.NotFoundException(nameof(Event), request.Id);

            await _eventRepo.DeleteAsync(eventToDelete);

            deleteEventResponse.Data = _mapper.Map<EventDto>(eventToDelete);

            return deleteEventResponse;
        } 
        #endregion
    }
}
