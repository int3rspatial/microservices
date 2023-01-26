using AutoMapper;
using BusinessLogicLevel.Interfaces;
using BusinessLogicLevel.Models;
using Microsoft.AspNetCore.Mvc;
using TaskPlannerWeb.Models;

namespace TaskPlannerWeb.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            IEnumerable<TaskViewModel> tasks = _mapper.Map<IEnumerable<TaskViewModel>>(_taskService.GetTasks());
            return View(tasks);
        }
        public IActionResult Create()//get
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskViewModel obj)//post
        {
            _taskService.CreateTask(_mapper.Map<TaskModel>(obj));
            TempData["success"] = "Task created successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)//todo: move all logic to bll
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var task = _taskService.GetTaskById((int)id);
            return View(_mapper.Map<TaskViewModel>(task));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskViewModel obj)//post
        {
            _taskService.EditTask(_mapper.Map<TaskModel>(obj));
            TempData["success"] = "Task edited successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)//todo: move all logic to bll
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            _taskService.DeleteTask((int)id);
            TempData["success"] = "Task deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
