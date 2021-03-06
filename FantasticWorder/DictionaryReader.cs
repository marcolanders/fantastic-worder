namespace FantasticWorder
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class DictionaryReader : IDictionaryReader
    {
        private readonly IFileReader reader;

        public DictionaryReader(IFileReader reader)
        {
            this.reader = reader;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> Read(string file)
        {
            var words = new List<string>();

            var regex = new Regex(@"^[A-Za-z]{4}$");

            var lines = this.reader.Read(file);

            foreach (string line in lines)
            {
                if (regex.IsMatch(line))
                {
                    words.Add(line);
                }
            }

            return words;
        }
    }
}
