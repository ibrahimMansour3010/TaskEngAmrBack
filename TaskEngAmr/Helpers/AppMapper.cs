using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TaskEngAmr.DTOs;
using TaskEngAmr.Models;

namespace TaskEngAmr.Helpers
{
    public class AppMapper:Profile
    {
        public AppMapper()
        {
            CreateMap<IdentityUser,UserDTO.Register>().ReverseMap();
            CreateMap<IdentityUser,UserDTO.Login>().ReverseMap();
            CreateMap<IdentityUser,UserDTO.LoginResult>().ReverseMap();
            CreateMap<IdentityUser,UserDTO.Get>().ReverseMap();


            CreateMap<Branch,BranchDTO.Add>().ReverseMap();
            CreateMap<Branch,BranchDTO.GetEdit>().ReverseMap();
        }
    }
}
