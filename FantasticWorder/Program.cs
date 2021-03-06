namespace FantasticWorder
{
    using SimpleInjector;
    using System;
    using System.Collections.Generic;
    using System.IO;
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
            container.Register<IFileWriter, FileWriter>();

            container.Verify();
        }

        /// <summary>
        /// 
        /// </summary>
        static void Main()
        {
            var file = string.Empty;

            while (!File.Exists(file))
            {
                Console.WriteLine("Please input dictionary file name."); //words-english.txt
                file = Console.ReadLine();
            }

            var reader = new Task<List<string>>(() => { return container.GetInstance<IDictionaryReader>().Read(file); });
            reader.Start();

            var regex = new Regex(@"^[A-Za-z]{4}$");

            Console.WriteLine("Hello World!");

            var first = string.Empty;

            while (!regex.IsMatch(first))
            {
                Console.WriteLine("Please input a four letter start word.");
                first = Console.ReadLine();
            }

            string last = string.Empty;

            while (!regex.IsMatch(last))
            {
                Console.WriteLine("Please input a four letter end word.");
                last = Console.ReadLine();
            }

            Console.WriteLine($"Gotcha! First word is { first }, second word is { last }.");
            reader.Wait();
            Console.WriteLine($"Read { reader.Result.Count } words into the dictionary.");

            var worder = new Task<List<string>>(() => { return container.GetInstance<IWorder>().Wordate(first, last, reader.Result); });
            worder.Start();

            Console.WriteLine("Please input answer file name.");
            file = Console.ReadLine();

            worder.Wait();
            foreach (var word in worder.Result)
            {
                Console.WriteLine($"{ word }.");
            }

            container.GetInstance<IFileWriter>().Write(file, worder.Result);
        }
    }
}