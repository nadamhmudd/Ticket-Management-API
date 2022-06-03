global using AutoMapper;
global using TicketManagement.Application.Interfaces;

namespace TicketManagement.Application.Features.Events.Queries
{
    public class EventQueryHandler :
                            IRequestHandler<GetEventsListQuery, List<EventDto>>,
                            IRequestHandler<GetEventDetailQuery, EventDetailsDto>,
                            IRequestHandler<GetEventsExportQuery, CsvFile>
    {
        #region Vars / Props
        private readonly IEventRepository _eventRepo;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly ILogger<EventQueryHandler> _logger;
        #endregion

        #region Constructor(s)
        public EventQueryHandler(IEventRepository eventRepo,
            IMapper mapper, ICsvExporter csvExporter, 
            ILogger<EventQueryHandler> logger)
        {
            _eventRepo = eventRepo;
            _mapper = mapper;
            _csvExporter = csvExporter;
            _logger = logger;
        }
        #endregion

        #region Get Events List Query
        public async Task<List<EventDto>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var eventsList = (await _eventRepo.ListAllAsync()).OrderBy(e => e.Date);

            if(!eventsList.Any())
                throw new Exception($"There is no Events has been found.");

            return _mapper.Map<List<EventDto>>(eventsList);
        }
        #endregion

        #region  Get Event Detail Query
        public async Task<EventDetailsDto> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var eventFronDb = await _eventRepo.GetByIdAsync(id: request.Id, include: e => e.Category);

            if (eventFronDb is null || eventFronDb.Category is null)
                throw new Exceptions.NotFoundException(nameof(Event), request.Id);

            var categoryDto = _mapper.Map<CategoryDto>(eventFronDb.Category);

            var eventDatailDto = _mapper.Map<EventDetailsDto>(eventFronDb);
            
            eventDatailDto.Category = categoryDto;

            return eventDatailDto;
        }
        #endregion

        #region Get Events Export Query
        public async Task<CsvFile> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
        {
            var eventsFromDb = (await _eventRepo.ListAllAsync())?.OrderBy(e => e.Date);
            
            if(!eventsFromDb.Any())
                throw new Exception($"There is no Events has been found.");

            var eventsList = _mapper.Map<List<EventExportDto>>(eventsFromDb);

            try
            {
                var csvFile = _csvExporter.ExportEventsToCsv(eventsList);

                return new CsvFile(exportFileName: $"{Guid.NewGuid()}.csv", contentType:
                        "text/csv",
                        data: csvFile
                );
            }
            catch (Exception ex)
            {
                _logger.LogError($"Returning a CSV File failed due to an error: {ex.Message}");
                throw;
            }
        }
        #endregion
    }
}
