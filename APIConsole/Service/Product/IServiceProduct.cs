using APIConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIConsole.Service.Product
{
    interface IServiceProduct
    {
        public Task<List<ProductModel>> GetAllProducts();
        Task<int> AddProducts(ProductModel product);
    }
}
