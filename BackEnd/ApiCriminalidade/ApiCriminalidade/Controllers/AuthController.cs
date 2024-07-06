using ApiCriminalidade.Dtos;
using ApiCriminalidade.Models;
using ApiCriminalidade.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiCriminalidade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;
        private readonly IUsuarioService _usuarioService;

        public AuthController(ITokenService tokenService, IConfiguration config, IUsuarioService usuarioService)
        {
            _tokenService = tokenService;
            _config = config;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UsuarioForm model)
        {
            var user = _usuarioService.FindByEmail(model.Email);

            if (user is not null && _usuarioService.CheckPassword(model.Senha, user.Senha))
            {

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in user.UsuarioPermissoes)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole.Permissao.Nome));
                }

                var token = _tokenService.GenerateAccessToken(authClaims,
                                                             _config);

                var refreshToken = _tokenService.GenerateRefreshToken();

                _ = int.TryParse(_config["JWT:RefreshTokenValidityInMinutes"],
                                   out int refreshTokenValidityInMinutes);

                user.RefreshTokenExpiryTime =
                                DateTime.Now.AddMinutes(refreshTokenValidityInMinutes);

                user.RefreshToken = refreshToken;

                _usuarioService.UpdateRefreshToken(user.Id,user );

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<Response> Register([FromBody] RegisterForm model)
        {
            var userExists = _usuarioService.ValidarUsuarioJaExistente(model.Email, model.Cpf);

            if (userExists.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var user in userExists)
                {
                    sb.AppendLine(user);
                }

               
                return StatusCode(StatusCodes.Status500InternalServerError,
                       new Response { Status = "Error", Message = sb.ToString() });
            }


            var result = _usuarioService.Post(model);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       new Response { Status = "Error", Message = "User creation failed." });
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });

        }
    }
}
