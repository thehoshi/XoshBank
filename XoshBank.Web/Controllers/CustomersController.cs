using Microsoft.AspNetCore.Mvc;
using XoshBank.Web.Models;
using XoshBank.Web.Services.Interfaces;

namespace XoshBank.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var customerModels = _customerService.Get();

            var customerUiModel = new CustomerUIModel
            {
                Customers = customerModels
            };

            return View(customerUiModel);
        }
    }

}
