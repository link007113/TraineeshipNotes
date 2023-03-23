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
                throw new SaldoTooLowException($"“Uw saldo van {Math.Round(Saldo, 2, MidpointRounding.AwayFromZero)} Euro is ontoereikend om een bedrag van {Math.Round(Saldo, 2, MidpointRounding.AwayFromZero)} mee te betalen”");
            }
            else
            {
                Saldo -= amount;
                return true;
            }
        }
    }
}