using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DiscoverComponents
{
    public class DiscoverNavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View();
        }

    }
}
