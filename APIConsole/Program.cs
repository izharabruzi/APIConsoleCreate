//using Azure.Core;
using APIConsole.Model;
using APIConsole.Service.Category;
using APIConsole.Service.Product;
using Nest;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;


namespace APIConsole

{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCategory serviceCategory = new ServiceCategory();
            IServiceProduct serviceProduct = new ServiceProduct();
            var menuConsole = new MenuConsole(serviceCategory, serviceProduct);

        //######################## console #################
        menupertama:
            Console.WriteLine("Tampilan Awal Menu:");
            Console.WriteLine("1. Tampilkan Semua Kategori");
            Console.WriteLine("2. Tampilkan Semua Produk");
            Console.WriteLine("3. Keluar Console");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Console.Clear();
            listsemuakategorilagi:
                Console.WriteLine("==============LIST SEMUA KATEGORI================");
                Console.WriteLine("");
                List<CategoryModel> categories = await menuConsole.GetAllCategories(serviceCategory);
                menuConsole.PrintAllCategory(categories);

                Console.WriteLine("Tambahkan Kategori? Y/N?");
                string userInput11 = Console.ReadLine().ToUpper();
                if (userInput11 == "Y")
                {
                    Console.Clear();
                tambahkankategorilagi:
                    var newCategory = await menuConsole.CreateNewCategory();
                    Console.WriteLine($"Nama Kategori yang ditambahkan adalah = {newCategory.Name}!");
                    Console.WriteLine("");
                    Console.WriteLine("Tambahkan Nama Kategori Lagi? (Y/N)");
                    string userInput12 = Console.ReadLine().ToUpper();
                    if (userInput12 == "Y")
                    {
                        Console.Clear();
                        goto tambahkankategorilagi;
                    }
                    else if (userInput12 == "N")
                    {
                        Console.Clear();
                        goto menupertama;

                    }
                }
                else if (userInput11 == "N")
                {
                    Console.Clear();
                    goto menupertama;
                }
            }
            else if (userInput == "2")
            {
                Console.Clear();
                Console.WriteLine("==============LIST SEMUA PRODUK================");
                Console.WriteLine("");
                List<ProductModel> products = await menuConsole.GetAllProduct(serviceProduct);
                menuConsole.PrintAllProducts(products);
                Console.WriteLine("Tambahkan Produk? Y/N?");
                string userInput2 = Console.ReadLine().ToUpper();
                if (userInput2 == "Y")
                {
                    Console.Clear();
                tambahkanproduklagi:
                    var createdProduct = await menuConsole.CreateNewProduct();
                    Console.WriteLine($"Nama Produk yang ditambahkan adalah = {createdProduct.Name}!");
                    Console.WriteLine("");
                    Console.WriteLine("Tambahkan Produk Lagi? (Y/N)");
                    string userInput21 = Console.ReadLine().ToUpper();
                    if (userInput21 == "Y")
                    {
                        Console.Clear();
                        goto tambahkanproduklagi;
                    }
                    else if (userInput21 == "N")
                    {
                        Console.Clear();
                        goto menupertama;

                    }

                }
                else if (userInput2 == "N")
                {
                    Console.Clear();
                    goto menupertama;
                }
            }
            else
            {
                Console.WriteLine("Terimakasih");
            }

           



        }


    }
}