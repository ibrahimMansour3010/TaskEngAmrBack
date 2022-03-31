using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TaskEngAmr.DTOs;
using TaskEngAmr.Repositories.Abstraction;
using TaskEngAmr.Services.Abstraction;

namespace TaskEngAmr.Repositories
{
    public class Auth:IAuth
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly IMapper Mapper;
        private readonly IBasicService Service;
        public Auth(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            IMapper mapper, IBasicService service)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Mapper = mapper;
            Service = service;
        }
        public async Task<APIRequest<UserDTO.Get>>Register(UserDTO.Register model)
        {
            var response = new APIRequest<UserDTO.Get>();
            var user = Mapper.Map<IdentityUser>(model);
            var result = await UserManager.CreateAsync(user,model.Password);

            if (!result.Succeeded)
            {
                response.Status = false;
                string errors = "";
                foreach (var error in result.Errors)
                {
                    errors += error.Description + "\n";
                }

                response.Message = errors;
                return response;
            }
            user = await UserManager.FindByEmailAsync(user.Email);
            response.Status = true;
            response.Message = "Success";
            response.Response = Mapper.Map<UserDTO.Get>(user);

            return response;
        }
        public async Task<APIRequest<UserDTO.LoginResult>>Login(UserDTO.Login model)
        {
            var response = new APIRequest<UserDTO.LoginResult>();
            IdentityUser user = null;
            if(await UserManager.FindByNameAsync(model.UserNameOrEmail) != null)
            {
                user = await UserManager.FindByNameAsync(model.UserNameOrEmail);
            }else if (await UserManager.FindByEmailAsync(model.UserNameOrEmail) != null)
            {
                user = await UserManager.FindByEmailAsync(model.UserNameOrEmail);
            }
            if(user == null)
            {
                response.Status =false;
                response.Message = "Invalid Username Or Email";

                return response;
            }
            var result = await SignInManager.PasswordSignInAsync(user,model.Password,false,false);
            if (!result.Succeeded)
            {
                response.Status=false;
                response.Message = "Invalid Password";

                return response;
            }
            var userDTO = Mapper.Map<UserDTO.LoginResult>(user);
            userDTO.Token = await Service.GenerateToken(user);
            
            response.Status = true;
            response.Message = "Success";
            response.Response = userDTO;

            return response;
        }
    }
}
