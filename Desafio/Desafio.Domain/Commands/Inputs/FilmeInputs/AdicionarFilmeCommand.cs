using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;

namespace Desafio.Domain.Commands.Inputs.FilmeInputs
{
    public class AdicionarFilmeCommand : Notifiable, ICommandPadrao
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }

        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Titulo))
                    AddNotification("Titulo", "Titulo é um campo obrigatório");
                else if (Titulo.Length > 50)
                    AddNotification("Titulo", "Titulo maior que 50 caracteres");

                if (string.IsNullOrWhiteSpace(Diretor))
                    AddNotification("Diretor", "Titulo é um campo obrigatório");
                else if (Diretor.Length > 50)
                    AddNotification("Diretor", "Titulo maior que 50 caracteres");

                return Valid;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
