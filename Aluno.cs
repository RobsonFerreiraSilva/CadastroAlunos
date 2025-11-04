using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Aluno
    {
        public string Nome;
        public int Idade;
        public double Nota;



        public void MostrarDados()
        {
            Console.WriteLine("Dados do Aluno");
            Console.WriteLine($"Nome do aluno: {Nome}");
            Console.WriteLine($"Idade: {Idade}");
            Console.WriteLine($"Nota: {Nota:f2}");
                
        }

        public bool ValidarNome(string nome)
        {
            string nomeTrim = nome.Trim(); // Trim é usado para remover espaços em branco no início e no fim da string

            if (string.IsNullOrWhiteSpace(nome.Trim()))
            {
                Console.WriteLine("Nome inválido. Digite um nome válido.");
                return false;
            }

            if (nomeTrim.Length < 3) // Length é usado para verificar o comprimento da string
            {
                Console.WriteLine("Nome muito curto. Digite pelo menos 3 caracteres");
                return false;
            }

            foreach (char c in nomeTrim)
            { 
                if (!char.IsLetter(c) && c != ' ') // Verifica se o caractere não é uma letra ou espaço
                {
                    Console.WriteLine("Nome inválido. Digite apenas letras e espaços.");
                    return false;
                }
            }

            Nome = nomeTrim;
            return true;
        }

        public bool ValidarIdade(string input)
        {
            if (int.TryParse(input, out int idade) && idade > 0) // Validação para garantir que a idade seja um número inteiro válido
            {
                Idade = idade;
                return true;
            }
            else
            {
                Console.WriteLine("Idade inválida, tente novamente.");
                return false;

            }

        }

        public bool ValidarNota(string input)
        {
            if (double.TryParse(input, out double nota) && nota >= 0 && nota <= 10) // Validação adicional para garantir que a nota esteja entre 0 e 10
            {
                Nota = nota;
                return true;
            }
            else
            {
                Console.WriteLine("Nota inválida, tente novamente.");
                return false;

            }
        }


        public void VerificarAprovaçao()
        {
            if (Nota >= 6)
            {
                Console.WriteLine($"Aluno {Nome} aprovado");
            }
            else
            {
                Console.WriteLine($"Aluno {Nome} reprovado");
            }
        }

    }
}
