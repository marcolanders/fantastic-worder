namespace FantasticWorder
{
    using System.Collections.Generic;

    public interface IWorder
    {
        List<string> Wordate(string first, string last, List<string> dictionary);
    }
}
