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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public VotoQueryResult Obter(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
