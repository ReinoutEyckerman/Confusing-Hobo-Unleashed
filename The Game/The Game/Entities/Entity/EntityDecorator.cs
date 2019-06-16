namespace Confusing_Hobo_Unleashed.Enemies
{
    public abstract class EntityDecorator : Updateable
    {
        private readonly Updateable entity;

        public EntityDecorator(Updateable decoratedEntity)
        {
            this.entity = decoratedEntity;
        }

        public virtual void Update()
        {
            entity.Update();
        }
    }
}