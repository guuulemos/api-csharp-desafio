using Dapper;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Query;
using Desafio.Infra.Data.DataContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Desafio.Infra.Data.Repositories.Queries
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DynamicParameters _parameters = new DynamicParameters();
        private readonly DataContexto _dataContexto;

        public UsuarioRepository(DataContexto dataContexto)
        {
            _dataContexto = dataContexto;
        }

        public long Inserir(Usuario usuario)
        {
            try
            {
                _parameters.Add("Nome", usuario.Nome, DbType.String);
                _parameters.Add("Login", usuario.Login, DbType.String);
                _parameters.Add("Senha", usuario.Senha, DbType.String);

                return _dataContexto.sqlConnection.Execute(UsuarioQueries.Inserir, _parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Atualizar(Usuario usuario)
        {
            try
            {
                _parameters.Add("Id", usuario.Id, DbType.Int64);
                _parameters.Add("Nome", usuario.Nome, DbType.String);
                _parameters.Add("Login", usuario.Login, DbType.String);
                _parameters.Add("Senha", usuario.Senha, DbType.String);

                _dataContexto.sqlConnection.Execute(UsuarioQueries.Atualizar, _parameters);
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

                return _dataContexto.sqlConnection.Query<bool>(UsuarioQueries.CheckId, _parameters).FirstOrDefault();
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

                _dataContexto.sqlConnection.Query<UsuarioQueryResult>(UsuarioQueries.Excluir, _parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UsuarioQueryResult> Listar()
        {
            try
            {
                return _dataContexto.sqlConnection.Query<UsuarioQueryResult>(UsuarioQueries.Listar).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UsuarioQueryResult Obter(long id)
        {
            try
            {
                _parameters.Add("Id", id, DbType.Int64);

                return _dataContexto.sqlConnection.Query<UsuarioQueryResult>(UsuarioQueries.Obter, _parameters).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
