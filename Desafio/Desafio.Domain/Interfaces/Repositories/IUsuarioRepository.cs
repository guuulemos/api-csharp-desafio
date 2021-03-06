using Desafio.Domain.Entidades;
using Desafio.Domain.Query;
using System.Collections.Generic;

namespace Desafio.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        long Inserir(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Excluir(long id);
        List<UsuarioQueryResult> Listar();
        UsuarioQueryResult Obter(long id);
        bool CheckId(long id);
    }
}
