using Desafio.Infra.Interfaces.Commands;
using Flunt.Notifications;

namespace Desafio.Domain.Commands.Inputs.UsuarioInputs
{
    public class AdicionarUsuarioCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool ValidarCommand()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification("Nome", "Nome é um campo obrigatório");
            else if (Nome.Length > 50)
                AddNotification("Nome", "Nome maior que 50 caracteres");

            if (string.IsNullOrWhiteSpace(Login))
                AddNotification("Login", "Nome é um campo obrigatório");
            else if (Login.Length > 50)
                AddNotification("Login", "Nome maior que 50 caracteres");

            if (string.IsNullOrWhiteSpace(Senha))
                AddNotification("Senha", "Nome é um campo obrigatório");
            else if (Senha.Length > 50)
                AddNotification("Senha", "Nome maior que 50 caracteres");

            return Valid;
        }
    }
}
