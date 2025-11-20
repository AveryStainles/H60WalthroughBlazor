namespace OnlineShop.States;
using OnlineShop.Models;
using System.Net.Http;
using System.Net.Http.Json;

public class CartState(HttpClient _httpClient)
{
    public List<Product> SelectedItems { get; set; } = new();

    public async Task AddProductToCartAsync(Guid productId)
    {
        if (!SelectedItems.Any(p => p.Id == productId) is false)
            return;

        var products = await _httpClient.GetFromJsonAsync<List<Product>>("sample-data/books.json") ?? new();
        var product = products.First(p => p.Id == productId);
        SelectedItems.Add(product);
    }
}