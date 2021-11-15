using Microsoft.AspNetCore.Mvc;
using Starter.API.Models;
using System.Text.Json;

namespace Starter.Web.Controllers
{
    public class PayStatementsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using var client = new HttpClient();

            var response = await client.GetAsync("http://localhost:8000/paystatement");
            var model = JsonSerializer.Deserialize<List<PayStatement>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(model);
        }
    }
}
