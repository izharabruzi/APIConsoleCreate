using APIConsole.Model;
using APIConsole.Service.Category;
using APIConsole.Service.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIConsole
{

    internal class MenuConsole
    {
        private readonly IServiceCategory _serviceCategory;
        private readonly IServiceProduct _serviceProduct;

        public MenuConsole(IServiceCategory serviceCategory, IServiceProduct serviceProduct)
        {
            _serviceCategory = serviceCategory;
            _serviceProduct = serviceProduct;
        }


        public async Task<List<CategoryModel>> GetAllCategories(IServiceCategory serviceCategory)
        {
            //_serviceCategory = serviceCategory;
            var categories = await _serviceCategory.GetAllCategory();
            return categories;
        }

        public void PrintAllCategory(List<CategoryModel> categories)
        {
            foreach (var category in categories)
            {
                Console.WriteLine("Id: "+category.Id);
                Console.WriteLine("Category: "+category.Name);
                Console.WriteLine("Description: "+category.Description);
                Console.WriteLine();
            }
        }

        public async Task<CategoryModel> CreateNewCategory()
        {
            Console.Write("Masukan Nama Kategori: ");
            var name = Console.ReadLine();
            var category = new CategoryModel
            {
                Name = name
            };
            var statusCode = await _serviceCategory.AddCategory(category);

            if (statusCode == (int)HttpStatusCode.OK)
            {
                Console.Clear();
                Console.WriteLine("Nama Kategori Berhasil Ditambahkan!");
                Console.WriteLine("");

                var categories = await GetAllCategories(_serviceCategory);
                PrintAllCategory(categories);
                return category;
            }
            else
            {
                Console.WriteLine("Gagal menambahkan nama kategori :(");
                return null;
            }
        }


        public async Task<List<ProductModel>> GetAllProduct(IServiceProduct serviceProduct)
        {
            //_serviceProduct = serviceProduct;
            var products = await _serviceProduct.GetAllProducts();
            return products;
        }

        public void PrintAllProducts(List<ProductModel> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine("Id: " + product.Id);
                Console.WriteLine("Produk: " + product.Name);
                Console.WriteLine("Price: " + product.Price);
                Console.WriteLine("Description: " + product.Description);
                Console.WriteLine();
            }
        }

        public async Task<ProductModel> CreateNewProduct()
        {
            Console.Write("Masukan Nama Kategori: ");
            var categoriesproduct = await _serviceCategory.GetAllCategory();
            PrintAllCategory(categoriesproduct);
            Console.Clear();
            Console.WriteLine("List Kategori:");
            Console.WriteLine("");
            Console.WriteLine("Id Kategori|| Nama Kategori");
            Console.WriteLine("");
            foreach (var category in categoriesproduct)
            {
                Console.WriteLine($"{category.Id}. {category.Name}");
                Console.WriteLine();
            }

            Console.Write("Masukkan Id Kategori: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Produk: ");
            string productName = Console.ReadLine();
            Console.Write("Masukkan Harga Produk: ");
            decimal productPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Masukkan Deskripsi Produk: ");
            string productDescription = Console.ReadLine();

            // Create a new ProductModel object with the user's input
            var product = new ProductModel
            {
                Name = productName,
                CategoryId = categoryId,
                Price = productPrice,
                Description = productDescription
            };
            var statusCode = await _serviceProduct.AddProducts(product);
            if (statusCode == (int)HttpStatusCode.OK)
            {
                Console.Clear();
                Console.WriteLine("Produk Berhasil Ditambahkan!");
                Console.WriteLine("");

                var products = await GetAllProduct(_serviceProduct);
                PrintAllProducts(products);
                return product;
            }
            else
            {
                Console.WriteLine("Gagal menambahkan produk :(");
                return null;
            }
        }

    }
}
