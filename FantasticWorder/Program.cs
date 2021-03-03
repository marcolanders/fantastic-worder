namespace FantasticWorder
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        static void Main()
        {
            //tarefa assíncrona para lamber nova classe que lambe o ficheiro de palavras e o carrega para memória

            Regex regex = new Regex(@"^([^a-zA-Z]*[A-Za-z]){4}[\s\S]*");

            Console.WriteLine("Hello World!");

            string first = string.Empty;

            while (first.Length != 4 || !regex.IsMatch(first))
            {
                Console.WriteLine("Please input a four letter start word.");
                first = Console.ReadLine();
            }

            string second = string.Empty;

            while (first.Length != 4 || !regex.IsMatch(second))
            {
                Console.WriteLine("Please input a four letter end word.");
                second = Console.ReadLine();
            }

            Console.WriteLine($"Gotcha! First word is { first }, second word is { second }.");
            //chamada a classe que recebe o dicionário e as duas palavras e calcula o resultado
            //chamada para classe que escreve o resultado num ficheiro
        }
    }
}