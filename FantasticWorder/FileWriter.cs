namespace FantasticWorder
{
    using System.Collections.Generic;
    using System.IO;

    public class FileWriter : IFileWriter
    {
        public void Write(string file, List<string> words)
        {
            using (StreamWriter sw = File.CreateText(file))
            {
                foreach (var word in words)
                {
                    sw.WriteLine(word);
                }
            }
        }
    }
}
