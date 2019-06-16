namespace Confusing_Hobo_Unleashed.Enemies
{
    public abstract class MovementController:EntityDecorator
    {
        protected MovementController(Updateable decoratedEntity) : base(decoratedEntity)
        {
        }

        public override void Update()
        {
            base.Update();
        }
    }
}