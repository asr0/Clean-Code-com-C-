using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace UI.Console
{
    internal class Contexto : IDisposable
    {
        private readonly SqlConnection myConn;

        public Contexto()
        {
            myConn = new SqlConnection(ConfigurationManager.ConnectionStrings["TiSelvagemConfig"].ConnectionString);
            myConn.Open();
        }

        public void ExecutaComando(string strSQL)
        {
            var cmd = new SqlCommand
            {
                CommandText = strSQL,
                Connection = myConn
            };
            cmd.ExecuteNonQuery();
        }
        


        public SqlDataReader ExecutaComandoComRetorno(string strSQL)
        {
            SqlCommand cmd = new SqlCommand(strSQL, myConn);
            return cmd.ExecuteReader();
        }

        public void Dispose()
        {
            if (myConn.State == ConnectionState.Open)
                myConn.Close();
        }

       
    }
}