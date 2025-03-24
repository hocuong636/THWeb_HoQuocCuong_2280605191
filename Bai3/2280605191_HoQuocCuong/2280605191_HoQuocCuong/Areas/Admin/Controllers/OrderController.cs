using Microsoft.AspNetCore.Mvc;
using _2280605191_HoQuocCuong.Models;
using _2280605191_HoQuocCuong.Repositories;

namespace _2280605191_HoQuocCuong.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAllAsync();
            return View(orders);
        }

        public async Task<IActionResult> Display(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        public async Task<IActionResult> UpdateStatus(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            await _orderRepository.UpdateStatusAsync(order);
            return RedirectToAction(nameof(Index));
        }
    }
}
