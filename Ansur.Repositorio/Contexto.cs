#region

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace Ansur.Repositorio
{
    public class Contexto : IDisposable
    {
        private readonly SqlConnection _myConn;

        public Contexto()
        {
            _myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["TiSelvagemConfig"].ConnectionString);
            _myConn.Open();
        }

        public void Dispose()
        {
            if (_myConn.State == ConnectionState.Open)
                _myConn.Close();
        }

        public void ExecutaComando(string strSql)
        {
            var cmd = new SqlCommand
            {
                CommandText = strSql,
                Connection = _myConn
            };
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoComRetorno(string strSql)
        {
            var cmd = new SqlCommand(strSql, _myConn);
            return cmd.ExecuteReader();
        }
    }
}