using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult NotFound404Page()
        {
            return View();
        }
    }
}
