namespace FantasticWorder
{
    using System.Collections.Generic;

    interface IFileWriter
    {
        void Write(string file, List<string> words);
    }
}
