
using Microsoft.AspNetCore.Mvc;

namespace OrderManagerMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
