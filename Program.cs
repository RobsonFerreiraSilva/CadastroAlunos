using ConsoleApp1;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace teste
{ 
    class Program
    {
        static void Main(string[] args)
        {
            List<Aluno> alunos = new List<Aluno>();

            while (true)
            {
                Console.WriteLine("-----MENU-----");
                Console.WriteLine("1. Digite os dados do aluno");
                Console.WriteLine("2. Dados dos alunos");
                Console.WriteLine("3. Média da turma");
                Console.WriteLine("4. Remover aluno");
                Console.WriteLine("5. Sair");
                string opcao = Console.ReadLine();
                Console.WriteLine();


                if (opcao == "1")
                {
                    Aluno aluno = new Aluno();

                    while (true)
                    {
                        Console.Write("Digite o nome do aluno: ");
                        if (aluno.ValidarNome(Console.ReadLine()))
                            break;
                    }


                    while (true)
                    {
                        Console.Write("Digite a idade: ");
                        if (aluno.ValidarIdade(Console.ReadLine()))
                            break;

                    }

                    while (true)
                    {
                        Console.Write("Digite a nota do aluno: ");
                        if (aluno.ValidarNota(Console.ReadLine()))
                            break;
                    }

                    alunos.Add(aluno);
                    Console.WriteLine();

                }

                else if (opcao == "2")
                {
                    Console.WriteLine("-----Lista de alunos-----");
                    foreach (var a in alunos)
                    {
                        a.MostrarDados();
                        a.VerificarAprovaçao();
                        Console.WriteLine("---------------------------");
                    }
                }


                else if (opcao == "3")
                {
                    if (alunos.Count == 0)
                    {
                        Console.WriteLine("Nenhum aluno foi cadastrado");
                    }

                    else
                    {
                        double soma = 0;
                        foreach (var a in alunos)
                        {
                            soma += a.Nota;
                        }

                        double mediaTurma = soma / alunos.Count;
                        Console.WriteLine($"A média da turma foi {mediaTurma:f2}");
                    }
                }

                else if (opcao == "4")
                {
                    Console.WriteLine("Digite o nome do aluno que deseja remover");
                    string nomeRemover = Console.ReadLine().Trim();

                    // LINQ (Language Integrated Query) é usado para consultar coleções de dados de forma mais eficiente
                    var matches = alunos // Usa LINQ para encontrar todos os alunos com o nome correspondente
                        .Select((al, idx) => new { Aluno = al, Index = idx }) // Projeta cada aluno com seu índice
                        .Where(x => x.Aluno.Nome != null && x.Aluno.Nome.Trim().Equals(nomeRemover, StringComparison.OrdinalIgnoreCase)) // Filtra os alunos cujo nome corresponde ao nome fornecido, ignorando maiúsculas/minúsculas e espaços em branco
                        .ToList(); // Converte o resultado em uma lista

                    if (matches.Count == 0)
                    {
                        Console.WriteLine("Aluno não encontrado");
                    }

                    else if (matches.Count == 1)
                    { 
                        alunos.Remove(matches[0].Aluno);
                        Console.WriteLine($"Aluno {matches[0].Aluno.Nome} removido com sucesso");
                    }

                    else
                    {
                        Console.WriteLine($"Foram encontrados {matches.Count} alunos com esse nome:");
                        for (int i = 0; i < matches.Count; i++)
                        {
                            var m = matches[i].Aluno;
                            Console.WriteLine($"{i + 1} - {m.Nome} (Idade: {m.Idade}, Nota: {m.Nota:f2})");
                        }

                        int escolha;
                        while (true)
                        {
                            Console.Write("Digite o número do aluno que deseja remover: ");
                            if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= matches.Count)
                                break;
                            Console.WriteLine("Entrada inválida. Digite um número válido da lista.");
                        }

                        var toRemove = matches[escolha - 1].Aluno;
                        alunos.Remove(toRemove);
                        Console.WriteLine($"Aluno {toRemove.Nome} removido com sucesso!");
                    }
                }

                else if (opcao == "5")
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Opção inválida, Digite um numero valido");
                    continue;
                }

            }
        }
    }
}