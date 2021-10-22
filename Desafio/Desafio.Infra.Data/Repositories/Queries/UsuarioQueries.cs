namespace Desafio.Infra.Data.Repositories.Queries
{
    public class UsuarioQueries
    {
        public static string Inserir = @"Insert Into Usuario(Nome, Login, Senha) Values (@Nome, @Login, @Senha); Select SCOPE_IDENTITY();";
        public static string Atualizar = @"Update Usuario Set Nome=@Nome, Login=@Login, Senha=@Senha Where IdUsuario=@Id";
        public static string CheckId = @"Select IdUsuario From Usuario Where IdUsuario=@Id";
        public static string Listar = @"Select IdUsuario as IdUsuario, Nome as Nome, Login as Login, Senha as Senha From Usuario Order by IdUsuario";
        public static string Obter = @"Select IdUsuario as IdUsuario, Nome as Nome, Login as Login, Senha as Senha From Usuario Where IdUsuario=@Id";
        public static string Excluir = @"Delete From Usuario Where IdUsuario=@Id";
    }
}
