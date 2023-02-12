using EShop.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Repository.Interfaces
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        public Task<List<Product>> GetByCategoryIdAsync(int id);
    }
}
