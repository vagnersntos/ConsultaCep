using ConsultaCep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConsultaCep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if (login.Login == "admin" && login.Password == "123")
            {
                var token = GetTOkenJWT();
                return Ok(new { token });
            }

            return BadRequest(new { mensagem = "Credenciais Inválidas" });
        }

        private string GetTOkenJWT()
        {
            string secretKey = "9d7a5159-d9fe-41df-bf99-9be6cd5d4129";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("login", "admin"),
                new Claim("name", "Administrador")
            };

            var token = new JwtSecurityToken(
                    issuer: "empresa",
                    audience: "Aplicacao",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credential
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
