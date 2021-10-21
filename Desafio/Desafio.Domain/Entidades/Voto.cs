namespace Desafio.Domain.Entidades
{
    public class Voto
    {
        public long Id { get; set; }
        public long IdFilme { get; set; }
        public long IdUsuario { get; set; }

        public Voto(long id, long idFilme, long idUsuario)
        {
            Id = id;
            IdFilme = idFilme;
            IdUsuario = idUsuario;
        }
    }
}
