using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        Task GetCategories();
    }
}
