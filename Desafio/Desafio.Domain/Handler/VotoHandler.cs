using Desafio.Domain.Commands.Inputs.VotoInputs;
using Desafio.Domain.Commands.Outputs;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Infra.Interfaces.Commands;
using System;

namespace Desafio.Domain.Handler
{
    public class VotoHandler : ICommandHandler<AdicionarVotoCommand>
    {
        private readonly IVotoRepository _repository;
        public VotoHandler(IVotoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(AdicionarVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new VotoCommandResult(false, "Por favor, corrija as inconsistências abaixo", command.Notifications);

                long id = 0;
                long idFilme = command.IdFilme;
                long idUsuario = command.IdUsuario;

                Voto voto = new Voto(id, idFilme, idUsuario);

                id = _repository.Inserir(voto);

                return new VotoCommandResult(true, "Voto adicionado com sucesso!", new
                {
                    IdFilme = voto.IdFilme,
                    IdUsuario = voto.IdUsuario,
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
