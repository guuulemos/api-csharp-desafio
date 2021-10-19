namespace Desafio.Infra.Data.Repositories.Queries
{
    public class FilmeQueries
    {
        public static string Inserir = @"Insert Into Filme(Titulo, Diretor) Values (@Titulo, @Diretor); Select SCOPE_IDENTITY();";
        public static string Atualizar = @"Update Filme Set Titulo=@Titulo, Diretor=@Diretor Where Id=@Id";
        public static string CheckId = @"Select Id From Filme Where Id=@Id";
        public static string Listar = @"Select Id as Id, Titulo as Titulo, Diretor as Diretor From Filme Order by Id";
        public static string Obter = @"Select Id as Id, Titulo as Titulo, Diretor as Diretor From Filme Where Id=@Id";
        public static string Excluir = @"Delete From Filme Where Id=@Id";
    }
}
