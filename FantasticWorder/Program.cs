namespace FantasticWorder
{
    using SimpleInjector;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Program
    {
        static readonly Container container;

        /// <summary>
        /// 
        /// </summary>
        static Program()
        {
            container = new Container();

            container.Register<IFileReader, FileReader>();
            container.Register<IDictionaryReader, DictionaryReader>();
            container.Register<IWorder, Worder>();

            container.Verify();
        }

        /// <summary>
        /// 
        /// </summary>
        static void Main()
        {
            var read = new Task<List<string>>(() => { return container.GetInstance<IDictionaryReader>().Read(); });
            read.Start();

            var regex = new Regex(@"^[A-Za-z]{4}$");

            Console.WriteLine("Hello World!");

            var first = string.Empty;

            while (!regex.IsMatch(first))
            {
                Console.WriteLine("Please input a four letter start word.");
                first = Console.ReadLine();
            }

            string second = string.Empty;

            while (!regex.IsMatch(second))
            {
                Console.WriteLine("Please input a four letter end word.");
                second = Console.ReadLine();
            }

            Console.WriteLine($"Gotcha! First word is { first }, second word is { second }.");
            read.Wait();
            Console.WriteLine($"Read { read.Result.Count } words into the dictionary.");

            container.GetInstance<IWorder>().Wordate(first, second, read.Result);

            //todo: chamar outra classe para receber o dicionário e as duas palavras e calcular o resultado

            //todo: chamar outra classe para escrever o resultado num ficheiro
        }
    }
}