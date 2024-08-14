using Prueba.Model.Request;
using System.Text.Json;

namespace Prueba.Servicios
{
    public class ProductosBL : IProductosBL
    {
      

        public async Task<List<ProductosResponse>> GET()        
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7227/api/");
            string url = "Products";

            HttpResponseMessage responseApi = await client.GetAsync(url);

            if (responseApi.IsSuccessStatusCode)
            {
                var responseContent = await responseApi.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<List<ProductosResponse>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return response;
            }
            return null;           
        
        }
    }
}
