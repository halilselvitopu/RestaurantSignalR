using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class DefaultSliderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
