using Dapper;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Query;
using Desafio.Infra.Data.DataContexts;
using Desafio.Infra.Data.Repositories.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Desafio.Infra.Data.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContexto _dataContexto;

        public VotoRepository(DataContexto dataContexto)
        {
            _dataContexto = dataContexto;
        }
        public void Atualizar(Voto voto)
        {
            try
            {
                _parameters.Add("IdFilme", voto.IdFilme, DbType.String);
                _parameters.Add("IdUsuario", voto.IdUsuario, DbType.String);

                _dataContexto.sqlConnection.Execute(VotoQueries.Atualizar, _parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckId(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                return _dataContexto.sqlConnection.Query<bool>(VotoQueries.CheckId, _parameters).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Excluir(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.String);

                _dataContexto.sqlConnection.Query<VotoQueryResult>(VotoQueries.Excluir, _parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long Inserir(Voto voto)
        {
            try
            {
                _parameters.Add("IdFilme", voto.IdFilme, DbType.String);
                _parameters.Add("IdUsuario", voto.IdUsuario, DbType.String);

                return _dataContexto.sqlConnection.Execute(VotoQueries.Inserir, _parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<VotoQueryResult> Listar()
        {
            try
            {
                return _dataContexto.sqlConnection.Query<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult, VotoQueryResult>(
                    VotoQueries.Listar,
                    map: ((voto, usuario, filme) =>
                    {
                        voto.Filme = filme;
                        voto.Usuario = usuario;

                        return voto;
                    }),
                    splitOn: "IdUsuario, IdFilme"
                    ).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public VotoQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.String);

                return _dataContexto.sqlConnection.Query<VotoQueryResult, UsuarioQueryResult, FilmeQueryResult, VotoQueryResult>(
                    VotoQueries.Obter,
                    map: ((voto, usuario, filme) =>
                    {
                        voto.Filme = filme;
                        voto.Usuario = usuario;

                        return voto;
                    }),
                    splitOn: "IdUsuario, IdFilme",
                    param: _parameters
                    ).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
