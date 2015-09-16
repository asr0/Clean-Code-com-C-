#region

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Ansur.Dominio;
using Ansur.Repositorio;

#endregion

namespace Ansur.Aplicacao
{
    public class AlunoApp
    {
        private Contexto _contexto;
        private string _sql = "";

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
            _sql = string.Format(@"INSERT INTO ALUNOS (NOME, CARGO, DATANASCIMENTO) VALUES ('{0}','{1}','{2}')",
                aluno.Nome, aluno.Cargo, aluno.DataNasc);

            using (_contexto = new Contexto())
            {
                _contexto.ExecutaComando(_sql);
            }
        }

        public void Alterar(Aluno aluno)
        {
            var sql = new StringBuilder();

            sql.Append("UPDATE ALUNOS SET ");
            sql.Append(String.Format(" NOME = '{0}', ", aluno.Nome));
            sql.Append(String.Format(" CARGO = '{0}', ", aluno.Cargo));
            sql.Append(String.Format(" DATANASCIMENTO = '{0}' ", aluno.DataNasc));
            sql.Append(String.Format(" WHERE ALUNOID  = {0}", aluno.Id));

            using (_contexto = new Contexto())
            {
                _contexto.ExecutaComando(sql.ToString());
            }
        }

        public void Excluir(int id)
        {
            using (_contexto = new Contexto())
            {
                _sql = String.Format(" DELETE FROM ALUNOS WHERE ALUNOID = {0}", id);
                _contexto.ExecutaComando(_sql);
            }
        }

        public List<Aluno> ListarTodos()
        {
            _sql = "SELECT * FROM ALUNOS";
            var alunos = new Contexto().ExecutaComandoComRetorno(_sql);
            return TranformaReaderEmLista(alunos);
        }

        private List<Aluno> TranformaReaderEmLista(SqlDataReader reader)
        {
            var lista = new List<Aluno>();
            while (reader.Read())
            {
                var aluno = new Aluno
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