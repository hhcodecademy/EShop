using AutoMapper;
using EShop.BLL.Services.Inerfaces;
using EShop.DAL.DBModel;
using EShop.DAL.Dtos;
using EShop.DAL.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Services
{
    public class ProductService : GenericService<ProductDto, Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<ProductCategory> _categoryRepository;
        private readonly IGenericRepository<ProductDocument> _documentRepository;
        public ProductService(IGenericRepository<Product> genericRepository,
            IMapper mapper, ILogger<GenericService<ProductDto, Product>> logger,
            IGenericRepository<ProductCategory> categoryRepository, IProductRepository productRepository, IGenericRepository<ProductDocument> documentRepository)
            : base(genericRepository, mapper, logger)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _documentRepository = documentRepository;
        }


        /// <summary>
        /// Get product categories with current product
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductCategoryDto>> GetCategoriesAsync()
        {

            var categories = await _categoryRepository.GetListAsync();

            var categoryDtos = _mapper.Map<List<ProductCategoryDto>>(categories);
            return categoryDtos;
        }

        public async Task<ProductDto> GetProductDetailByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            List<ProductDocument> documents = await _documentRepository.GetListAsync();
            product.ProductDocuments = documents.Where(d => d.ProductId == id).ToList();
            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<List<ProductDto>> GetProductsByCategoryIdAsync(int id)
        {
            var products = await _productRepository.GetByCategoryIdAsync(id);
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return productDtos;
        }
    }
}
