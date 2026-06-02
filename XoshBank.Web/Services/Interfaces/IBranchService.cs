using XoshBank.Web.Models;

namespace XoshBank.Web.Services.Interfaces
{
    public interface IBranchService
    {
        List<BranchModel> Get();
    }
}