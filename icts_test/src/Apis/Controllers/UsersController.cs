using System.Text;
using icts_test.Entities.Entities;
using icts_test.WebAPIs.Models;
using icts_test.WebAPIs.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace icts_test.WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _singInManager;

        public UsersController(
            UserManager<User> userManager,
            SignInManager<User> singInManager
        )
        {
            _userManager = userManager;
            _singInManager = singInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/authentication")]
        public async Task<IActionResult> Authentication(
            [FromBody] Login login
        )
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
            {
                return Unauthorized();
            }

            var result = await _singInManager.PasswordSignInAsync(login.Email, login.Senha, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var userCurrent = await _userManager.FindByNameAsync(login.Email);
                var idUser = userCurrent.Id;

                var token = new TokenJWTBuilder().AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                    .AddSubject("Empresa - ICTS")
                    .AddIssuer("Teste.Security.Bearer")
                    .AddAudience("Teste.Security.Bearer")
                    .AddClaim("idUser", idUser)
                    .AddExpiry(30)
                    .Builder();

                return Ok(token.value);
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/new-user")]
        public async Task<IActionResult> NewUser(
            [FromBody] Login login
        )
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
            {
                return BadRequest("Favor preencher dados restantes.");
            }

            var user = new User
            {
                UserName = login.Email,
                Email = login.Email,
                Cpf = login.Cpf
            };

            var result = await _userManager.CreateAsync(user, login.Senha);

            if (result.Errors.Any())
                return BadRequest(result.Errors);

            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var resultFinal = await _userManager.ConfirmEmailAsync(user, code);

            if (resultFinal.Succeeded)
                return Ok("Usuário criado com sucesso");

            return BadRequest("Erro ao confirmar usuário");
        }
    }
}