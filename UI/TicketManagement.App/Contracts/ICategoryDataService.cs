using TicketManagement.App.Services;
using TicketManagement.App.Services.Base;
using TicketManagement.App.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketManagement.App.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoryEventsViewModel>> GetAllCategoriesWithEvents(bool includeHistory);
        Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
