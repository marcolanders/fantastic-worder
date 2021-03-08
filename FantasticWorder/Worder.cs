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

            possibles.Add(FirstLetterPossibilities(first, last, dictionary));
            possibles.Add(SecondLetterPossibilities(first, last, dictionary));
            possibles.Add(ThirdLetterPossibilities(first, last, dictionary));
            possibles.Add(FourthLetterPossibilities(first, last, dictionary));

            return Possibilities(last, dictionary, possibles, ref result);
        }

        private List<string> Possibilities(string last, List<string> dictionary, List<string> possibles, ref List<string> result)
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

        private string FirstLetterPossibilities(string first, string last, List<string> dictionary)
        {
            if (first.First() != last.First())
            {
                return dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(last.First(), first.Substring(1)), true) == 0);
            }

            return null;
        }

        private string SecondLetterPossibilities(string first, string last, List<string> dictionary)
        {
            if (first.Skip(1).First() != last.Skip(1).First())
            {
                return dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(first.First(), last.Skip(1).First(), first.Substring(2)), true) == 0);
            }

            return null;
        }

        private string ThirdLetterPossibilities(string first, string last, List<string> dictionary)
        {
            if (first.Skip(2).First() != last.Skip(2).First())
            {
                return dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(first.First(), first.Skip(1).First(), last.Skip(2).First(), first.Skip(3).First()), true) == 0);
            }

            return null;
        }

        private string FourthLetterPossibilities(string first, string last, List<string> dictionary)
        {
            if (first.Skip(3).First() != last.Skip(3).First())
            {
                return dictionary.FirstOrDefault(f => string.Compare(f, string.Concat(first.First(), first.Skip(1).First(), first.Skip(2).First(), last.Skip(3).First()), true) == 0);
            }

            return null;
        }
    }
}
