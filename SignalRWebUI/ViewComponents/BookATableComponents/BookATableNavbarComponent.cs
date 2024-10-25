using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.BookATableComponents
{
    public class BookATableNavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
