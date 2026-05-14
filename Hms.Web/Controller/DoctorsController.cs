using Hms.Models;
using Hms.Services;
using Hms.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Hms.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorService;

        // Constructor
        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // ================= INDEX =================

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_doctorService.GetAll(pageNumber, pageSize));
        }

        // ================= ADD TIMING =================

        [HttpGet]
        public IActionResult AddTiming()
        {
            List<SelectListItem> morningShiftStart = new List<SelectListItem>();
            List<SelectListItem> morningShiftEnd = new List<SelectListItem>();
            List<SelectListItem> afternoonShiftStart = new List<SelectListItem>();
            List<SelectListItem> afternoonShiftEnd = new List<SelectListItem>();

            // Morning Start
            for (int i = 1; i <= 11; i++)
            {
                morningShiftStart.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

            // Morning End
            for (int i = 1; i <= 13; i++)
            {
                morningShiftEnd.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

            // Afternoon Start
            for (int i = 13; i <= 16; i++)
            {
                afternoonShiftStart.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

            // Afternoon End
            for (int i = 13; i <= 18; i++)
            {
                afternoonShiftEnd.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }

            ViewBag.morningStart = new SelectList(morningShiftStart, "Value", "Text");
            ViewBag.morningEnd = new SelectList(morningShiftEnd, "Value", "Text");
            ViewBag.evenStart = new SelectList(afternoonShiftStart, "Value", "Text");
            ViewBag.evenEnd = new SelectList(afternoonShiftEnd, "Value", "Text");

            TimingViewModel vm = new TimingViewModel();
            vm.Date = DateTime.Now.AddDays(1);

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddTiming(TimingViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity!;

                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                if (claim != null)
                {
                    vm.DoctorId = claim.Value;
                }

                _doctorService.AddTiming(vm);

                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // ================= EDIT =================

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _doctorService.GetTimingById(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(TimingViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _doctorService.UpdateTiming(vm);

                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // ================= DETAILS =================

        [HttpGet]
        public IActionResult Details(int id)
        {
            var viewModel = _doctorService.GetTimingById(id);

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // ================= DELETE =================

        public IActionResult Delete(int id)
        {
            _doctorService.DeleteTiming(id);

            return RedirectToAction("Index");
        }
    }
}