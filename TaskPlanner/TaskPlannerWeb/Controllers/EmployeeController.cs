using AutoMapper;
using BusinessLogicLevel.Interfaces;
using BusinessLogicLevel.Models;
using BusinessLogicLevel.Services;
using Microsoft.AspNetCore.Mvc;
using TaskPlannerWeb.Models;

namespace TaskPlannerWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var employees = _employeeService.GetEmployees();
            return View(_mapper.Map<IEnumerable<EmployeeViewModel>>(employees));
        }
        public IActionResult Create()//get
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel obj)//post
        {
            _employeeService.AddEmployee(_mapper.Map<EmployeeModel>(obj));
            TempData["success"] = "Employee created successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)//todo: move all logic to bll
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var employee = _employeeService.GetEmployeeById(id.Value);
            return View(_mapper.Map<EmployeeViewModel>(employee));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel obj)//post
        {
            _employeeService.EditEmployee(_mapper.Map<EmployeeModel>(obj));
            TempData["success"] = "Employee edited successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (IsValidIdentifier(id))
            {
                return NotFound();
            }
            _employeeService.RemoveEmployee((int)id);
            TempData["success"] = "Employee removed successfully";
            return RedirectToAction("Index");
        }
        private bool IsValidIdentifier(int? id)
        {
            return !(id.HasValue || id == 0);
        }

    }
}
