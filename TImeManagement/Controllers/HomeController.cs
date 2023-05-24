using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TImeManagement.Models;

namespace TImeManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Start()
        {
            return View();
        }
    }
}