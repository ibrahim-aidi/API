using API.Dtos;
using API.Models;
using API.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase { 
            private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
     public async Task<ActionResult<ServiceResponse<string>>> Login(UserLogin request)
        {
            var response = await _authService.Login(request.Login, request.Password);
            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }




        [HttpPost("register") , Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
        {
            var response = await _authService.Register(
                new User
                {
                    Login = request.Login,
                    Prenom = request.Prenom,
                    Nom = request.Nom,
                    Email = request.Email,
                    Telephone = request.Telephone,
                    Role = request.Role,
                    Etat = request.Etat
                },
                request.Password);

            if (response.Data == 0)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }


    }