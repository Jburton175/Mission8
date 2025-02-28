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

            // Ensure the model has a default TaskId (0 for new tasks)
            return View(new Mission8.Models.Task { TaskId = 0 });
        }

        [HttpPost]
        public IActionResult SaveTask(Mission8.Models.Task app)
        {
            Debug.WriteLine("Received Task:");
            Debug.WriteLine($"Name: {app.name}");
            Debug.WriteLine($"DueDate: {app.due_date}");
            Debug.WriteLine($"Quadrant: {app.quadrant}");
            Debug.WriteLine($"Completed: {app.completed}");

            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Model is invalid.");
                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Debug.WriteLine($"Validation Error - {key}: {error.ErrorMessage}");
                    }
                }

                ViewBag.ErrorMessage = "There was an error saving the task. Please check the inputs.";
                ViewBag.Categories = new SelectList(_repo.GetCategories(), "category_id", "Category");
                return View("CreateTask", app);
            }

            try
            {
                _repo.AddTask(app);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                return View("CreateTask", app);
            }
        }







        [HttpGet]
        public IActionResult Edit(int id)
        {
            var record = _repo.GetTaskById(id);
            if (record == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_repo.GetCategories(), "category_id", "Category");

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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var record = _repo.GetTaskById(id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record); 
        }



        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTask(int id)
        {
            var task = _repo.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            _repo.DeleteTask(task);
            return RedirectToAction("Index");
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