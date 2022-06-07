using TicketManagement.Application.Models.Mail;

namespace TicketManagement.Application.Features.Events.Commands
{
    public class EventCommandHandler :
                    IRequestHandler<CreateEventCommand, EventDto>,
                    IRequestHandler<UpdateEventCommand, EventDto>,
                    IRequestHandler<DeleteEventCommand, EventDto>
    {
        #region Props / Vars
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepo; 
        private readonly IAsyncRepository<Category> _categoryRepo; 
        private readonly IEmailService _emailService;
        private readonly ILogger<EventCommandHandler> _logger;
        #endregion

        #region Constructor(s)
        public EventCommandHandler(IMapper mapper, IEventRepository eventRepo, ILogger<EventCommandHandler> logger, IEmailService emailService, IAsyncRepository<Category> categoryRepo)
        {
            _mapper = mapper;
            _eventRepo = eventRepo;
            _logger = logger;
            _emailService = emailService;
            _categoryRepo = categoryRepo;
        }
        #endregion

        #region Create new Event
        public async Task<EventDto> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validator = new EventCommandValidator(_eventRepo, _categoryRepo);

            var validationResult = await validator.ValidateAsync(request.Event);

            if (validationResult.Errors.Any())
            {
                throw new Exceptions.ValidationException(validationResult);
            }
            #endregion

            var @event = _mapper.Map<Event>(request);

            @event = await _eventRepo.AddAsync(@event);

            #region Send an email
            try
            {
                await _emailService.SendEmail(new Email()
                {
                    To = "nada.mhmudd@gmail.com",
                    Body = $"A new event was created: {request}",
                    Subject = "A new event was created"
                });
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                _logger.LogError($"Mailing about event {@event.Id} failed due to an error with the mail service: {ex.Message}");
            } 
            #endregion

            return _mapper.Map<EventDto>(@event);
        }
        #endregion

        #region Update Event
        public async Task<EventDto> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var eventToUpdate = await _eventRepo.GetByIdAsync(request.Id);

                if (eventToUpdate is null)
                    throw new Exceptions.NotFoundException(nameof(Event), request.Id);

                #region Validation
                //var validator = new UpdateEventCommandValidator();
                var validator = new EventCommandValidator(_eventRepo, _categoryRepo);

                var validationResult = await validator.ValidateAsync(request.Event);

                if (validationResult.Errors.Any())
                    throw new Exceptions.ValidationException(validationResult);
                #endregion

                _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

                var @event = await _eventRepo.UpdateAsync(eventToUpdate);

                return _mapper.Map<EventDto>(@event);
            }
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(Exceptions.NotFoundException)|| ex.GetType() != typeof(Exceptions.ValidationException))
                    _logger.LogError(ex.Message);

                throw;
            }
        }
        #endregion

        #region Delete Event
        public async Task<EventDto> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var eventToDelete = await _eventRepo.GetByIdAsync(request.Id);

                if (eventToDelete is null)
                    throw new Exceptions.NotFoundException(nameof(Event), request.Id);

                await _eventRepo.DeleteAsync(eventToDelete);

                return _mapper.Map<EventDto>(eventToDelete);
            }
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(Exceptions.NotFoundException))
                    _logger.LogError(ex.Message);

                throw;
            }
        } 
        #endregion
    }
}
