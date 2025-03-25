using Microsoft.EntityFrameworkCore;
using _2280605191_HoQuocCuong.Models;

namespace _2280605191_HoQuocCuong.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public EFOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.ApplicationUser)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.ApplicationUser)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> GetOrderWithDetailsAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.ApplicationUser)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id);
            
            if (existingOrder != null)
            {
                // Cập nhật các thuộc tính có thể thay đổi
                existingOrder.ShippingAddress = order.ShippingAddress;
                existingOrder.Notes = order.Notes;
                
                // Lưu thay đổi
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateStatusAsync(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id);
            
            if (existingOrder != null)
            {
                // Theo model hiện tại không có trường Status
                // Nếu cần thêm, có thể thực hiện ở đây
                
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            // Đầu tiên, xóa các chi tiết đơn hàng
            var orderDetails = await _context.Set<OrderDetail>()
                .Where(od => od.OrderId == id)
                .ToListAsync();
                
            if (orderDetails.Any())
            {
                _context.Set<OrderDetail>().RemoveRange(orderDetails);
            }
            
            // Sau đó xóa đơn hàng
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}