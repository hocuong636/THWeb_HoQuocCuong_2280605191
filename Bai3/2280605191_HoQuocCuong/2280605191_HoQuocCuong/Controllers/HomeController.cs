using System.Diagnostics;
using _2280605191_HoQuocCuong.Models;
using _2280605191_HoQuocCuong.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _2280605191_HoQuocCuong.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index( )
        {
            var model = await _productRepository.GetAllAsync();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
