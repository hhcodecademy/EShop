using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public decimal UnitOfPrice { get; set; }
        public int TotalCount { get; set; }
        public string ProfileDocPath { get; set; }

        public List<ProductCategoryDto> CategoryDtos { get; set; }
    }
}
