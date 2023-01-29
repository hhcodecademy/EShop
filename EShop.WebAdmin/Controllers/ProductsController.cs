using EShop.BLL.Services.Inerfaces;
using EShop.DAL.DBModel;
using EShop.DAL.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.WebAdmin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.GetListAsync();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            ProductDto model = new ProductDto();
            model.CategoryDtos = await _service.GetCategoriesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto itemDto)
        {

            var category = await _service.AddAsync(itemDto);
            if (category != null)
            {
                TempData["success"] = "Kateqoriya uğurla əlavə edildi.";
                return RedirectToAction("Index");
            }
            return Ok(category);
        }

    }
}
