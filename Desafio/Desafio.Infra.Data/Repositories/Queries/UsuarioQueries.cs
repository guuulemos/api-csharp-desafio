namespace Desafio.Infra.Data.Repositories.Queries
{
    public class UsuarioQueries
    {
        public static string Inserir = @"Insert Into Usuario(Nome, Login, Senha) Values (@Nome, @Login, @Senha); Select SCOPE_IDENTITY();";
        public static string Atualizar = @"Update Usuario Set Nome=@Nome, Login=@Login, Senha=@Senha Where Id=@Id";
        public static string CheckId = @"Select Id From Usuario Where Id=@Id";
        public static string Listar = @"Select Id as Id, Nome as Nome, Login as Login, Senha as Senha From Usuario Order by Id";
        public static string Obter = @"Select Id as Id, Nome as Nome, Login as Login, Senha as Senha From Usuario Where Id=@Id";
        public static string Excluir = @"Delete From Usuario Where Id=@Id";
    }
}
