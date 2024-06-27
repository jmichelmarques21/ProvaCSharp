using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ProvaCSharp.models;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticadorController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly string _secretKey;

        public AutenticadorController(AppDbContext context)
        {
            _context = context;
            _secretKey = "abcabcabcabcabcabcabcabcabcabcabc"; // Use uma chave secreta segura
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            var user = await _context.Usuarios.SingleOrDefaultAsync(u => u.Email == userLogin.Email && u.Senha == userLogin.Senha);

            if (user != null)
            {
                var token = GenerateToken(user.Email);
                return Ok(new { token });
            }

            return Unauthorized("Credenciais inválidas");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegister userRegister)
        {
            var user = new Usuario
            {
                User = userRegister.User,
                Email = userRegister.Email,
                Senha = userRegister.Senha
            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Usuário registrado com sucesso");
        }

        private string GenerateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}