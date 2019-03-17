using Confusing_Hobo_Unleashed.Shapes;

namespace Confusing_Hobo_Unleashed.UI.UIElements
{
    public abstract class ActivateableUI: UIObject
    {
        protected bool isActive;
          private Shape inactiveShape;
          private Shape activeShape;

          public ActivateableUI(Shape activeShape, Shape inactiveShape)
          {
              this.isActive = false;
              this.activeShape = activeShape;
              this.inactiveShape = inactiveShape;
          }

          public override bool IsActive()
          {
              return isActive;//TODO
          }

          public override void HandleAction()
          {
              throw new System.NotImplementedException();
          }

          public override void Draw()
          {
              
            if (IsActive())
            {
                activeShape.Draw();
            }
            else
            {
                inactiveShape.Draw();
            }
          }
    }
}