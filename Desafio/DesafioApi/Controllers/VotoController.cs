using Desafio.Domain.Commands.Inputs.VotoInputs;
using Desafio.Domain.Handler;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Interfaces.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApi.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class VotoController : ControllerBase
    {
        private readonly IVotoRepository _repository;
        private readonly VotoHandler _handler;

        public VotoController(IVotoRepository repository, VotoHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/voto")]
        public ICommandResult Inserir([FromBody] AdicionarVotoCommand command)
        {
            return _handler.Handle(command);
        }
    }
}
