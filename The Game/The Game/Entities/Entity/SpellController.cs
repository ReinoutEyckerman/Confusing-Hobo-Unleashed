namespace Confusing_Hobo_Unleashed.Enemies
{
    public class SpellControl: EntityDecorator
    {
        public SpellControl(Updateable decoratedEntity) : base(decoratedEntity)
        {
        }

        public override void Update()
        {
            base.Update();
        }
    }
}