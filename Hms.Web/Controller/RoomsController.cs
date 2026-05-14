using Hms.Services;
using Hms.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Hms.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoomsController : Controller
    {
        private readonly IRoomService _room;

        public RoomsController(IRoomService room)
        {
            _room = room;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_room.GetAll(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _room.GetRoomById(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(RoomViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _room.UpdateRoom(vm);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _room.InsertRoom(vm);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var viewModel = _room.GetRoomById(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            _room.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}