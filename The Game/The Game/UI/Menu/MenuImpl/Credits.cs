using System;
using System.Collections.Generic;
using System.Threading;
using Confusing_Hobo_Unleashed.Graphics.Image;
using Confusing_Hobo_Unleashed.Tools;
using Confusing_Hobo_Unleashed.UI.Colors;
using Confusing_Hobo_Unleashed.UI.UIElements;
using Confusing_Hobo_Unleashed.UI.Windows;

namespace Confusing_Hobo_Unleashed.UI.Menu.MenuImpl
{
    public class Credits : Menu
    {
        public Credits()
        {
            CircularList<string> Credits = new CircularList<string>
            {
                "Credits", "Web Development", "Spiderman", "Map Design", "Reinout Eyckerman", "Map Editor",
                "Oliver Hofkens", "Graphical Buffering", "Oliver Hofkens", "Player Movement", "Oliver Hofkens",
                "Artificial Intelligence", "Reinout Eyckerman", "Map Generation", "Reinout Eyckerman",
                "Multiplayer Development", "Reinout Eyckerman", "Enslaved during creation process", "Oliver Hofkens",
                "UI Creation", "Oliver Hofkens", "Composer & Sound Effects",
                "Reinout Eyckerman with Panflute and/or voice recorder", "Mentally Unstable", "Tim D'Joos",
                "Map Layering", "Oliver Hofkens", "Other Potential Game Names & Concepts",
                "Bling Bling Llama Bloodbath", "Rocket Powered Samurai Detective", "Flamboyant Hitman Fiasco",
                "Cosmic Mexican Uprising", "Alberto 'Pasta Sauce' Pennewalnuts",
                "Askldite, Goddess of Genital Warts and Sewage", "Divine Unicorn Conquest",
                "M.C. Escher's Spelling with Friends", "Illegal Toast Rampage Redux", "Gothic Monkey Havoc",
                "Advanced Pinball Spatula", "Special Thanks", "Tim Dams", "Stalina", "That guy living in my basement",
                "Svetlana, the polish prostitute", "The coffee machine in the cafetaria",
                "The coffee cup we paid 60 cents for", "Video Game Name Generator", "Sanchez from 'The Block'",
                "The class 1EA1 from year 2013-2014", "Pedro from 'The Vault Teambuilding'", "Reinout's alter ego",
                "No ethnic minorities were harmed during the creation of this game"
            };
            int spacing = 3;
            int windowWidth = AbstractUIFactory.getInstance().getWindow().getWidth();
            int windowHeight = AbstractUIFactory.getInstance().getWindow().getHeight();
            int totalHeight = windowHeight * 2 + Credits.Count * (spacing + 1);
            Pixel[,] grid = new Pixel[windowWidth, totalHeight];
            for (int x = 0; x < windowWidth; x++)
            {
                int y = 0;
                for (; y < totalHeight; y++)
                {
                    grid[x, y] = new Pixel(BaseColor.Void, BaseColor.Void, ' '); //TODO create basic void static 
                }
            }

            Image image = AbstractUIFactory.getInstance().buildImage(grid);

            for (int x = 0; x < windowWidth; x++)
            {
                for (int y = windowHeight; y < totalHeight - windowHeight; y += spacing)
                {
                    Text text = new Text(Credits.currentItem(), new ColorPoint(BaseColor.Void, BaseColor.White),
                        new Position(x, 0));
                    //TODO center this text vertically
                    image.addTopLayer(text.toImage());
                    Credits.increment();
                }
            }

            this.root = new ImageFrame(new Position(0, 0), image);
        }

        protected override void Run()
        {
            //TODO use timer to update screen every 300ms

            if (true) //TODO
            {
                root.Reposition(root.getBoundingBox().getPosition().substract(new Position(0, -1)));
            }

            if (-root.getBoundingBox().getPosition().y + AbstractUIFactory.getInstance().getWindow().getHeight() >
                root.getBoundingBox().getHeight())
            {
                exit(Confusing_Hobo_Unleashed.GameState.StartScreen);
            }
        }

        protected override GameState defaultExitState()
        {
            return Confusing_Hobo_Unleashed.GameState.StartScreen;
        }
    }
}