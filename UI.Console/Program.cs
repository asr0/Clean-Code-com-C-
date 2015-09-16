#region

using System;
using System.Text;
using Ansur.Aplicacao;
using Ansur.Dominio;

#endregion

namespace UI.Console
{
    internal class Program
    {
        public static void Menu()
        {
            System.Console.ReadKey();
            System.Console.Clear();
            System.Console.WriteLine("      ******************** Sistema Gerenciador de Alunos ****************");
            var menu = new StringBuilder("_______Selecione uma das opcoes abaixo: \n\n");
            menu.AppendLine("   1. Listar Alunos.");
            menu.AppendLine("   2. Cadastrar Aluno");
            menu.AppendLine("   3. Alterar Aluno");
            menu.AppendLine("   4. Excluir um aluno");
            var opcao = 0;
            try
            {
                opcao = int.Parse(Prompt(menu.ToString()));
            }
            catch (Exception)
            {
                System.Console.WriteLine("Digite apenas numeros!");
                Menu();
            }


            switch (opcao)
            {
                case 1:
                    ListarAlunos();
                    break;

                case 2:
                    CadastrarAluno();
                    break;

                case 3:
                    AlterarAluno();
                    break;
                case 4:
                    ExcluirAluno();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        public static void Main(string[] args)
        {
            Menu();
        }

        public static void ListarAlunos()
        {
            var dados = new AlunoApp().ListarTodos();

            foreach (var aluno in dados)
            {
                System.Console.WriteLine("ID: {0}, NOME: {1}, CARGO: {2}, NASCIMENTO: {3}", aluno.Id, aluno.Nome,
                    aluno.Cargo, aluno.DataNasc);
            }
            Menu();
        }

        public static string Prompt(string text)
        {
            System.Console.WriteLine(text);
            return System.Console.ReadLine();
        }

        public static void ExcluirAluno()
        {
            var aluno = new Aluno
            {
                Id = int.Parse(Prompt("Digite o id do aluno que deseja excluir: "))
            };

            new AlunoApp().Excluir(aluno.Id);
            Menu();
        }

        public static void CadastrarAluno()
        {
            var nome = Prompt("Digite o nome do aluno");
            var cargo = Prompt("Digite o cargo do aluno");
            var data = DateTime.Parse(Prompt("Digite o Data de Nascimento do aluno"));
            var aluno = new Aluno
            {
                Nome = nome,
                Cargo = cargo,
                DataNasc = data
            };

            new AlunoApp().Salvar(aluno);
            Menu();
        }

        public static void AlterarAluno()
        {
            var aluno = new Aluno
            {
                Id = int.Parse(Prompt("Digite o id do aluno que deseja alterar: ")),
                Nome = Prompt("Digite o nome do aluno"),
                Cargo = Prompt("Digite o cargo do aluno"),
                DataNasc = DateTime.Parse(Prompt("Digite o Data de Nascimento do aluno"))
            };

            new AlunoApp().Salvar(aluno);
            Menu();
        }
    }
}