using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;

namespace Desafio.Domain.Handler
{
    public class ExcluirVotoCommand : Notifiable, ICommandPadrao
    {
        public long Id { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (Id <= 0)
                    AddNotification("IdFilme", "IdFilme deve ser maior que zero");

                return Valid;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}