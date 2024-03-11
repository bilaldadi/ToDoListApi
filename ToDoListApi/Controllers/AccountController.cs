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
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signingManager)
        
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signingManager;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LogingDto logingDto)
        {
            try{
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _userManager.FindByNameAsync(logingDto.Username.ToLower());

                if(user == null)
                {
                    return Unauthorized("Invalid Email and/or Password");
                }
                var result = await _signInManager.CheckPasswordSignInAsync(user, logingDto.Password, false);
                if(!result.Succeeded)
                {
                    return Unauthorized("Invalid UserName and/or Password");
                }
                return Ok(
                    new NewUserDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.createToken(user)
                });
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
            
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