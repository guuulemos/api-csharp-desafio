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
    public class FilmeRepository : IFilmeRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContexto _dataContexto;

        public FilmeRepository(DataContexto dataContexto)
        {
            _dataContexto = dataContexto;
        }

        public long Inserir(Filme filme)
        {
            try
            {
                _parameters.Add("Titulo", filme.Titulo, DbType.String);
                _parameters.Add("Diretor", filme.Diretor, DbType.String);

                return _dataContexto.sqlConnection.Execute(FilmeQueries.Inserir, _parameters);
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

                return _dataContexto.sqlConnection.Query<bool>(FilmeQueries.CheckId, _parameters).FirstOrDefault();
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
                _parameters.Add("Id", id, DbType.Int64);

                _dataContexto.sqlConnection.Query<FilmeQueryResult>(FilmeQueries.Excluir, _parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Atualizar(Filme filme)
        {
            try
            {
                _parameters.Add("Id", filme.Id, DbType.Int64);
                _parameters.Add("Titulo", filme.Titulo, DbType.String);
                _parameters.Add("Diretor", filme.Diretor, DbType.String);

                _dataContexto.sqlConnection.Execute(FilmeQueries.Atualizar, _parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FilmeQueryResult> Listar()
        {
            try
            {
                return _dataContexto.sqlConnection.Query <FilmeQueryResult>(FilmeQueries.Listar).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FilmeQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                return _dataContexto.sqlConnection.Query<FilmeQueryResult>(FilmeQueries.Obter, _parameters).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            } 
        }
    }
}
