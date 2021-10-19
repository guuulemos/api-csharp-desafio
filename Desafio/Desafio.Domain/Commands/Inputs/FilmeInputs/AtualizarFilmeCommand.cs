using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Text.Json.Serialization;

namespace Desafio.Domain.Commands.Inputs.FilmeInputs
{
    public class AtualizarFilmeCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("Id", "Id deve ser maior que zero");

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
