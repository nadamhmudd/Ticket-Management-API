﻿namespace TicketManagement.Application.Features.Events.Commands
{
    public class UpdateEventCommand : IRequest<EventDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
    }
}