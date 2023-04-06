namespace Blok1.BlackJack
{
    public abstract class PlayerBase
    {
        public string Name { get; protected set; }

        public PlayerBase()
        {
            Name = "Alice";
        }

        public PlayerBase(string name)
        {
            Name = name;
        }

        public abstract void ClearHands();
    }
}