using Microsoft.AspNetCore.Mvc;
using ldtiep.be.BL.Dto;
using ldtiep.be.BL.Service;
using ldtiep.be.Controllers;
using ldtiep.be.DL.Entity;
using ldtiep.be.Common;

namespace ldtiep.be.api.Controllers
{
    [Route("api/v1/[controller]s")]
    public class UserController : BaseController<User, UserDto, UserCreateDto, UserUpdateDto>
    {
        public IUserService _userService;
        public UserController(IUserService userService
            ) : base(userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// API thêm một bản ghi
        /// </summary>
        /// <param name="entityCreateDto">Thông tin tài khoản cần thêm</param>
        /// <exception cref="BadRequestException">Lỗi thông tin bản ghi</exception>
        /// <returns>Id bản ghi vừa thêm</returns>
        /// Author: LeDucTiep (23/05/2023)
        [HttpPost]
        public override async Task<IActionResult> PostAsync(UserCreateDto entityCreateDto)
        {
            if (entityCreateDto == null)
            {
                throw new BadRequestException();
            }
            UserDto entityDto = await _userService.PostAsync(entityCreateDto);

            return StatusCode(201, entityDto);
        }
    }
}
