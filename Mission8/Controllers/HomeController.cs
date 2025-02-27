using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission8.Models;

// Quadrants 
// CreateTasks

namespace Mission8.Controllers
{
    public class HomeController : Controller
    {
        private InterfaceMission8 _repo;

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
            ViewBag.Categories = new SelectList(_repo.GetCategories(), "category_id", "Category");

            return View();
        }


        [HttpPost]
        public IActionResult SaveTask(Models.Task app)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(app);
                return RedirectToAction("Index");
            }

            return View(app);
        }


        [HttpGet]
        public IActionResult Edit(int TaskId)
        {
            var record = _repo.GetTaskById(TaskId);

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

            return View(app);
        }

        //[HttpGet]
        //public IActionResult Delete(int TaskId)
        //{
        //}

        //[HttpPost]
        //public IActionResult Delete(Models.Task app)
        //{ }


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