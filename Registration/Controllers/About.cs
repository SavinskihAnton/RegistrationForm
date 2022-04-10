using Microsoft.AspNetCore.Mvc;

namespace Registration.Controllers
{
    public class About : Controller
    {
        public IActionResult Abouts()
        {
            return View();
        }
    }
}
