using Desafio.Domain.Commands.Inputs.FilmeInputs;
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
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _repository;
        private readonly FilmeHandler _handler;

        public FilmeController(IFilmeRepository repository, FilmeHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/filme/{id}")]
        public FilmeQueryResult Obter(long id)
        {
            return _repository.Obter(id);
        }

        [HttpGet]
        [Route("v1/filme")]
        public List<FilmeQueryResult> listarFilmes()
        {
            return _repository.Listar();
        }

        [HttpPost]
        [Route("v1/filme")]
        public ICommandResult Inserir([FromBody] AdicionarFilmeCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("v1/filme/{id}")]
        public ICommandResult Atualizar(long id, [FromBody] AtualizarFilmeCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("V1/filme/{id}")]
        public ICommandResult Excluir(long id)
        {
            var command = new ExcluirFilmeCommand() { Id = id };
            return _handler.Handle(command);
        }
    }
}
