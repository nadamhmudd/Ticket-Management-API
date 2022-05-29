using System.Net.Http;

namespace TicketManagement.App.Services
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }

    }
}
