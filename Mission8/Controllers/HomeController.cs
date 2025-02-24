using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission8.Models;

namespace Mission8.Controllers
{
    public class HomeController : Controller
    {
        private InterfaceMission8 _repo;
        public HomeController(InterfaceMission8 temp) 
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var tasks = _repo.Task.ToList();

            return View(tasks);
        }

    }
}
