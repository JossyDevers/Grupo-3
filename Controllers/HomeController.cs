using Microsoft.AspNetCore.Mvc;
using StudentService.Models;
using System.Diagnostics;

namespace StudentService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Principal()
        {
            return View();
        }

        public IActionResult Miembros()
        {
            return View();
        }
    }
}
