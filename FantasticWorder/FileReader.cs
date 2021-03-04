namespace FantasticWorder
{
    public class FileReader
    {
        public string[] Read(string filename)
        {
            return System.IO.File.ReadAllLines(filename);
        }
    }
}
