using Microsoft.AspNetCore.Mvc;
using ApiLibros.Repositories;
using System.Security.Claims;
using ApiLibros.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Cors;

namespace MyApp.Namespace
{
    [EnableCors]
    [Route("/Api/Auth")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccesor;
        public UsuarioController(IHttpContextAccessor contextAccesor, UsuarioRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
            _contextAccesor = contextAccesor;
        }

        private IActionResult GenerateToken(Usuario request, int idUsuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, request.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, request.NombreUsuario),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return Ok(new Dictionary<string, object>
            {
                {"token" , jwt},
                {"id" , idUsuario}
            });
        }
        [HttpGet("/Api/Usuario")]
        public IActionResult GetUsuarioId([FromQuery] int id)
        {
            if (!_contextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                return Unauthorized("Requiere authenticacion");
            }
            return Ok(_repository.GetUsuarioById(id));
        }
        [HttpPost("/Api/Auth/register")]
        public IActionResult Register([FromBody] Usuario request)
        {
            if (_repository.ExistUsuarioByUserName(request.NombreUsuario))
            {
                return BadRequest("Usuario ya existente");
            }
            int idUsuario = _repository.InsertUsuario(request);
            return GenerateToken(request, idUsuario);
        }
        [HttpPost("/Api/Auth/login")]
        public IActionResult Login([FromBody] Usuario request)
        {
            if (!_repository.ExistUsuarioByUserName(request.NombreUsuario))
            {
                return BadRequest("Usuario no encontrado");
            }
            else if (!_repository.ExistUsuarioByUserNameAndPassword(request.NombreUsuario, request.Contrasena))
            {
                return BadRequest("Contraseña incorrecta");
            }
            Usuario user = _repository.GetUsuarioByUserNameAndPassword(request.NombreUsuario, request.Contrasena);
            return GenerateToken(user, user.IdUsuario);
        }
    }
}

