using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIConsole.Model;
using System.Text.Json;

namespace APIConsole.Service.Category
{
    public class ServiceCategory : IServiceCategory
    {
        public async Task<List<CategoryModel>> GetAllCategory()
        {
            var url = "https://localhost:7188/api/Menu/GetCategory";
            var client = new HttpClient();
            var result = new List<CategoryModel>();

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                var message = await client.SendAsync(request);

                var hhtpResult = await message.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<List<CategoryModel>>(hhtpResult);

                return result;
            }

        }

        public async Task<int> AddCategory(CategoryModel category)
        {
            HttpClient client = new HttpClient();
            var url = "https://localhost:7188/api/Menu/AddCategoryNew";
            var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
                return (int)response.StatusCode;
            }
        }
    }
}
