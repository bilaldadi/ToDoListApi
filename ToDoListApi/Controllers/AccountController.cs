using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Dtos.Account;
using ToDoListApi.Interfaces;
using ToDoListApi.Models;

namespace ToDoListApi.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
        
        {
            _userManager = userManager;
            _tokenService = tokenService;

        }   

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto regestirDto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var AppUser = new AppUser
                {
                    UserName = regestirDto.Username,
                    Email = regestirDto.Email
                };
                var createdUser = await _userManager.CreateAsync(AppUser, regestirDto.Password);
                if(createdUser.Succeeded)
                {
                    var RoleResult = await _userManager.AddToRoleAsync(AppUser, "User");
                    if(RoleResult.Succeeded)
                    {
                        return Ok(new NewUserDto
                        {
                            Username = AppUser.UserName,
                            Email = AppUser.Email,
                            Token = _tokenService.createToken(AppUser)
                        });
                    }
                    else
                    {
                        return BadRequest(RoleResult.Errors);
                    }
                }
                else
                {
                    return BadRequest(createdUser.Errors);
                }


            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
    }
}