namespace Day13.LambdaAndLinqDemo
{
    internal class Program
    {
        private static void Main()
        {
            static void Main(string[] args)
            {
                List<int> primes = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

                var q3 = primes.Where(n => n >= 18)
                               .Select(x => x * x);

                var q4 = from p in primes
                         where p >= 18
                         select p * p;

                List<Person> people = new List<Person>
            {
                new(){ Name = "Evert 't Reve", Age = 22},
                new(){ Name = "Mats Nevenstam", Age= 44},
                new(){ Name = "Karina van Irak", Age = 33},
            };
                var oudste = people.Max(p => p.Age);
                Console.WriteLine(oudste);
            }
        }
    }

    internal class Person
    {
        public string Name { get; internal set; }
        public int Age { get; internal set; }
    }
}