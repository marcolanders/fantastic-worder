namespace FantasticWorder
{
    using System.Collections.Generic;
    using System.Linq;

    public class Worder : IWorder
    {
        public List<string> Wordate(string first, string last, List<string> dictionary)
        {
            var result = new List<string> { first };
            return this.Transform(first, last, dictionary, ref result);
        }

        private List<string> Transform(string first, string last, List<string> dictionary, ref List<string> result)
        {
            List<string> possibles = new List<string>();

            int d = Differences(first, last);

            if (d == 0)
            {
                possibles.Add(dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(last.First(), first.Substring(1)), true) == 0));

                if (first.Skip(1).First() != last.Skip(1).First())
                {
                    possibles.Add(dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(first.First(), last.Skip(1).First(), first.Substring(2)), true) == 0));
                }

                if (first.Skip(2).First() != last.Skip(2).First())
                {
                    possibles.Add(dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(first.First(), first.Skip(1).First(), last.Skip(2).First(), first.Skip(3).First()), true) == 0));
                }

                if (first.Skip(3).First() != last.Skip(3).First())
                {
                    possibles.Add(dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(first.First(), first.Skip(1).First(), first.Skip(2).First(), last.Skip(3).First()), true) == 0));
                }

                return Possibilities(first, last, dictionary, possibles, ref result);
            }
            else if (d == 1)
            {
                possibles.Add(dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(first.First(), last.Skip(1).First(), first.Substring(2)), true) == 0));

                if (first.Skip(2).First() != last.Skip(2).First())
                {
                    possibles.Add(dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(first.First(), first.Skip(1).First(), last.Skip(2).First(), first.Skip(3).First()), true) == 0));
                }

                if (first.Skip(3).First() != last.Skip(3).First())
                {
                    possibles.Add(dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(first.First(), first.Skip(1).First(), first.Skip(2).First(), last.Skip(3).First()), true) == 0));
                }

                return Possibilities(first, last, dictionary, possibles, ref result);
            }
            else if (d == 2)
            {
                possibles.Add(dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(first.First(), first.Skip(1).First(), last.Skip(2).First(), first.Skip(3).First()), true) == 0));

                if (first.Skip(3).First() != last.Skip(3).First())
                {
                    possibles.Add(dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(first.First(), first.Skip(1).First(), first.Skip(2).First(), last.Skip(3).First()), true) == 0));
                }

                return Possibilities(first, last, dictionary, possibles, ref result);
            }
            else if (d == 3)
            {
                result.Add(last);
                return result;
            }

            return result;
        }

        private int Differences(string first, string last)
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != last[i])
                {
                    return i;
                }
            }

            return -1;
        }

        private List<string> Possibilities(string first, string last, List<string> dictionary, List<string> possibles, ref List<string> result)
        {
            foreach (var item in possibles.Where(w => w != null))
            {
                if (item == last)
                {
                    result.Add(last);
                }
                else
                {
                    result.Add(item);
                    var partial = this.Transform(item, last, dictionary, ref result);
                    if (partial.Last() == last)
                    {
                        return partial;
                    }
                    else
                    {
                        result.Remove(item);
                    }
                }
            }

            return result;
        }
    }
}
