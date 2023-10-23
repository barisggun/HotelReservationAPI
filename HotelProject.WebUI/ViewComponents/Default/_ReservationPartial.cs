using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _ReservationPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
