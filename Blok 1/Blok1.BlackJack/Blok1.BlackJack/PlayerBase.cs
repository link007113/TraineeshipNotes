namespace Blok1.BlackJack
{
    public class PlayerBase
    {
        public virtual bool IsDealer => false;

        public string Name { get; protected set; }
        public virtual HandBase PrimaryHand { get; protected set; }

        public PlayerBase()
        {
            Name = "Alice";
            PrimaryHand = new HandBase();
        }

        public PlayerBase(string name)
        {
            Name = name;
            PrimaryHand = new HandBase();
        }

        public PlayerBase(HandBase primaryHand)
        {
            PrimaryHand = primaryHand;
        }

        public virtual void ClearHands()
        {
            PrimaryHand = new HandBase();
        }
    }
}