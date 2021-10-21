using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Commands.Inputs.VotoInputs
{
    public class AdicionarVotoCommand : Notifiable ,ICommandPadrao
    {
        public long IdFilme { get; set; }
        public long IdUsuario { get; set; }

        public bool ValidarCommand()
        {
            return Valid;
        }
    }
}
