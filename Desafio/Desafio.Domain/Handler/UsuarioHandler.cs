using Desafio.Domain.Commands.Inputs.UsuarioInputs;
using Desafio.Domain.Commands.Outputs.FilmeOutputs;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;

namespace Desafio.Domain.Handler
{
    public class UsuarioHandler : ICommandHandler<AdicionarUsuarioCommand>, ICommandHandler<AtualizarUsuarioCommand>, ICommandHandler<ExcluirUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                long id = 0;
                string nome = command.Nome;
                string login = command.Login;
                string senha = command.Senha;

                Usuario usuario = new Usuario(id, nome, login, senha);

                _repository.Inserir(usuario);

                return new UsuarioCommandResult(true, "Usuario adicionado com sucesso!", new
                {
                    Nome = usuario.Nome,
                    Login = usuario.Login,
                    Senha = usuario.Senha,
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICommandResult Handle(AtualizarUsuarioCommand command)
        {
            try
            {
                if (!_repository.CheckId(command.Id))
                    return new UsuarioCommandResult(false, "Id", new Notification("Id", "Id inválido. Este id não está cadastrado!"));

                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                long id = command.Id;
                string nome = command.Nome;
                string login = command.Login;
                string senha = command.Senha;

                Usuario usuario = new Usuario(id, nome, login, senha);

                _repository.Atualizar(usuario);

                return new UsuarioCommandResult(true, "Usuario alterado com sucesso!", new
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Login = usuario.Login,
                    Senha = usuario.Senha,
                });
            }
            catch (Exception)
            {

                throw;
            } 

        }

        public ICommandResult Handle(ExcluirUsuarioCommand command)
        {
            if (!_repository.CheckId(command.Id))
                return new UsuarioCommandResult(false, "Id", new Notification("Id", "Id inválido. Este id não está cadastrado!"));

            if (!command.ValidarCommand())
                return new UsuarioCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

            _repository.Excluir(command.Id);

            return new UsuarioCommandResult(true, "Usuário excluído com sucesso!", new { Id = command.Id });
        }
    }
}
