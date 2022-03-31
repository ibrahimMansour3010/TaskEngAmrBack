using System.Collections.Generic;
using System.Threading.Tasks;
using TaskEngAmr.DTOs;

namespace TaskEngAmr.Services.Abstraction
{
    public interface IBranchServices
    {
        Task<APIRequest<BranchDTO.Get>> GetAllBranches(int pageNumber, int pageSize);
        Task<APIRequest<BranchDTO.GetEdit>> GetBranchById(int Id);
        Task<APIRequest<BranchDTO.GetEdit>> AddBranch(BranchDTO.Add model);
        Task<APIRequest<BranchDTO.GetEdit>> EditBranch(BranchDTO.GetEdit model);
        Task<APIRequest<BranchDTO.GetEdit>> DeleteBranch(int Id);
    }
}
