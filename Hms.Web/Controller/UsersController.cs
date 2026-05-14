using Hms.Models;
using Hms.Services;
using Hms.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private IApplicationUserService _userService;

        public UsersController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int PageNumber=1,int PageSize=10)
        {
            return View(_userService.GetAll(PageNumber,PageSize));
        }

        public IActionResult AllDoctors(int PageNumber = 1, int PageSize = 10)
        {
            return View(_userService.GetAll(PageNumber, PageSize));
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ApplicationUserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _userService.InsertUsers(vm);

                return RedirectToAction("Index");
            }

            return View(vm);
        }
    }
}
