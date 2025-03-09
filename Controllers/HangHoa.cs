using Cau4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cau4_MVC.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://localhost:7297/api/HangHoa"; // Đổi theo API của bạn

        public HangHoaController()
        {
            _httpClient = new HttpClient();
        }

        // Lấy danh sách hàng hóa
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync(_apiBaseUrl);
            var hangHoas = JsonConvert.DeserializeObject<List<HangHoa>>(response);
            return View(hangHoas);
        }

        // Form thêm mới hàng hóa
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HangHoa hangHoa)
        {
            var response = await _httpClient.PostAsJsonAsync(_apiBaseUrl, hangHoa);
            return RedirectToAction("Index");
        }
    }
}
