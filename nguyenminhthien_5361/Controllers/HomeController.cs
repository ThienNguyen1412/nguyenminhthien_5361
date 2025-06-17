using Microsoft.AspNetCore.Mvc;
using nguyenminhthien_5361.Models;
using nguyenminhthien_5361.Repositories;
using System.Diagnostics;

namespace nguyenminhthien_5361.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }
    }
}
