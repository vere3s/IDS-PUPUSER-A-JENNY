using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PupuseriaJenny.Models;
using PupuseriaJenny.Services;
using RestauranteAPI.DTOs;
using System.Data;  // Asegúrate de incluir tu modelo de usuario

namespace RestauranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UsuarioService _usuarioService;

        // Inyección de dependencias para acceder al servicio UsuarioService
        public AuthController(IConfiguration configuration, UsuarioService usuarioService)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            // Validar las credenciales del usuario con el servicio
            DataTable dt = _usuarioService.AutenticarUsuario(loginModel.Username, loginModel.Password);

            if (dt == null || dt.Rows.Count == 0)
            {
                return Unauthorized(new { message = "Usuario o contraseña incorrectos" });
            }

            // Si el usuario es encontrado, generamos el token JWT
            string username = dt.Rows[0]["usuario"].ToString();  // Nombre de usuario
            string nombreEmpleado = dt.Rows[0]["nombreEmpleado"].ToString(); // Nombre del empleado
            string apellidoEmpleado = dt.Rows[0]["apellidoEmpleado"].ToString(); // Apellido del empleado
            int idEmpleado = Convert.ToInt32(dt.Rows[0]["IDEmpleado"]);  // ID del empleado
            string rol = dt.Rows[0]["rol"].ToString();
            var token = GenerateJwtToken(username, nombreEmpleado, apellidoEmpleado, idEmpleado,rol);

            return Ok(new { token });
        }

        private string GenerateJwtToken(string username, string nombreEmpleado, string apellidoEmpleado, int idEmpleado,string rol)
        {
            // Definir las claims (reclamaciones) para el token
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.NameIdentifier, username),
         new Claim(ClaimTypes.Role, rol),
        new Claim("nombreEmpleado", nombreEmpleado),
        new Claim("apellidoEmpleado", apellidoEmpleado),
        new Claim("idEmpleado", idEmpleado.ToString()),  // Convertir el ID a cadena
        // Puedes agregar más claims como roles o permisos si es necesario
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"])); // Se usa la clave secreta desde el archivo de configuración
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"], // El emisor desde la configuración
                audience: _configuration["Jwt:Audience"], // La audiencia desde la configuración
                claims: claims,
                expires: DateTime.Now.AddHours(1),  // El token expira en 1 hora
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);  // Retorna el token en formato string
        }

    }
}
