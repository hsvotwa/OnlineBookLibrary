using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using OnlineLibrary.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using OnlineLibrary.Services;
using OnlineLibrary.Models;
using OnlineLibrary.ViewModels;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;

        public UsersController(
            IUserService userService,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = user.UserId,
                Username = user.Username,
                FullName = user.FullName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            try
            {
                _userService.Create(new User
                {
                    FullName = model.FullName,
                    Username = model.Username,
                }, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
