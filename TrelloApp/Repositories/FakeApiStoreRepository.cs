using System.Text.Json;
using TrelloApp.Data;

namespace TrelloApp.Repositories
{
    public interface IFakeApiStoreRepository
    {
        public Task<List<Producto>> GetAllData();
        public Task<Producto> GetOneProducto(int id);
        public Task<List<Category>> GetAllCategories();
    }
    public class FakeApiStoreRepository : IFakeApiStoreRepository
    {
        JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        public async Task<List<Producto>> GetAllData()
        {
            var url = "https://fakestoreapi.com/products/";
            var httpclient = new HttpClient();
            var response = await httpclient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<Producto>>(content, options);
                return products;
            }
            else
            {
                return null;
            }

        }

        public async Task<Producto> GetOneProducto(int id)
        {
            var url = "https://fakestoreapi.com/products/";
            var httpclient = new HttpClient();
            var response = await httpclient.GetAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode) 
            {
                var content = await response.Content.ReadAsStringAsync();
                var producto = JsonSerializer.Deserialize<Producto>(content, options);
                return producto;
            }
            else { return null; }
        }
        public async Task<List<Category>> GetAllCategories()
        {
            var url = "https://fakestoreapi.com/products/categories";
            var httpclient = new HttpClient();
            var response = await httpclient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var categories = JsonSerializer.Deserialize<List<Category>>(content);
                return categories;
            }
            else return null;
            
        }
    }
}
