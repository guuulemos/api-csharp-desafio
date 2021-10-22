namespace Desafio.Infra.Data.Repositories.Queries
{
    public class VotoQueries
    {
        public static string Inserir = @"Insert Into Voto(IdFilme, IdUsuario) Values (@IdFilme, @IdUsuario); Select SCOPE_IDENTITY();";
        public static string Atualizar = @"Update Voto Set IdFilme=@IdFilme, IdUsuario=@IdUsuario Where Id=@Id";
        public static string CheckId = @"Select Id From Voto Where Id=@Id";
        public static string Listar = @"Select v.Id, u.IdUsuario, u.Nome, u.Login, u.Senha, f.IdFilme, f.Titulo, f.Diretor FROM Voto v INNER JOIN Filme f ON v.IdFilme = f.IdFilme INNER JOIN Usuario u ON v.IdUsuario = u.IdUsuario;";
        public static string Obter = @"Select v.Id, u.IdUsuario, u.Nome, u.Login, u.Senha, f.IdFilme, f.Titulo, f.Diretor FROM Voto v INNER JOIN Filme f ON v.IdFilme = f.IdFilme INNER JOIN Usuario u ON v.IdUsuario = u.IdUsuario Where Id=@Id;";
        public static string Excluir = @"Delete From Voto Where Id=@Id";
    }
}
