using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission8.Models;

// Quadrants 
// CreateTasks

namespace Mission8.Controllers
{
    public class HomeController : Controller
    {
        private InterfaceMission8 _repo;

        // Constructor injection for the repository
        public HomeController(InterfaceMission8 temp)
        {
            _repo = temp;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var tasks = _repo.Tasks.ToList();
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Index(Models.Task t)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(t);
                return RedirectToAction("Index");
            }
            return View(new Models.Task());
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var record = _repo.GetTaskById(id);

            if (record == null)
            {
                return NotFound();
            }

            return View("CreateTask", record);
        }

        [HttpPost]
        public IActionResult Edit(Models.Task app)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(app);
                return RedirectToAction("Index");
            }

            return View("CreateTask", app);
        }
    }
}

// create and edit are the same post 
// get is only different because the create does not pass data while the edit has to receive data 

// Index has add and delete
// CreateTask has a form that 
// The CreateTask needs to be passed the ID of the data 

// Index needs to receive a model in the form of a list 
// Index receives a whole data object 

// createtask will need 