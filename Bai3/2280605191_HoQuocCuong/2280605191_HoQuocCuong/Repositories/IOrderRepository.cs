using _2280605191_HoQuocCuong.Models;

namespace _2280605191_HoQuocCuong.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task UpdateStatusAsync(Order order);
        Task DeleteAsync(int id);
    }
} 