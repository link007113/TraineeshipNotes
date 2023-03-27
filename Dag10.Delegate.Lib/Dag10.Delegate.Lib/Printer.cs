namespace Dag10.Delegate.Lib
{
    public static class Printer
    {
        public static string Print(int getal, Formateerder formateerder)
        {
            string print = formateerder.Invoke(getal);

            Console.WriteLine(print);
            return print;
        }
    }
}