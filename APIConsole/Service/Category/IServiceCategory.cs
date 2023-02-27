using APIConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIConsole.Service.Category
{
    interface IServiceCategory
    {
        public Task<List<CategoryModel>> GetAllCategory();
        Task<int> AddCategory(CategoryModel category);


    }
}
