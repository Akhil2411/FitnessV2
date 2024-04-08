using FitnessApp.Facade.IFacade;
using FitnessApp.Infrastructure.Models;
using FitnessApp.Service.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitnessApp.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthFacade _authFacade;
        private readonly IConfiguration _config;
        public AuthController(IAuthFacade authFacade,IConfiguration config)
        {
             _authFacade = authFacade;
            _config = config;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserLoginResponseModel>> Login(UserLoginModel model)
        {

            bool isUserExist = await _authFacade.CheckByEmailAsync(model.Email);
            if (!isUserExist)
            {
                return Unauthorized(new UserLoginResponseModel { ErrorMessage = "Invalid Email" });
            }

            UserModel user=await _authFacade.CheckPasswordAsync(model);

            if (user == null)
            {
                return Unauthorized(new UserLoginResponseModel { ErrorMessage = "Incorrect Password" });
            }

            string token=string.Empty;
            string errorMessage=string.Empty;
            bool isLoginSuccess = false;
            if (user!=null)
            {
                isLoginSuccess = true;
                var jwtTokenOptions = JWTTokenHelper.GenerateToken(_config, "akhil", user.Email);
                token = new JwtSecurityTokenHandler().WriteToken(jwtTokenOptions);
            }
          
            var response = new UserLoginResponseModel()
            {
                IsAuthenticationSuccess = isLoginSuccess,
                ErrorMessage = errorMessage,
                Token = token
            };

            return Ok(response);
            
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserDetailModel>>> GetAllUsers()
        {
            try
            {
                var data = await _authFacade.GetAllUsers();
                return Ok(data);
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
