namespace Confusing_Hobo_Unleashed.Enemies
{
    public class SpellController : EntityDecorator
    {
        private int maxMana;
        private int currentMana;

        public SpellController(int startMana, int maxMana, Updateable decoratedEntity) : base(decoratedEntity)
        {
            this.maxMana = maxMana;
            this.currentMana = startMana;
        }

        public SpellController(int maxMana, Updateable decoratedEntity) : this(maxMana, maxMana, decoratedEntity)
        {
        }

        public override void Update()
        {
            base.Update();
        }
    }
}