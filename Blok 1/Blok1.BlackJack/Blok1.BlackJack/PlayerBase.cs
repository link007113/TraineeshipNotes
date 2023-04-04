namespace Blok1.BlackJack
{
    public class PlayerBase
    {
        public List<HandBase> Hands { get; set; } = new List<HandBase>();
        public virtual bool IsDealer => false;

        public string Name { get; protected set; }
        public virtual HandBase PrimaryHand => Hands.FirstOrDefault();

        public void ClearHands()
        {
            Hands = new List<HandBase>
            {
                new HandPlayer()
            };
        }
    }
}