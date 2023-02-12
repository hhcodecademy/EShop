using EShop.BLL.Services.Inerfaces;
using EShop.DAL.DBModel;
using EShop.DAL.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGenericService<ProductCategoryDto, ProductCategory> _service;
        public CategoryController(IGenericService<ProductCategoryDto, ProductCategory> service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<ProductCategoryDto> categoryDtos = await _service.GetListAsync();
            return View(categoryDtos);
        }
    }
}
