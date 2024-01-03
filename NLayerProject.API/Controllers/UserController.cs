using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.DTOs;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        // api/Team/
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _userService.GetAllAsync();
            var userDto = _mapper.Map<List<UserDto>>(users.ToList());
            return CreateActionResult(CustomResponseData<List<UserDto>>.Success(200, userDto));
        }

        [HttpGet("{id}")]
        // Get api/user/3
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseData<UserDto>.Success(200, userDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(userDto));
            return CreateActionResult(CustomResponseData<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userService.GetById(id);
            await _userService.RemoveAsync(user);

            return CreateActionResult(CustomResponseData<NoContentDto>.Success(204));
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> SignUp(AuthRequestDto authDto)
        {
            var user = _userService.SignUp(authDto);
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseData<UserDto>.Success(201, userDto));
        }

        [HttpPost("Login")]
        public IActionResult Login(AuthRequestDto authDto)
        {
            var result = _userService.Login(authDto);
            if (result.User != null)
                return CreateActionResult(CustomResponseData<AuthResponseDto>.Success(200, result));
            else
                return CreateActionResult(CustomResponseData<AuthResponseDto>.Success(401, result));
        }
    }

}

