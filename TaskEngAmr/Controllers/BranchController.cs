using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskEngAmr.DTOs;
using TaskEngAmr.Services.Abstraction;

namespace TaskEngAmr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchServices _branchServices;
        public BranchController(IBranchServices branchServices)
        {
            _branchServices = branchServices;
        }
        [Authorize]
        [HttpGet("GetAllBranches")]
        public async Task<IActionResult> GetAllBranches()
        {
            try
            {
                return Ok(await _branchServices.GetAllBranches());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("GetBranchById/{Id}")]
        public async Task<IActionResult> GetBranchById(int Id)
        {
            try
            {
                return Ok(await _branchServices.GetBranchById(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("AddBranch")]
        public async Task<IActionResult> AddBranch(BranchDTO.Add model)
        {
            try
            {
                return Ok(await _branchServices.AddBranch(model));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPut("EditBranch")]
        public async Task<IActionResult> EditBranch(BranchDTO.GetEdit model)
        {
            try
            {
                return Ok(await _branchServices.EditBranch(model));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpDelete("DeleteBranch/{Id}")]
        public async Task<IActionResult> DeleteBranch(int Id)
        {
            try
            {
                return Ok(await _branchServices.DeleteBranch(Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
