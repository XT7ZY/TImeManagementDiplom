using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace TImeManagement.Controllers
{
    public class EmployerController : Controller
    {
        [Authorize(Policy = "EmployOnly")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Test()
        {
            return View();
        }
    }
}
