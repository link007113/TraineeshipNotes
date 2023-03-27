using Dag10.Delegate.Lib;

namespace Dag10.Delegate.Program
{
    internal static class Program
    {
        private static void Main()
        {
            Formateerder formateerder = Layout.LieftinckFormaat;
            Printer.Print(36, formateerder);
        }
    }
}