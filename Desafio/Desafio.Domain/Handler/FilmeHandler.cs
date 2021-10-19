using Desafio.Domain.Commands.Inputs.FilmeInputs;
using Desafio.Domain.Commands.Outputs;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;

namespace Desafio.Domain.Handler
{
    public class FilmeHandler : ICommandHandler<AdicionarFilmeCommand>, ICommandHandler<AtualizarFilmeCommand>, ICommandHandler<ExcluirFilmeCommand>
    {
        private readonly IFilmeRepository _repository;

        public FilmeHandler(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new FilmeCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                long id = 0;
                string titulo = command.Titulo;
                string diretor = command.Diretor;

                Filme filme = new Filme(id, titulo, diretor);

                id = _repository.Inserir(filme);

                return new FilmeCommandResult(true, "Filme adicionado com sucesso!", new
                {
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor,
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ICommandResult Handle(AtualizarFilmeCommand command)
        {
            if (!_repository.CheckId(command.Id))
                return new FilmeCommandResult(false, "Id", new Notification("Id", "Id inválido. Este id não está cadastrado!"));

            if (!command.ValidarCommand())
                return new FilmeCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

            long id = command.Id;
            string titulo = command.Titulo;
            string diretor = command.Diretor;

            Filme filme = new Filme(id, titulo, diretor);

            _repository.Atualizar(filme);

            return new FilmeCommandResult(true, "Filme adicionado com sucesso!", new
            {
                Id = filme.Titulo,
                Titulo = filme.Titulo,
                Diretor = filme.Diretor,
            });
        }

        public ICommandResult Handle(ExcluirFilmeCommand command)
        {
            if (!_repository.CheckId(command.Id))
                return new FilmeCommandResult(false, "Id", new Notification("Id", "Id inválido. Este id não está cadastrado!"));

            if (!command.ValidarCommand())
                return new FilmeCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

            _repository.Excluir(command.Id);

            return new FilmeCommandResult(true, "Filme excluído com sucesso!", new { Id = command.Id });
        }
    }
}
