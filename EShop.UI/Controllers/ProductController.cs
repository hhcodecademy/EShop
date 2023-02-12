using EShop.BLL.Services.Inerfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShop.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int id)
        {
            var data =await _service.GetProductsByCategoryIdAsync(id);
            return View(data);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var data = await _service.GetProductDetailByIdAsync(id);
            return View(data);
        }
    }
}
