using Desafio.Domain.Commands.Inputs.UsuarioInputs;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly UsuarioHandler _handler;

        public UsuarioController(IUsuarioRepository repository, UsuarioHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/usuario/{id}")]
        public UsuarioQueryResult Obter(long id)
        {
            return _repository.Obter(id);
        }

        [HttpGet]
        [Route("v1/usuario")]
        public List<UsuarioQueryResult> Listar()
        {
            return _repository.Listar();
        }

        [HttpPost]
        [Route("v1/usuario")]
        public ICommandResult Inserir([FromBody] AdicionarUsuarioCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/usuario/{id}")]
        public ICommandResult Atualizar(long id, [FromBody] AtualizarUsuarioCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("v1/usuario/{id}")]
        public ICommandResult Excluir(long id)
        {
            var command = new ExcluirUsuarioCommand() { Id = id };
            return _handler.Handle(command);
        }
    }
}
