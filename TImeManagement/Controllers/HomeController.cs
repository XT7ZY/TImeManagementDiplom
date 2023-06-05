using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Diagnostics;
using TImeManagement.Data;
using TImeManagement.Models;
using TImeManagement.ViewModels.Account;

namespace TImeManagement.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Start()
        {
            return View();
        }

        public IActionResult Test()
        {
            List<Day> list = _context.days.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Event obj)
        {
            _context.events.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Start");
        }

        public JsonResult GetEvents()
        {
            using (var context = _context)
            {
                var Data = context.events
                    .Include(e=>e.Employer)
                    .ToList();
                return new JsonResult(Data);
            }
        }
    }
}