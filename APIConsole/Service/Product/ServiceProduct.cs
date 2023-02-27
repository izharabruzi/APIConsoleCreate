using APIConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIConsole.Service.Product
{
    public class ServiceProduct : IServiceProduct
    {
        public async Task<List<ProductModel>> GetAllProducts()
        {
            var url = "https://localhost:7188/api/Menu/GetProduct";
            var client = new HttpClient();
            var result = new List<ProductModel>();

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                var message = await client.SendAsync(request);

                var hhtpResult = await message.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<List<ProductModel>>(hhtpResult);

                return result;
            }

        }

        public async Task<int> AddProducts(ProductModel product)
        {
            HttpClient client = new HttpClient();
            var url = "https://localhost:7188/api/Menu/AddProductNew";
            var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
                return (int)response.StatusCode;
            }
        }
    }
}
