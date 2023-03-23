namespace Dag08.Betaalkaarten.Lib
{
    public class NormalCard : BaseCard
    {
        public NormalCard(string name, decimal saldo)
        {
            Name = name;
            Saldo = saldo;
        }

        public override bool Pay(decimal amount)
        {
            if (amount < 0 || Saldo - amount < 0)
            {
                return false;
            }
            else
            {
                Saldo -= amount;
                return true;
            }
        }
    }
}