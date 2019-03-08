using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.MapEdit;
using Confusing_Hobo_Unleashed.Multiplayer;
using Confusing_Hobo_Unleashed.Shapes;
using Confusing_Hobo_Unleashed.TerrainGen;
using Confusing_Hobo_Unleashed.UI;
using Confusing_Hobo_Unleashed.User;
using Microsoft.Xna.Framework.Input;

namespace Confusing_Hobo_Unleashed
{
    internal class StartMenu
    {
        public static List<OptionsMenu> Main = new List<OptionsMenu>();
        public static List<OptionsMenu> Configuration = new List<OptionsMenu>();
        public static List<OptionsMenu> MapEditorMain = new List<OptionsMenu>();
        public static List<OptionsMenu> MapEditorNewMap = new List<OptionsMenu>();
        public static List<OptionsMenu> MapsInFolder = new List<OptionsMenu>();
        public static List<OptionsMenu> Debug = new List<OptionsMenu>();
        public static List<OptionsMenu> ControlsMain = new List<OptionsMenu>();
        public static List<string> Credits = new List<string>();
        public static Thread Fire;
        public static Buffer FireBuffer = new Buffer(Console.WindowWidth*2/5, Console.WindowHeight*5/6, Console.WindowWidth, Console.WindowHeight);
        public static Buffer FireBuffer2 = new Buffer(Console.WindowWidth*2/5, Console.WindowHeight*5/6, Console.WindowWidth, Console.WindowHeight);
        private static short[,] _firepits;
        public static List<OptionsMenu> Versus = new List<OptionsMenu>();


        public static void GenList()
        {
            Configuration = new List<OptionsMenu>();
            MapEditorNewMap = new List<OptionsMenu>();
            MapsInFolder = new List<OptionsMenu>();
            Debug = new List<OptionsMenu>();
            ControlsMain = new List<OptionsMenu>();
            var confpos = 0;
            Main = new List<OptionsMenu> {new OptionsMenu {ButtonList = new List<Button> {new Button {Message = "Start the Game!", Ypos = Console.WindowHeight/5 + (Console.WindowHeight/6)*0, BlockHeight = Console.WindowHeight/9}, new Button {Message = "Versus Mode", Ypos = Console.WindowHeight/5 + (Console.WindowHeight/6)*1, BlockHeight = Console.WindowHeight/9}, new Button {Message = "Map Editor", Ypos = Console.WindowHeight/5 + (Console.WindowHeight/6)*2, BlockHeight = Console.WindowHeight/9}, new Button {Message = "Configuration Screen", Ypos = Console.WindowHeight/5 + (Console.WindowHeight/6)*3, BlockHeight = Console.WindowHeight/9}, new Button {Message = "Credits", Ypos = Console.WindowHeight/5 + (Console.WindowHeight/6)*4, BlockHeight = Console.WindowHeight/9}}}};
            Versus = new List<OptionsMenu> {new OptionsMenu {ButtonList = new List<Button> {new Button {Message = "Single-Player", Ypos = Console.WindowHeight/6 + (Console.WindowHeight/5)*0, BlockHeight = Console.WindowHeight/9}, new Button {Message = "Split-Screen", Ypos = Console.WindowHeight/6 + (Console.WindowHeight/5)*1, BlockHeight = Console.WindowHeight/9}, new Button {Message = "LAN", Ypos = Console.WindowHeight/6 + (Console.WindowHeight/5)*2, BlockHeight = Console.WindowHeight/9}, new Button {Message = "New LAN Server", Ypos = Console.WindowHeight/6 + (Console.WindowHeight/5)*3, BlockHeight = Console.WindowHeight/9}}, TextBoxList = new List<TextBox>()}};
            Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Map Size", Content = "This defines the size in number of rooms on the game-map. Note: Too much rooms may increase loading times or even make the game unable to generate or display properly. You can possibly fix the display size by picking 'Small' in map display size.", XposMax = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + confpos*4 - 1, State = true, ButtonList = new List<Button> {new Button {Message = "Small", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {4, 4, 3}}, new Button {Message = "Medium", Value = true, Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {7, 4, 5}}, new Button {Message = "Large", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {11, 6, 7}}}, TextBoxList = new List<TextBox> {new TextBox {Message = "Custom", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Box = new List<InsertBox> {new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 5)}, new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 1)}}, VarChanger = new List<int> {7, 4}}}});
            confpos++;
            Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Map Display Size", Content = "This defines the size of the displayed rooms on the map. Setting them to 'Small' will display larger maps correctly.", XposMax = Console.WindowWidth*6/7 - (Console.WindowWidth*4/42 + 2)*4, Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Small", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {5, 3}}, new Button {Message = "Medium", Value = true, Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {9, 5}}, new Button {Message = "Large", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, VarChanger = new List<int> {11, 7}}}, TextBoxList = new List<TextBox> {new TextBox {Message = "Custom", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Box = new List<InsertBox> {new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 5)}, new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 1)}}, VarChanger = new List<int> {9, 5}}}});
            confpos++;
            Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Map Exploration Difficulty", Content = "Difficulty of map. Very easy=Start with complete map. Easy=Map is retrievable en rooms discovered are registered. Medium=Map retrievable. Hard=Rooms registered. Very hard=None of these.", XposMax = Console.WindowWidth*6/7 - (Console.WindowWidth*4/42 + 2)*5, Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Very Easy", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*5, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Easy", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Medium", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Hard", Value = true, Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Very Hard", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}}});
            confpos++;
            Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Dead Ends in Map", Content = "The higher this is, the higher the chance is you find dead ends in the map. Setting it too high might not allow the map to generate. Recommended is 6.", XposMax = Console.WindowWidth*6/7 - (Console.WindowWidth*4/42 + 2)*1, Ypos = Console.WindowHeight/6 + confpos*4 - 1, TextBoxList = new List<TextBox> {new TextBox {Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Message = "Dead Ends", Box = new List<InsertBox> {new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 2)}}, VarChanger = new List<int> {6}}}});
            confpos++;
            Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Approvement Rate", Content = "Defines how much of the generated rooms actually have to be used in percent. Setting this too high might not allow map generation. Setting it very low generates random patterns, useful for large maps. Recommended is 70", XposMax = Console.WindowWidth*6/7 - (Console.WindowWidth*4/42 + 2)*1, Ypos = Console.WindowHeight/6 + confpos*4 - 1, TextBoxList = new List<TextBox> {new TextBox {Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Message = "Approvement Rate", Box = new List<InsertBox> {new InsertBox {Length = 3, PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 2)}}, VarChanger = new List<int> {75}}}});
            confpos++;
            Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Spawn Point", Content = "Defines player spawn point on map. Has no real use.", XposMax = Console.WindowWidth*6/7 - (Console.WindowWidth*4/42 + 2)*1, Ypos = Console.WindowHeight/6 + confpos*4 - 1, TextBoxList = new List<TextBox> {new TextBox {Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Message = "Spawn Rate", Box = new List<InsertBox> {new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 5)}, new InsertBox {PosX = Console.WindowWidth*6/7 - (Console.WindowWidth*2/49 + 1)}}, VarChanger = new List<int> {2, 3}}}});
            confpos++;
            Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Color Schemes", Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Normal", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*5, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, Value = true, BlockHeight = 8}, new Button {Message = "Black & White", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "4 Shades of Gray", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "Inverted Shades of Gray ", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "Random ", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}}});
            confpos++;

            Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "World Type", Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Asteroid", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "Air", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}, new Button {Message = "Aboveground", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = true}, new Button {Message = "Underground", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}}});
            confpos++;
            Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Extra", Ypos = Console.WindowHeight/6 + confpos*4 - 1, ButtonList = new List<Button> {new Button {Message = "Invert", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8, Value = false}}});

            confpos++;
            Configuration.Add(new OptionsMenu {BiDirectional = true, Name = "Debug Options", Ypos = Console.WindowHeight/6 + confpos*4 - 1, Content = "", ButtonList = new List<Button> {new Button {Message = "Dead Ends", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*4, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Approvement Rate", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*3, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Side Matrix", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*2, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}, new Button {Message = "Map Positioning", Xpos = Console.WindowWidth*6/7 - (Console.WindowWidth*2/21 + 2)*1, Ypos = Console.WindowHeight/6 + 4*confpos, BlockLength = Console.WindowWidth*2/21, BlockHeight = 8}}});
            Credits = new List<string> {"Credits", "Web Development", "Spiderman", "Map Design", "Reinout Eyckerman", "Map Editor", "Oliver Hofkens", "Graphical Buffering", "Oliver Hofkens", "Player Movement", "Oliver Hofkens", "Artificial Intelligence", "Reinout Eyckerman", "Map Generation", "Reinout Eyckerman", "Multiplayer Development", "Reinout Eyckerman", "Enslaved during creation process", "Oliver Hofkens", "UI Creation", "Oliver Hofkens", "Composer & Sound Effects", "Reinout Eyckerman with Panflute and/or voice recorder", "Mentally Unstable", "Tim D'Joos", "Map Layering", "Oliver Hofkens", "Other Potential Game Names & Concepts", "Bling Bling Llama Bloodbath", "Rocket Powered Samurai Detective", "Flamboyant Hitman Fiasco", "Cosmic Mexican Uprising", "Alberto 'Pasta Sauce' Pennewalnuts", "Askldite, Goddess of Genital Warts and Sewage", "Divine Unicorn Conquest", "M.C. Escher's Spelling with Friends", "Illegal Toast Rampage Redux", "Gothic Monkey Havoc", "Advanced Pinball Spatula", "Special Thanks", "Tim Dams", "Stalina", "That guy living in my basement", "Svetlana, the polish prostitute", "The coffee machine in the cafetaria", "The coffee cup we paid 60 cents for", "Video Game Name Generator", "Sanchez from 'The Block'", "The class 1EA1 from year 2013-2014", "Pedro from 'The Vault Teambuilding'", "Reinout's alter ego", "No ethnic minorities were harmed during the creation of this game"};
            MapEditorMain = new List<OptionsMenu> {new OptionsMenu {ButtonList = new List<Button> {new Button {Message = "Start New Map", BlockHeight = Console.WindowHeight/9, Ypos = Console.WindowHeight/3 + (Console.WindowHeight/4)*0}, new Button {BlockHeight = Console.WindowHeight/9, Message = "Load Map From File", Ypos = Console.WindowHeight/3 + (Console.WindowHeight/4)*1}}}};
            MapEditorNewMap = new List<OptionsMenu> {new OptionsMenu {ButtonList = new List<Button> {new Button {Message = "Gen Clouds Ingame", BlockHeight = Console.WindowHeight/9, Ypos = Console.WindowHeight/3 + (Console.WindowHeight/4)*0}, new Button {BlockHeight = Console.WindowHeight/9, Message = "Gen Sky Ingame", Ypos = Console.WindowHeight/3 + (Console.WindowHeight/4)*1}, new Button {BlockHeight = Console.WindowHeight/9, Message = "Continue", Ypos = Console.WindowHeight/3 + (Console.WindowHeight/4)*2}}}};
        }

        //Bling bling llama bloodbath//Rocket powered samurai detective// Confusing hobo unleashed/ Flamboyant Hitman Fiasco/Cosmic Mexican Uprising/Alberto 'Pasta Sauce' Pennewalnuts/Askldite, Goddess of Genital Warts and Sewage //Divine Unicorn Conquest/M.C. Escher's Spelling with Friends//Illegal Toast Rampage Redux/Gothic Monkey Havoc/Advanced Pinball Spatula
        public static void MainScreen(Window window)
        {
            //DrawFirePits();
            //Fire = new Thread(DrawFire);
            //Fire.Start();
            Fire fire = new Fire(window, new Position(10, 30), 29, 59);
            fire.DrawFire();
            window.Paint();
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Black);
            Console.ForegroundColor = Painter.Instance.Paint(ConsoleColor.White);
            DrawUi.RedrawBackground();
            DrawUi.Select(Main);
        }
    }

    internal class DrawUi
    {
        private static int _curSel;
        private static int _buttonSel;
        public static bool DrawLayout = true;
        public static int ContStartY = Console.WindowHeight/6;
        public static int ContStopX = Console.WindowWidth*6/7;
        public static int ContLength = 9;
        private static string[] _files;
        private static bool _versus = true;
        public static Buffer SelectionBuffer = new Buffer(Console.WindowWidth, Console.WindowHeight, Console.WindowWidth, Console.WindowHeight);
        private static readonly string[] SplashText = {"Insane in the Membrane!", "No midgets were harmed during the creation of this game", "Team Alpha for President!", "We aren't part of the Illuminati, I promise!", "Oliver is a potato", "Did you know the main character's name originally was 'Joe Pottoe'?", "Habla Espanol?", "The panflute is magical", "Reinout is an omnipotent composer!", "I punched a raccoon today!", "Did you know Oliver is 'Average'?", "Be nice, or Oliver will wreck you", "Shrek is Love", "Shrek is Life", "(Don't tell anyone, but the boss's weak point is his big toe!)", "Go play Sandcastle Builder!", "Go outside, or the sun is gonna burn your shit", "Did you know Reinout was harmed during the development of this game?", "Did you know I still don't know what gender the winner of Eurosong is?", "You can play this game with an xbox controller!", "More pixels than Mario!", "Lag? I don't see any lag! Shut up!", "Blame the hairy armpit!", "Runs 60fps smoothly on native!", "More popular than League of Legends!", "Go buy Oliver a coffee! I'm poor, and if we don't, he'll get cranky.", "Habemus Cancer", "We found a witch! May we burn her?", "Have you accepted Raptor Jesus as your lord and saviour?", "She's after my piano!", "Baby, do you wanna bump?", "He's after my diode!", "I saw a deer once. Shit was whack.", "I saw a leprechaun once. It stole a kidney for drug money.", "I'LL SWALLOW YOUR SOUL", "WALUIGI TIME", "Huehuehuehuehuehuehuehuehuehuehuehue", "Hahehe...huheare...huahehrerharah..HUERHUERHUAUREHEHR", "Unfinished/10", "Have you tried 4 shades of gray mode yet?"};
        private static int? _r;

        public static void RedrawBackground()
        {
            SelectionBuffer = new Buffer(Console.WindowWidth, Console.WindowHeight, Console.WindowWidth, Console.WindowHeight);
            for (var i = 0; i < Console.WindowWidth; i++)
                for (var j = 0; j < Console.WindowHeight; j++)
                    SelectionBuffer.Draw(" ", i, j, Painter.Instance.ColorsToAttribute(Painter.Instance.Paint(ConsoleColor.Blue), Painter.Instance.Paint(ConsoleColor.White)));
        }

        public static void Select(List<OptionsMenu> list)
        {
            if (list[_curSel].BiDirectional)
            {
                for (var x = list.Count - 1; x >= 0; x--)
                {
                    list[x].Render(SelectionBuffer);
                }
                list[_curSel].RenderActive(SelectionBuffer);
            }
            for (var x = 0; x < list[_curSel].ButtonList.Count + list[_curSel].TextBoxList.Count; x++)
            {
                if (x < list[_curSel].ButtonList.Count)
                {
                    list[_curSel].ButtonList[x].Render(SelectionBuffer);
                }
                else if (list[_curSel].TextBoxList.Count > 0)
                {
                    var xtemp = x - list[_curSel].ButtonList.Count;
                    list[_curSel].TextBoxList[xtemp].Render(SelectionBuffer);
                }
            }
            if (_buttonSel < list[_curSel].ButtonList.Count)
            {
                list[_curSel].ButtonList[_buttonSel].RenderActive(SelectionBuffer);
            }
            else if (list[_curSel].TextBoxList.Count > 0)
            {
                var xtemp = _buttonSel - list[_curSel].ButtonList.Count;
                list[_curSel].TextBoxList[xtemp].RenderActive(SelectionBuffer);
            }
            if (list == StartMenu.Main)
            {
                DrawTitle(SelectionBuffer);
                WriteSplash();
            }
            SelectionBuffer.Print();
            if (list == StartMenu.Main)
            {
                StartMenu.FireBuffer.SetDrawCord(0, Convert.ToInt16(Console.WindowHeight/6));
                StartMenu.FireBuffer.Print();
                StartMenu.FireBuffer2.SetDrawCord((Convert.ToInt16(Console.WindowWidth*10/15)), Convert.ToInt16(Console.WindowHeight/6));
                StartMenu.FireBuffer2.Print();
            }
            var input = InputHandler.ControlInputHandling();
            switch (input)
            {
                case Buttons.A:
                    RedrawBackground();
                    var tempsel = 0;
                    var tempbut = 0;
                    if (list != StartMenu.Configuration && list != StartMenu.MapEditorNewMap)
                    {
                        tempsel = _curSel;
                        tempbut = _buttonSel;
                        _curSel = 0;
                        _buttonSel = 0;
                    }
                    if (list == StartMenu.Main)
                    {
                        StartMenu.Fire.Abort();
                        switch (tempbut)
                        {
                            case 0:

                                BootScreen.LoadScreen();
                                break;
                            case 1:
                                Select(StartMenu.Versus);
                                break;
                            case 2:
                                _buttonSel = 0;
                                Select(StartMenu.MapEditorMain);
                                break;
                            case 3:
                                Select(StartMenu.Configuration);
                                break;
                            case 4:
                                ShowCredits();
                                break;
                        }
                    }
                    else if (list == StartMenu.Versus)
                    {
                        switch (tempbut)
                        {
                            case 0:
                                CreateMapSelection();
                                break;
                            case 1:
                                CreateMapSelection();
                                break;
                            case 2:
                                Client.Start();
                                break;
                            case 3:
                                Console.ForegroundColor = Painter.Instance.Paint(ConsoleColor.White, true);
                                Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Black);
                                Console.Clear();
                                Server.Start();
                                break;
                        }
                    }
                    else if (list == StartMenu.MapEditorMain)
                    {
                        _versus = false;
                        switch (tempbut)
                        {
                            case 0:
                                _buttonSel = 1;
                                Select(StartMenu.MapEditorNewMap);
                                break;
                            case 1:
                                CreateMapSelection();
                                break;
                        }
                    }
                    else if (list == StartMenu.MapEditorNewMap)
                    {
                        if (_buttonSel <= 1)
                        {
                            StartMenu.MapEditorNewMap[_curSel].ButtonList[_buttonSel].Value = !StartMenu.MapEditorNewMap[_curSel].ButtonList[_buttonSel].Value;
                        }
                        else
                        {
                            var clouds = StartMenu.MapEditorNewMap[_curSel].ButtonList[0].Value;
                            var sky = StartMenu.MapEditorNewMap[_curSel].ButtonList[1].Value;
                            MapEditor.CurrentMapInEditor = new CustomMap(35, 150, true, " ", clouds, sky);
                            MapEditor.WorkingSpace();
                        }
                    }
                    else if (list == StartMenu.MapsInFolder)
                    {
                        var chosenFile = _files[tempsel];

                        int mapwidth;
                        int mapheight;
                        bool dayNightEnabled;
                        bool cloudsEnabled;

                        using (var reader = XmlReader.Create(chosenFile))
                        {
                            reader.ReadToFollowing("Width");
                            mapwidth = reader.ReadElementContentAsInt("Width", "");
                            mapheight = reader.ReadElementContentAsInt("Height", "");
                            dayNightEnabled = Convert.ToBoolean(reader.ReadElementContentAsString("DayNightGen", ""));
                            cloudsEnabled = Convert.ToBoolean(reader.ReadElementContentAsString("CloudGen", ""));
                            reader.Close();
                        }

                        var filename = Path.GetFileName(chosenFile);

                        if (!_versus)
                        {
                            MapEditor.CurrentMapInEditor = new CustomMap(mapheight, mapwidth, false, filename, cloudsEnabled, dayNightEnabled);
                            MapEditor.CurrentMapInEditor.LoadMap(chosenFile);
                            MapEditor.WorkingSpace();
                        }
                        else
                        {
                            Game.CurrentLoadedMap = new CustomMap(mapheight, mapwidth, false, filename, cloudsEnabled, dayNightEnabled);
                            Game.CurrentLoadedMap.LoadMap(chosenFile);
                            Array.Copy(Game.CurrentLoadedMap.Collision, Game.CurrentLoadedMap.CollisionBackUp, Game.CurrentLoadedMap.Mapheight*Game.CurrentLoadedMap.Mapwidth);

                            Game.Start_Versus();
                        }
                    }
                    else if (list == StartMenu.Configuration)
                    {
                        if (_curSel < list.Count - 2)
                            ResetValues(_curSel);
                        if (_buttonSel > StartMenu.Configuration[_curSel].ButtonList.Count - 1)
                        {
                            var textLoc = _buttonSel - StartMenu.Configuration[_curSel].ButtonList.Count;
                            StartMenu.Configuration[_curSel].TextBoxList[textLoc].Insert();
                            StartMenu.Configuration[_curSel].TextBoxList[textLoc].Value = true;
                        }
                        else
                        {
                            if (_curSel != list.Count - 1)
                                list[_curSel].ButtonList[_buttonSel].Value = true;
                            else list[_curSel].ButtonList[_buttonSel].ChangeValue();
                        }
                    }
                    break;

                case Buttons.Back:
                    RedrawBackground();
                    _versus = true;
                    _curSel = 0;
                    _buttonSel = 0;
                    if (list == StartMenu.Versus || list == StartMenu.MapEditorMain || list == StartMenu.MapsInFolder || list == StartMenu.Configuration)
                    {
                        PostStart();
                       // StartMenu.MainScreen();
                    }
                    else if (list == StartMenu.MapEditorNewMap)
                        Select(StartMenu.MapEditorMain);
                    break;

                case Buttons.DPadRight:
                case Buttons.LeftThumbstickRight:
                    if (list[_curSel].BiDirectional)
                    {
                        if (_buttonSel < list[_curSel].TextBoxList.Count + list[_curSel].ButtonList.Count - 1)
                            _buttonSel++;
                        else _buttonSel = 0;
                    }
                    break;
                case Buttons.DPadLeft:
                case Buttons.LeftThumbstickLeft:
                    if (list[_curSel].BiDirectional)
                    {
                        if (_buttonSel > 0)
                            _buttonSel--;
                        else _buttonSel = list[_curSel].TextBoxList.Count + list[_curSel].ButtonList.Count - 1;
                    }
                    break;

                case Buttons.DPadDown:
                case Buttons.LeftThumbstickDown:
                    if (list[_curSel].BiDirectional)
                    {
                        _buttonSel = 0;
                        if (_curSel < list.Count - 1)
                            _curSel++;
                        else _curSel = 0;
                    }
                    else
                    {
                        if (_buttonSel < list[_curSel].TextBoxList.Count + list[_curSel].ButtonList.Count - 1)
                            _buttonSel++;
                        else _buttonSel = 0;
                    }
                    break;
                case Buttons.DPadUp:
                case Buttons.LeftThumbstickUp:
                    if (list[_curSel].BiDirectional)
                    {
                        _buttonSel = 0;
                        if (_curSel > 0) _curSel--;
                        else _curSel = list.Count - 1;
                    }
                    else
                    {
                        if (_buttonSel > 0)
                            _buttonSel--;
                        else _buttonSel = list[_curSel].TextBoxList.Count + list[_curSel].ButtonList.Count - 1;
                    }
                    break;
            }

            Select(list);
        }

        public static void CreateMapSelection()
        {
            _files = Directory.GetFileSystemEntries("maps", "*.xml");
            StartMenu.MapsInFolder = new List<OptionsMenu>();
            for (var x = 0; x < _files.Length; x++)
            {
                StartMenu.MapsInFolder.Add(new OptionsMenu {Name = "Map " + x, Content = _files[x], BiDirectional = true, TextBoxList = new List<TextBox>(), ButtonList = new List<Button>(), XposMax = ContStopX, Ypos = Console.WindowHeight/6 + x*4 - 1});
            }
            Select(StartMenu.MapsInFolder);
        }

        private static void WriteSplash()
        {
            var random = new Random();
            if (_r == null)
                _r = random.Next(SplashText.GetLength(0));

            SelectionBuffer.Draw(SplashText[(int) _r], Console.WindowWidth*3/5, 8, 0);
        }

        public static void ShowCredits()
        {
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Blue);
            Console.Clear();
            for (var y = Console.WindowHeight; y > StartMenu.Credits.Count*-2; y--)
            {
                Console.Clear();
                for (var i = 0; i < StartMenu.Credits.Count; i++)
                {
                    var pos = y + i*2;
                    if (pos < Console.WindowHeight && pos > 0)
                    {
                        Console.SetCursorPosition(Console.WindowWidth/2 - StartMenu.Credits[i].Length/2, pos);
                        Console.Write(StartMenu.Credits[i]);
                    }
                }
                Thread.Sleep(300);
            }
        }

        private static void ResetValues(int x)
        {
            for (var a = 0; a < StartMenu.Configuration[x].ButtonList.Count + StartMenu.Configuration[x].TextBoxList.Count; a++)
                if (a > StartMenu.Configuration[x].ButtonList.Count - 1)
                    StartMenu.Configuration[x].TextBoxList[a - StartMenu.Configuration[x].ButtonList.Count].Value = false;
                else StartMenu.Configuration[x].ButtonList[a].Value = false;
        }

        public static void DrawTitle(Buffer buffer)
        {
            Console.BackgroundColor = Painter.Instance.Paint(ConsoleColor.Blue);
            var meslength = "   ______            ____           _                __  __      __             __  __      __                __             __".Length/2;
            buffer.Draw(@"   ______            ____           _                __  __      __             __  __      __                __             __", Console.WindowWidth/2 - meslength, 1, Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
            buffer.Draw(@"  / ____/___  ____  / __/_  _______(_)___  ____ _   / / / /___  / /_  ____     / / / /___  / /__  ____ ______/ /_  ___  ____/ /", Console.WindowWidth/2 - meslength, 2, Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
            buffer.Draw(@" / /   / __ \/ __ \/ /_/ / / / ___/ / __ \/ __ `/  / /_/ / __ \/ __ \/ __ \   / / / / __ \/ / _ \/ __ `/ ___/ __ \/ _ \/ __  / ", Console.WindowWidth/2 - meslength, 3, Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
            buffer.Draw(@"/ /___/ /_/ / / / / __/ /_/ (__  ) / / / / /_/ /  / __  / /_/ / /_/ / /_/ /  / /_/ / / / / /  __/ /_/ (__  ) / / /  __/ /_/ / ", Console.WindowWidth/2 - meslength, 4, Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
            buffer.Draw(@"\____/\____/_/ /_/_/  \__,_/____/_/_/ /_/\__, /  /_/ /_/\____/_.___/\____/   \____/_/ /_/_/\___/\__,_/____/_/ /_/\___/\__,_/ ", Console.WindowWidth/2 - meslength, 5, Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
            buffer.Draw(@"                                        /____/", Console.WindowWidth/2 - meslength, 6, Painter.Instance.ColorsToAttribute(Console.BackgroundColor, Console.ForegroundColor));
        }

        public static void PostStart(bool color = true)
        {
            foreach (var t in StartMenu.Configuration)
            {
                switch (t.Name)
                {
                    case "Map Size":
                        //Defining Block 1:MapSize
                        for (var x = 0; x < t.ButtonList.Count + t.TextBoxList.Count - 1; x++)
                        {
                            if (x > StartMenu.Configuration[0].ButtonList.Count - 1)
                            {
                                if (StartMenu.Configuration[0].TextBoxList[x - StartMenu.Configuration[0].ButtonList.Count].Value)
                                {
                                    MapGeneration.RoomsHorizontal = StartMenu.Configuration[0].TextBoxList[x - StartMenu.Configuration[0].ButtonList.Count].VarChanger[0];
                                    MapGeneration.RoomsVertical = StartMenu.Configuration[0].TextBoxList[x - StartMenu.Configuration[0].ButtonList.Count].VarChanger[1];
                                    MapGeneration.MaxDeadEnd = StartMenu.Configuration[0].TextBoxList[x - StartMenu.Configuration[0].ButtonList.Count].VarChanger[2];
                                    break;
                                }
                            }
                            else if (StartMenu.Configuration[0].ButtonList[x].Value)
                            {
                                MapGeneration.RoomsHorizontal = StartMenu.Configuration[0].ButtonList[x].VarChanger[0];
                                MapGeneration.RoomsVertical = StartMenu.Configuration[0].ButtonList[x].VarChanger[1];
                                MapGeneration.MaxDeadEnd = StartMenu.Configuration[0].ButtonList[x].VarChanger[2];
                                break;
                            }
                        }
                        MapGeneration.Corridors = new bool[MapGeneration.RoomsHorizontal, MapGeneration.RoomsVertical, 5];
                        MapGeneration.Counter = new bool[MapGeneration.RoomsHorizontal, MapGeneration.RoomsVertical, 5];
                        MapGeneration.EnableMoreCorridors = new int[(MapGeneration.RoomsHorizontal + 1)*(MapGeneration.RoomsVertical + 1), 2];
                        break;
                    case "Map Display Size":
                        //Defining Block 2: MapDrawing
                        for (var x = 0; x < t.ButtonList.Count + t.TextBoxList.Count - 1; x++)
                        {
                            if (x > StartMenu.Configuration[1].ButtonList.Count - 1)
                            {
                                if (StartMenu.Configuration[1].TextBoxList[x - StartMenu.Configuration[1].ButtonList.Count].Value)
                                {
                                    MapDrawing.HorizontalBlockLength = StartMenu.Configuration[1].TextBoxList[x - StartMenu.Configuration[1].ButtonList.Count].VarChanger[0];
                                    MapDrawing.VerticalBlockLength = StartMenu.Configuration[1].TextBoxList[x - StartMenu.Configuration[1].ButtonList.Count].VarChanger[1];
                                    break;
                                }
                            }
                            if (StartMenu.Configuration[1].ButtonList[x].Value)
                            {
                                MapDrawing.HorizontalBlockLength = StartMenu.Configuration[1].ButtonList[x].VarChanger[0];
                                MapDrawing.VerticalBlockLength = StartMenu.Configuration[1].ButtonList[x].VarChanger[1];
                                break;
                            }
                        }
                        break;
                    case "Map Exploration Difficulty":
                        //Defining Block 3: PathFinding
                        if (t.ButtonList[0].Value)
                            MapDrawing.Map = true;
                        if (t.ButtonList[1].Value || t.ButtonList[2].Value)
                            MapDrawing.FindRooms = true;
                        if (t.ButtonList[1].Value || t.ButtonList[3].Value)
                            MapDrawing.MapRetrievable = true;
                        break;
                    case "Dead Ends in Map":
                        //Defining Block 4: Dead Ends
                        MapGeneration.MaxDeadEnd = t.TextBoxList[0].VarChanger[0];
                        break;
                    case "Approvement Rate":
                        //Defining Block 5: Approvement Rate
                        MapGeneration.ApprovementReq = t.TextBoxList[0].VarChanger[0];
                        break;
                    case "Spawn Point":
                        //Defining Block 6: Approvement Rate
                        MapDrawing.Xposcurrent = t.TextBoxList[0].VarChanger[0];
                        MapDrawing.Yposcurrent = t.TextBoxList[0].VarChanger[1];
                        break;
                    case "Debug Options":
                        //Defining Block 7: Debug Options
                        VarDatabase.Debug = false;
                        foreach (var but in t.ButtonList.Where(but => but.Value))
                            VarDatabase.Debug = true;
                        VarDatabase.ShowDeadEnd = t.ButtonList[0].Value;
                        VarDatabase.ShowApprovementRate = StartMenu.Configuration[6].ButtonList[1].Value;
                        VarDatabase.ShowSideMatrix = t.ButtonList[2].Value;
                        VarDatabase.ShowMapSizeDebug = t.ButtonList[3].Value;
                        break;
                    case "Color Schemes":
                        //Defining Color Scheme usage
                        Painter.Instance.Bw = t.ButtonList[1].Value;
                        Painter.Instance.Refresh();
                        for (var b = 0; b < t.ButtonList.Count; b++)
                            if (t.ButtonList[b].Value)
                                Painter.Instance.ColorScheme = (ColorScheme) b;
                        break;
                    case "World Type":
                        if (t.ButtonList[3].Value)
                            VarDatabase.CurrentLayer = Layers.Cave;
                        else if (t.ButtonList[2].Value)
                            VarDatabase.CurrentLayer = Layers.Earth;
                        else if (t.ButtonList[1].Value)
                            VarDatabase.CurrentLayer = Layers.Sky;
                        else if (t.ButtonList[0].Value)
                            VarDatabase.CurrentLayer = Layers.Space;
                        break;
                    case "Extra":
                        VarDatabase.Invertrate = t.ButtonList[0].Value ? 1 : 0;
                        break;
                }
            }
            for (var x = 0; x < 20; x++)
            {
                if (x < StartMenu.Main.Count)
                    StartMenu.Main[x].Recolor();
                if (x < StartMenu.Configuration.Count)
                    StartMenu.Configuration[x].Recolor();
                if (x < StartMenu.ControlsMain.Count)
                    StartMenu.ControlsMain[x].Recolor();
                if (x < StartMenu.MapEditorMain.Count)
                    StartMenu.MapEditorMain[x].Recolor();
                if (x < StartMenu.MapEditorNewMap.Count)
                    StartMenu.MapEditorNewMap[x].Recolor();
                if (x < StartMenu.MapsInFolder.Count)
                    StartMenu.MapsInFolder[x].Recolor();
                if (x < StartMenu.Debug.Count)
                    StartMenu.Debug[x].Recolor();
                if (x < StartMenu.Versus.Count)
                    StartMenu.Versus[x].Recolor();
            }
        }

        public static int ContStartX = Console.WindowWidth/6;
        public static int ContStopY = ContStartX + 10;
    }
}