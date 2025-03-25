using _2280605191_HoQuocCuong.Models;
using _2280605191_HoQuocCuong.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _2280605191_HoQuocCuong.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductRepository _productRepository;

        public OrderController(
            IOrderRepository orderRepository,
            UserManager<ApplicationUser> userManager,
            IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _userManager = userManager;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAllAsync();
            return View(orders);
        }

        public async Task<IActionResult> Display(int id)
        {
            var order = await _orderRepository.GetOrderWithDetailsAsync(id);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.UpdateAsync(order);
                return RedirectToAction(nameof(Display), new { id = order.Id });
            }
            return View(order);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Add()
        {
            await PrepareViewBagForOrderForm();
            return View(new Order { OrderDate = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.AddAsync(order);
                return RedirectToAction(nameof(Index));
            }

            await PrepareViewBagForOrderForm();
            return View(order);
        }

        private async Task PrepareViewBagForOrderForm()
        {
            var users = await _userManager.GetUsersInRoleAsync("Customer");
            ViewBag.Users = new SelectList(users, "Id", "UserName");

            var products = await _productRepository.GetAllAsync();
            ViewBag.Products = new SelectList(products, "Id", "Name");
        }
    }
}
