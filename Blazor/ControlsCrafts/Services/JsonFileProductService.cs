using ControlsCrafts.Models;
using System.Text.Json;

namespace ControlsCrafts.Services
{
    public class JsonFileProductService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        string JsonFileName
        {
            get => Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");
        }
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IEnumerable<Product> GetProducts()
        {
            using StreamReader jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
