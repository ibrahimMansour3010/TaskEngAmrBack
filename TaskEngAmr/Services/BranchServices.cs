using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskEngAmr.DTOs;
using TaskEngAmr.Models;
using TaskEngAmr.Repositories.Abstraction;
using TaskEngAmr.Services.Abstraction;

namespace TaskEngAmr.Services
{
    public class BranchServices : IBranchServices
    {
        private readonly IMainRepo<Branch> _branchRepo;
        private readonly IMapper _mapper;

        public BranchServices(IMainRepo<Branch> branchRepo, IMapper mapper)
        {
            _branchRepo = branchRepo;
            _mapper = mapper;
        }
        public async Task<APIRequest<BranchDTO.Get>> GetAllBranches(int pageNumber, int pageSize)
        {
            var response = new APIRequest<BranchDTO.Get>();
            var branches = (await _branchRepo.Get())
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize).ToList();
            if (branches == null || branches.Count() == 0)
            {
                response.Status = false;
                response.Message = "There Is No Branches";

                return response;
            }
            var data = branches.Select(_mapper.Map<BranchDTO.GetEdit>).ToList();
            var DTO = new BranchDTO.Get()
            {
                Data = data,
                Size = (await _branchRepo.Get()).Count()
            };
            response.Response = DTO;
            response.Status = true;
            response.Message = "Success";

            return response;
        }
        public async Task<APIRequest<BranchDTO.GetEdit>> GetBranchById(int Id)
        {
            var response = new APIRequest<BranchDTO.GetEdit>();
            var branch = await _branchRepo.Get(Id);
            if (branch == null)
            {
                response.Status = false;
                response.Message = "Invalid Branch Id";

                return response;
            }

            response.Status = true;
            response.Message = "Success";
            response.Response = _mapper.Map<BranchDTO.GetEdit>(branch);

            return response;
        }
        public async Task<APIRequest<BranchDTO.GetEdit>> AddBranch(BranchDTO.Add model)
        {
            var response = new APIRequest<BranchDTO.GetEdit>();
            var branch = _mapper.Map<Branch>(model);
            branch = await _branchRepo.Add(branch);
            await _branchRepo.SaveChanges();
            if (branch == null)
            {
                response.Status = false;
                response.Message = "Failed To Add";

                return response;
            }

            response.Status = true;
            response.Message = "Success";
            response.Response = _mapper.Map<BranchDTO.GetEdit>(branch);

            return response;
        }
        public async Task<APIRequest<BranchDTO.GetEdit>> EditBranch(BranchDTO.GetEdit model)
        {
            var response = new APIRequest<BranchDTO.GetEdit>();
            var branch = await _branchRepo.Get(model.Id);
            if (branch == null)
            {
                response.Status = false;
                response.Message = "Invalid Branch Id";

                return response;
            }
            branch = await _branchRepo.Edit(_mapper.Map<Branch>(model));
            await _branchRepo.SaveChanges();
            if (branch == null)
            {
                response.Status = false;
                response.Message = "Failed Updated";

                return response;
            }
            response.Status = true;
            response.Message = "Success";
            response.Response = _mapper.Map<BranchDTO.GetEdit>(branch);

            return response;
        }
        public async Task<APIRequest<BranchDTO.GetEdit>> DeleteBranch(int Id)
        {
            var response = new APIRequest<BranchDTO.GetEdit>();
            var branch = await _branchRepo.Get(Id);
            if (branch == null)
            {
                response.Status = false;
                response.Message = "Invalid Branch Id";

                return response;
            }
            branch = await _branchRepo.Delete(branch);
            await _branchRepo.SaveChanges();
            if (branch == null)
            {
                response.Status = false;
                response.Message = "Failed Deleted";

                return response;
            }
            response.Status = true;
            response.Message = "Success";
            response.Response = _mapper.Map<BranchDTO.GetEdit>(branch);

            return response;
        }
    }
}
