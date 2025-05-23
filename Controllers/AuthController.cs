using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using iDss.X.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace iDss.X.Controllers
{
    [IgnoreAntiforgeryToken]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            if (user == null)
                return Unauthorized("Username salah");

            if (!await _userManager.CheckPasswordAsync(user, login.Password))
                return Unauthorized("Password salah");

            // Manual SignIn untuk Blazor Server tanpa race condition
            var claims = await _userManager.GetClaimsAsync(user);
            var identity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

            var principal = new ClaimsPrincipal(identity);
            //await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);
            //await HttpContext.SignInAsync(
            //    IdentityConstants.ApplicationScheme,
            //    principal,
            //    new AuthenticationProperties
            //    {
            //        IsPersistent = true, // true = simpan cookie login meski browser ditutup
            //        ExpiresUtc = DateTime.UtcNow.AddMinutes(60) // expired dalam 1 jam
            //    });

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, // Ganti dari IdentityConstants.ApplicationScheme
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                });// Set session storage



            return Ok();
        }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
