using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace TaskEngAmr.Services.Abstraction
{
    public interface IBasicService
    {
        Task<string> GenerateToken(IdentityUser user);
    }
}
