global using AutoMapper;
global using TicketManagement.Application.Interfaces.Repositories;
using TicketManagement.Application.Contracts.Infrastructure;

namespace TicketManagement.Application.Features.Events.Queries
{
    public class EventQueryHandler :
                            IRequestHandler<GetEventsListQuery, Response<List<EventDto>>>,
                            IRequestHandler<GetEventDetailQuery, Response<EventDetailsDto>>,
                            IRequestHandler<GetEventsExportQuery, Response<CsvFile>>
    {
        #region Vars / Props
        private readonly IEventRepository _eventRepo;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        #endregion

        #region Constructor(s)
        public EventQueryHandler(IEventRepository eventRepo, IMapper mapper, ICsvExporter csvExporter)
        {
            _eventRepo = eventRepo;
            _mapper = mapper;
            _csvExporter = csvExporter;
        } 
        #endregion

        #region Get Events List Query
        public async Task<Response<List<EventDto>>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var eventsList = (await _eventRepo.ListAllAsync()).OrderBy(e => e.Date);

            return new Response<List<EventDto>>(_mapper.Map<List<EventDto>>(eventsList));
        }
        #endregion

        #region  Get Event Detail Query
        public async Task<Response<EventDetailsDto>> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var eventFronDb = await _eventRepo.GetByIdAsync(id: request.Id, include: e => e.Category);

            if (eventFronDb is null || eventFronDb.Category is null)
                throw new Exceptions.NotFoundException(nameof(Event), request.Id);

            var categoryDto = _mapper.Map<CategoryDto>(eventFronDb.Category);

            var eventDatailDto = _mapper.Map<EventDetailsDto>(eventFronDb);
            
            eventDatailDto.Category = categoryDto;

            return new Response<EventDetailsDto>(eventDatailDto);
        }
        #endregion

        #region Get Events Export Query
        public async Task<Response<CsvFile>> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
        {
            var eventsList = _mapper.Map<List<EventExportDto>>((await _eventRepo.ListAllAsync()).OrderBy(e => e.Date));

            var csvFile = _csvExporter.ExportEventsToCsv(eventsList);

            return new Response<CsvFile>(
                    new CsvFile(exportFileName: $"{Guid.NewGuid()}.csv", contentType:
                    "text/csv",
                    data: csvFile
            ));

        }
        #endregion

    }
}
