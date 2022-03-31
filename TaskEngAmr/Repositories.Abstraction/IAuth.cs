using System.Threading.Tasks;
using TaskEngAmr.DTOs;

namespace TaskEngAmr.Repositories.Abstraction
{
    public interface IAuth
    {
        Task<APIRequest<UserDTO.Get>> Register(UserDTO.Register model);
        Task<APIRequest<UserDTO.LoginResult>> Login(UserDTO.Login model);
    }
}
