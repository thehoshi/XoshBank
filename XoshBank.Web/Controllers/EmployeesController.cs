using Microsoft.AspNetCore.Mvc;
using XoshBank.Web.Models;
using XoshBank.Web.Services.Interfaces;

namespace XoshBank.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employeeModels = _employeeService.Get();

            var employeeUiModel = new EmployeeUiModel
            {
                Employees = employeeModels
            };

            return View(employeeUiModel);
        }
    }
}
