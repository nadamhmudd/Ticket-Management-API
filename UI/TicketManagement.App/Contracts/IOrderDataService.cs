using 
    TicketManagement.App.ViewModels;
using System;
using System.Threading.Tasks;

namespace TicketManagement.App.Contracts
{
    public interface IOrderDataService
    {
        Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size);
    }
}
