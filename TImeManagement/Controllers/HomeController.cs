using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            ViewData["EmployerId"] = new SelectList(_context.employers, "Id", "LastName");
            return View();
        }
    }
}