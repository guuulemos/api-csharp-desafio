using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;

namespace Desafio.Domain.Commands.Inputs.VotoInputs
{
    public class AtualizarVotoCommand : Notifiable, ICommandPadrao
    {
        public long IdFilme { get; set; }
        public long IdUsuario { get; set; }
        public long Id { get; set; }

        public bool ValidarCommand()
        {
            if (IdFilme <= 0)
                AddNotification("IdFilme", "IdFilme deve ser maior que zero");

            if (IdUsuario <= 0)
                AddNotification("IdUsuario", "IdUsuario deve ser maior que zero");
            return Valid;
        }
    }
}
