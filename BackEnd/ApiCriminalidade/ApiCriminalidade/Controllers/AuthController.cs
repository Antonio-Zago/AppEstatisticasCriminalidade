using ApiCriminalidade.Application.Dtos;
using ApiCriminalidade.Application.Interfaces;
using ApiCriminalidade.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
        private readonly IPermissaoService _permissaoService;

        public AuthController(ITokenService tokenService, IConfiguration config, IUsuarioService usuarioService, IPermissaoService permissaoService)
        {
            _tokenService = tokenService;
            _config = config;
            _usuarioService = usuarioService;
            _permissaoService = permissaoService;
        }

        [HttpPost]
        [Route("AddUserToRole/{email}/{rolename}")]
        //[Authorize(Policy = "ADMINEXCLUSIVO")]
        public IActionResult AddUserToRole(string email, string roleName)
        {

            var permissao = _permissaoService.FindPermissaoByName(roleName);

            
            if (permissao != null)
            {
                var result = _usuarioService.AddToRole(email, permissao.Id);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                           new ResponseDto
                           {
                               Status = "Success",
                               Message =
                           $"User {result.Email} added to the {roleName} role"
                           });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                    {
                        Status = "Error",
                        Message = $"Error: Unable to add user {email} to the {roleName} role"
                    });
                }


            }
            return BadRequest(new { error = "Unable to find permission" });
        }

        [HttpPost]
        [Route("CreateRole/{roleName}")]
        [Authorize(Policy = "ADMINEXCLUSIVO")]
        public IActionResult CreateRole(string roleName)
        {
            var role = _permissaoService.FindPermissaoByName(roleName);

            if (role == null)
            {
                var roleResult = _permissaoService.Post(new PermissaoForm { Nome = roleName});

                if (roleResult != null)
                {
                    return StatusCode(StatusCodes.Status200OK,
                            new ResponseDto
                            {
                                Status = "Success",
                                Message =
                            $"Role {roleName} added successfully"
                            });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                       new ResponseDto
                       {
                           Status = "Error",
                           Message =
                           $"Issue adding the new {roleName} role"
                       });
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest,
              new ResponseDto { Status = "Error", Message = "Role already exist." });
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
                    Expiration = token.ValidTo,
                    Usuario = user.Nome,
                    Email = user.Email,
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<ResponseDto> Register([FromBody] RegisterForm model)
        {
            var userExists = _usuarioService.ValidarUsuarioJaExistente(model);

            if (userExists.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var user in userExists)
                {
                    sb.AppendLine(user);
                }

               
                return StatusCode(StatusCodes.Status500InternalServerError,
                       new ResponseDto { Status = "Error", Message = sb.ToString() });
            }


            var result = _usuarioService.Post(model);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       new ResponseDto { Status = "Error", Message = "User creation failed." });
            }

            return Ok(new ResponseDto { Status = "Success", Message = "User created successfully!" });

        }

        [HttpPost]
        [Route("refresh-token")]
        [Authorize(Policy = "USUARIOGERAL")]
        public IActionResult RefreshToken(TokenForm tokenForm)
        {

            if (tokenForm is null)
            {
                return BadRequest("Invalid client request");
            }

            string? accessToken = tokenForm.AccessToken
                                  ?? throw new ArgumentNullException(nameof(tokenForm));

            string? refreshToken = tokenForm.RefreshToken
                                   ?? throw new ArgumentException(nameof(tokenForm));

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken!, _config);

            if (principal == null)
            {
                return BadRequest("Invalid access token/refresh token");
            }
            string username = principal.Identity.Name;

            var user = _usuarioService.FindByNome(username!);

            if (user == null || user.RefreshToken != refreshToken
                             || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid access token/refresh token");
            }

            var newAccessToken = _tokenService.GenerateAccessToken(
                                               principal.Claims.ToList(), _config);

            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;

            _usuarioService.UpdateRefreshToken(user.Id, user);

            return new ObjectResult(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                refreshToken = newRefreshToken
            });
        }

        [Authorize]
        [HttpPost]
        [Route("revoke/{username}")]
        [Authorize(Policy = "ADMINEXCLUSIVO")]
        public IActionResult Revoke(string username)
        {
            var user = _usuarioService.FindByNome(username);

            if (user == null) return BadRequest("Invalid user name");

            user.RefreshToken = null;

            _usuarioService.UpdateRefreshToken(user.Id,user);

            return NoContent();
        }
    }
}
