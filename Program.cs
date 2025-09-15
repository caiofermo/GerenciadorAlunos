using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeAlunos
{
    // Classe do objeto aluno
    public class Aluno
    {
        public string Nome { get; set; }
        public List<double> Notas { get; private set; }

        // Construtor aluno
        public Aluno(string nome)
        {
            Nome = nome;
            Notas = new List<double>();
        }

        // Método para adicionar nota do aluno
        public void AdicionarNota(double nota)
        {
            if (nota >= 0 && nota <= 10)
                Notas.Add(nota);
            else
                Console.WriteLine("Nota inválida. Deve estar entre 0 e 10.");
        }

        // Calcula a média (if ternário)
        public double CalcularMedia()
        {
            return Notas.Count > 0 ? Notas.Average() : 0;
        }

        // Verifica se o aluno está aprovado ou reprovado
        public string ObterSituacao()
        {
            return CalcularMedia() >= 6 ? "Aluno aprovado" : "Aluno reprovado";
        }
    }

    // Classe que gerencia os alunos
    public class GerenciadorDeAlunos
    {
        private List<Aluno> Alunos = new List<Aluno>();

        // Método para adicionar aluno
        public void AdicionarAluno(string nome)
        {
            Alunos.Add(new Aluno(nome));
            Console.WriteLine($"Aluno {nome} adicionado com sucesso.");
        }

        // Método para buscar aluno
        public Aluno BuscarAluno(string nome)
        {
            return Alunos.FirstOrDefault(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }

        // Método para listar alunos
        public void ListarAlunos()
        {
            if (Alunos.Count == 0)
            {
                Console.WriteLine("Nenhum aluno cadastrado.");
                return;
            }

            Console.WriteLine("Lista de alunos:");
            foreach (var aluno in Alunos)
            {
                Console.WriteLine($"Nome: {aluno.Nome}, Média: {aluno.CalcularMedia():F2}, Situação: {aluno.ObterSituacao()}");
            }
        }
    }

    // Classe principal do programa
    class Program
    {
        static void Main(string[] args)
        {
            GerenciadorDeAlunos gerenciador = new GerenciadorDeAlunos();
            int opcao;

            // Laço de repetição, mantém o menu rodando até o usuário digitar 0.
            do
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Adicionar aluno");
                Console.WriteLine("2. Adicionar nota");
                Console.WriteLine("3. Listar alunos");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma das opções: ");

                // Converte a entrada em número, evitando erro caso o usuário digite letras.
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o nome do aluno: ");
                        string nome = Console.ReadLine();
                        gerenciador.AdicionarAluno(nome);
                        break;

                    case 2:
                        Console.Write("Digite o nome do aluno: ");
                        string nomeAluno = Console.ReadLine();
                        var aluno = gerenciador.BuscarAluno(nomeAluno);
                        if (aluno != null)
                        {
                            Console.Write("Digite a nota (0 a 10): ");
                            if (double.TryParse(Console.ReadLine(), out double nota))
                            {
                                aluno.AdicionarNota(nota);
                                Console.WriteLine("Nota adicionada com sucesso.");
                            }
                            else
                            {
                                Console.WriteLine("Nota inválida. Deve ser um número entre 0 e 10.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aluno não encontrado.");
                        }
                        break;

                    case 3:
                        gerenciador.ListarAlunos();
                        break;

                    case 0:
                        Console.WriteLine("Saindo... Até mais!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }
    }
}
