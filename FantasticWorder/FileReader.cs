namespace FantasticWorder
{
    public class FileReader : IFileReader
    {
        public string[] Read(string filename)
        {
            return System.IO.File.ReadAllLines(filename);
        }
    }
}
