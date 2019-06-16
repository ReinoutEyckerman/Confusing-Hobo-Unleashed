using Confusing_Hobo_Unleashed.Shapes.Complex;
using Confusing_Hobo_Unleashed.UI.UIElements;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class AlphaScreen : Menu
    {
        public AlphaScreen() //TODO fix positioning problem (two new positions?)
        {
            AbstractList list = new HorizontalListBuilder()
                .addUIObject(new ImageFrame(new Position(0, 0), new Alpha().toImage()))
                .addUIObject(new TextBlock(new Position(0, 0),
                    UIFactory.createDefaultText("Confusing Hobo Unleashed", new Position(0, 0))))
                .addUIObject(new TextBlock(new Position(0, 0),
                    UIFactory.createDefaultText("By Oliver Hofkens & Reinout Eyckerman", new Position(0, 0))))
                .addUIObject(new TextBlock(new Position(0, 0),
                    UIFactory.createDefaultText("A Team Alpha Production", new Position(0, 0))))
                .build();
            this.root = list;
        }
    }
}