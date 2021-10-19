namespace Desafio.Domain.Entidades
{
    public class Filme
    {
        public long Id { get; private set; }
        public string Titulo { get; private set; }
        public string Diretor { get; private set; }

        public Filme(long id, string titulo, string diretor)
        {
            Id = id;
            Titulo = titulo;
            Diretor = diretor;
        }
    }
}
