using Desafio.Domain.Commands.Inputs.VotoInputs;
using Desafio.Domain.Handler;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Query;
using Desafio.Infra.Interfaces.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet]
        [Route("v1/voto/{id}")]
        public VotoQueryResult Obter(long id)
        {
            return _repository.Obter(id);
        }

        [HttpGet]
        [Route("v1/voto")]
        public List<VotoQueryResult> Listar()
        {
            return _repository.Listar();
        }

        [HttpPost]
        [Route("v1/voto")]
        public ICommandResult Inserir([FromBody] AdicionarVotoCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/voto/{id}")]
        public ICommandResult Atualizar(long id, [FromBody] AtualizarVotoCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/voto/{id}")]
        public ICommandResult Excluir(long id)
        {
            var command = new ExcluirVotoCommand() { Id = id };
            return _handler.Handle(command);
        }
    }
}
