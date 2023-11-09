using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserWorkLocation : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserWorkLocation(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Context context = new Context();
            //var values = _appUserService.TUserListWithWorkLocations();
            var values = context.Users.Include(x => x.WorkLocation).Select(y => new AppUserWorkLocationViewModel
            {
                Name = y.Name,
                Surname = y.Surname,
                WorkLocationID = (int)y.WorkLocationID,
                WorkLocationName = y.WorkLocation.WorkLocationName
            }).ToList();

            return Ok(values);
        }
    }
}
