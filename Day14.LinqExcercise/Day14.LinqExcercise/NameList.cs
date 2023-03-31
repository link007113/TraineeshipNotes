namespace Day14.LinqExcercise
{
    public class NameList
    {
        public List<string> Names = new List<string>()
                                    {
                                        "Anthony",
                                        "Daan",
                                        "Daniel",
                                        "Jasper",
                                        "Mart",
                                        "Niek",
                                        "Rob",
                                        "Yannick",
                                        "Yaouad"
                                    };

        public int CountFromList() => Names.Count;

        public int CountFromListComprehensionContainsA()
        {
            var q = from n in Names
                    where n.Contains("a") || n.Contains("A")
                    select Names.Count;
            return q.Count();
        }

        public int CountFromListExtensionMethodContainsA() => Names.Where(n => n.Contains("a") || n.Contains("A")).Count();

        public char[] AllFirstLettersFromListComprehensionContainsA()
        {
            return (from n in Names
                    where n.Contains("a") || n.Contains("A")
                    orderby n descending
                    select n.First()).ToArray();
        }

        public char[] AllFirstLettersFromListExtensionMethodStartsWithA() =>
            Names.Where(n => n.Contains("a") || n.Contains("A")).
            OrderByDescending(n => n).
            Select(n => n.First()).ToArray();

        public int SumOfAllNamesContainingYComprehensionContains()
        {
            var q = from n in Names
                    where n.Contains("y") || n.Contains("Y")
                    select n.Length;
            return q.Sum();
        }

        public int SumOfAllNamesContainingYExtensionMethodContains() =>
    Names.Where(n => n.Contains("y") || n.Contains("Y"))
         .Select(n => n.Length)
         .Sum();

        public List<String> NamesWithAverageLengthExtensionMethod()
        {
            var averageLength = (int)Names.Average(n => n.Length);

            var namesWithClosestLengths = Names.Where(n => n.Length == averageLength - 1 || n.Length == averageLength || n.Length == averageLength + 1)
                                               .OrderBy(n => n).ToList();

            return namesWithClosestLengths;
        }

        public List<string> NamesWithAverageLengthComprehension()
        {
            var averageLength = (int)Names.Average(n => n.Length);

            var namesWithClosestLengths = (from n in Names
                                           where n.Length == averageLength - 1 || n.Length == averageLength || n.Length == averageLength + 1
                                           orderby n
                                           select n).ToList();

            return namesWithClosestLengths;
        }
    }
}