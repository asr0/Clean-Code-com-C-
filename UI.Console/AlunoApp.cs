using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.SqlServer.Server;

namespace UI.Console
{
    internal class AlunoApp
    {
        string sql = "";
        Contexto contexto;
        public void Salvar(Aluno aluno)
        {
            if (aluno.Id > 0)
            {
                Alterar(aluno);
            }
            else
            {
                Inserir(aluno);
            }
        }

        public void Inserir(Aluno aluno)
        {
            
            sql = string.Format(@"INSERT INTO ALUNOS (NOME, CARGO, DATANASCIMENTO) VALUES ('{0}','{1}','{2}')",
                aluno.Nome, aluno.Cargo, aluno.DataNasc);

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(sql);
            }
        }

        public void Alterar(Aluno aluno)
        {
            StringBuilder _sql = new StringBuilder();

            _sql.Append("UPDATE ALUNOS SET ");
            _sql.Append(String.Format(" NOME = '{0}', ", aluno.Nome));
            _sql.Append(String.Format(" CARGO = '{0}', ", aluno.Cargo));
            _sql.Append(String.Format(" DATANASCIMENTO = '{0}' ", aluno.DataNasc));
            _sql.Append(String.Format(" WHERE ALUNOID  = {0}", aluno.Id));

            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(_sql.ToString());
            }
        }

        public void Excluir(int id)
        {
            using ( contexto = new Contexto())
            {
                sql = String.Format(" DELETE FROM ALUNOS WHERE ALUNOID = {0}", id);
                contexto.ExecutaComando(sql);
            }
        }

        public List<Aluno> ListarTodos()
        {
            var lista = new List<Aluno>();
            sql = "SELECT * FROM ALUNOS";
            SqlDataReader alunos = new Contexto().ExecutaComandoComRetorno(sql);
            return TranformaReaderEmLista(alunos);

        }

        private List<Aluno> TranformaReaderEmLista(SqlDataReader reader)
        {
            var lista = new List<Aluno>();
            while (reader.Read())
            {
                Aluno aluno = new Aluno()
                {
                    Id = Convert.ToInt32(reader["AlunoId"]),
                    Nome = reader["nome"].ToString(),
                    Cargo = reader["cargo"].ToString(),
                    DataNasc = Convert.ToDateTime(reader["DataNascimento"])
                };
                lista.Add(aluno);
            }
            reader.Close();
            return lista;
        }
    }
}