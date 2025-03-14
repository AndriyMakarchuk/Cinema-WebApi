using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HallsController : Controller
    {
        ICinemaHallService _service;
        public HallsController(ICinemaHallService service)
        {
            _service = service;
        }
        //GET: /Halls/Add
        //GET: /Halls
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
        //GET: /Halls/Add
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }
        //POST: /Halls/Add
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(CinemaHallDTO hall)
        {
            if (!ModelState.IsValid) 
            {
                return View(hall);
            }
            _service.Create(hall);
            return RedirectToAction(nameof(Index));
        }

    }
}
