using Microsoft.AspNetCore.Mvc;

namespace romerogates_shopping_list.Controllers
{
    public class ListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
