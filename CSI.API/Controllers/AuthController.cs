﻿using CSI.Application.DTOs;
using CSI.Application.Interfaces;
using CSI.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CSI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHashService _passwordHashService;

        public AuthController(IUserService userService, IJwtService jwtService, IPasswordHashService passwordHashService)
        {
            _userService = userService;
            _jwtService = jwtService;
            _passwordHashService = passwordHashService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginDto login)
        {
            var userDto = await _userService.AuthenticateAsync(login.Username, login.Password);

            if (userDto != null && userDto.Id != Guid.Empty)
            {
                return Ok(userDto);
            }
            return NotFound();
        }

        [HttpPost("LoginAD")]
        public async Task<IActionResult> LoginADAsync()
        {
            var userDto = await _userService.AuthenticateADAsync();

            if (userDto != null && userDto.Id != Guid.Empty)
            {
                return Ok(userDto);
            }
            return NotFound();
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> LogoutAsync(LoginDto login)
        {
            var userDto = await _userService.Logout(login.Username);

            if (userDto != null && userDto.Id != Guid.Empty)
            {
                return Ok(userDto);
            }
            return NotFound();
        }

        [HttpPost("GenerateToken")]
        public Task<IActionResult> GenerateToken(User objUser)
        {
            var token = _jwtService.GenerateToken(objUser);

            if (token != null && token != "")
            {
                return Task.FromResult<IActionResult>(Ok(token));
            }
            return Task.FromResult<IActionResult>(NotFound());
        }

        [HttpPost("GenerateSalt")]
        public Task<IActionResult> GenerateSalt(int salt)
        {
            var strSalt = _passwordHashService.GenerateSalt(salt);

            if (strSalt != null && strSalt != "")
            {
                return Task.FromResult<IActionResult>(Ok(strSalt));
            }
            return Task.FromResult<IActionResult>(NotFound());
        }

        [HttpPost("HashPassword")]
        public Task<IActionResult> HashPassword(string password)
        {
            int saltiness = 70;
            int nIterations = 10101;
            var strSalt = _passwordHashService.GenerateSalt(saltiness);
            var hashedPassword = _passwordHashService.HashPassword(password, strSalt, nIterations, saltiness);

            if (hashedPassword != null && hashedPassword != "")
            {
                return Task.FromResult<IActionResult>(Ok(hashedPassword));
            }
            return Task.FromResult<IActionResult>(NotFound());
        }
    }
}
