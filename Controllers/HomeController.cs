using Cau4.Models;  // Đảm bảo namespace đúng

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;


    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7297/api/HangHoa");

        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<List<HangHoa>>();
            return View(data); // ✅ Đảm bảo truyền model vào View
        }

        return View(new List<HangHoa>()); // ✅ Trả về danh sách rỗng nếu có lỗi
    }
}
