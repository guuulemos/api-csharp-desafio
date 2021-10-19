using Desafio.Infra.Settings;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Desafio.Infra.Data.DataContexts
{
    public class DataContexto : IDisposable
    {
        public SqlConnection sqlConnection { get; set; }

        public DataContexto (AppSettings appSettings)
        {
            sqlConnection = new SqlConnection(appSettings.ConnectionString);
            sqlConnection.Open();
        }
        public void Dispose()
        {
            try
            {
                if (sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
