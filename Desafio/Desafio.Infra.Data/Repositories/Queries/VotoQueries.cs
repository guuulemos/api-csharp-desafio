namespace Desafio.Infra.Data.Repositories.Queries
{
    public class VotoQueries
    {
        public static string Inserir = @"Insert Into Voto(IdFilme, IdUsuario) Values (@IdFilme, @IdUsuario); Select SCOPE_IDENTITY();";
        public static string CheckId = @"Select Id From Voto Where Id=@Id";
    }
}
