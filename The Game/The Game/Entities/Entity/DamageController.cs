namespace Confusing_Hobo_Unleashed.Enemies
{
    public class DamageController: EntityDecorator
    {
        public DamageController(Updateable decoratedEntity) : base(decoratedEntity)
        {
        }

        public override void Update()
        {
            base.Update();
        }
    }
}