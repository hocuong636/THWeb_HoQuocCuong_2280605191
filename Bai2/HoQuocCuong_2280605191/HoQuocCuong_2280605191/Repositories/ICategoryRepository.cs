using HoQuocCuong_2280605191.Models;

namespace HoQuocCuong_2280605191.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}
