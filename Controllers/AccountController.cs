using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MVCAPIs_Controller.DTOs;
using MVCAPIs_Controller.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MVCAPIs_Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(IConfiguration config, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.config = config;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }




        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO user)
        {
            try
            {

                AppUser newUser = new AppUser
                {
                    Email = user.Email,
                    FullName = user.FullNmae,
                    UserName = user.Email
                };

                var result = await userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded)
                {
                    // add rols to user if needed

                    return Ok($"The user [{user.Email}] is Registered");

                }
                else
                {
                    return StatusCode(500, result.Errors);
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }

        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDTO loginUser)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == loginUser.Email.ToLower());

            if (user is null)
                return Unauthorized("Invalid User Name");

            var signUser = await signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);

            if (!signUser.Succeeded)
            {
                return Unauthorized("Invalid user name or Password ");
            }
            return Ok(new { Email = loginUser.Email, Token = GenerateToken(user) });
        }


        private string GenerateToken(AppUser user)
        {

            var Claims = new List<Claim>
             {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName,user.FullName)
             };


            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config["JWT:skey"]));

            var signCred = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = signCred,
                Issuer = config["JWT:iss"],
                Audience = config["JWT:aud"],
                Expires = DateTime.Now.AddDays(1),
                Subject = new ClaimsIdentity(Claims)
            };

            var TokenHandler = new JwtSecurityTokenHandler();

            var token = TokenHandler.CreateToken(tokenDiscriptor);


            return TokenHandler.WriteToken(token);
        }





    }

}
