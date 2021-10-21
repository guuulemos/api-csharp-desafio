using Desafio.Domain.Entidades;
using Desafio.Domain.Services;
using Desafio.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioApi.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioAuthController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserAuth model)
        {
            var user = UserAuthRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
