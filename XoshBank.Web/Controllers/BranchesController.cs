using Microsoft.AspNetCore.Mvc;
using XoshBank.Web.Models;
using XoshBank.Web.Services.Interfaces;

namespace XoshBank.Web.Controllers
{
    public class BranchesController : Controller
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public IActionResult Index()
        {
            var branchModels = _branchService.Get();

            var branchUiModel = new BranchUiModel
            {
                Branches = branchModels
            };

            return View(branchUiModel);
        }
    }
}