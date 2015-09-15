using System;
using System.ComponentModel.Design;
using System.Text;

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
            int opcao = int.Parse(Prompt(menu.ToString()));

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
                System.Console.WriteLine("ID: {0}, NOME: {1}, CARGO: {2}, NASCIMENTO: {3}", aluno.Id, aluno.Nome, aluno.Cargo, aluno.DataNasc);
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
            Aluno aluno = new Aluno();
            aluno.Id = int.Parse(Prompt("Digite o id do aluno que deseja excluir: "));
            new AlunoApp().Excluir(aluno.Id);
            Menu();
        }

        public static void CadastrarAluno()
        {
            String nome = Prompt("Digite o nome do aluno");
            String cargo = Prompt("Digite o cargo do aluno");
            DateTime data = DateTime.Parse(Prompt("Digite o Data de Nascimento do aluno"));
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
            Aluno aluno = new Aluno();
            aluno.Id = int.Parse(Prompt("Digite o id do aluno que deseja alterar: "));
            aluno.Nome = Prompt("Digite o nome do aluno");
            aluno.Cargo = Prompt("Digite o cargo do aluno");
            aluno.DataNasc = DateTime.Parse(Prompt("Digite o Data de Nascimento do aluno"));
            new AlunoApp().Salvar(aluno);
            Menu();

        }



    }
}

