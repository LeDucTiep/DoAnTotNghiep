using AutoMapper;
using ldtiep.be.BL.Dto;
using ldtiep.be.DL.Entity;
using ldtiep.be.DL.Model;

namespace ldtiep.be.BL
{
    /// <summary>
    /// Class dành cho automapper 
    /// </summary>
    /// Author: LeDucTiep (07/06/2023)
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserCreateDto>();
            CreateMap<UserCreateDto, UserDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserDto, UserCreateDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserUpdateDto, UserDto>();
            CreateMap<UserDto, UserUpdateDto>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<BasePage<User>, BasePage<UserDto>>();
        }
    }
}
