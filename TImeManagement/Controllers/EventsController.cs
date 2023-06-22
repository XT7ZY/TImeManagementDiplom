using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TImeManagement.Data;
using TImeManagement.Models;

namespace TImeManagement.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployerId,EventDay")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Событие добавлено";
                return RedirectToAction("Start", "Home");
            }
            ViewData["EmployerId"] = new SelectList(_context.employers, "Id", "LastName", @event.EmployerId);
            TempData["error"] = "Событие не добавлено, данные не прошли валидацию";
            return RedirectToAction("Start","Home");
        }

        [HttpGet]
        public JsonResult GetEvents()
        {
                var Data = _context.events
                    .Include(e => e.Employer)
                    .ToList();
                return new JsonResult(Data);
        }


        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public JsonResult DeleteEvent(int eventId)
        {
            var status = false;

                var v = _context.events.Where(a => a.Id == eventId).FirstOrDefault();
                if (v != null)
                {
                    _context.events.Remove(v);
                    _context.SaveChanges();
                    TempData["Success"] = "Событие удалено";
                    status = true;
                }
            return new JsonResult(status);
        }
    }
}
