using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Confusing_Hobo_Unleashed.Colors;
using Confusing_Hobo_Unleashed.Map;
using Confusing_Hobo_Unleashed.MapEdit;

namespace Confusing_Hobo_Unleashed
{
    internal enum GravFields
    {
        Normal = 51,
        Sea = 83,
        Space = 125
    }

    public enum Maplayers
    {
        Air,
        Collision,
        Destructible,
        Decor,
        Clouds
    }

    public class CustomMap
    {
        public int Invertrate;
        public int Mapheight;
        public int Mapwidth;

        public CustomMap(int mapheight)
        {
            Mapheight = mapheight;
        }

        public CustomMap(int mapheight, int mapwidth, bool newfile, string filename = " ", bool clouds = true, bool daynight = true)
        {
            Invertrate = VarDatabase.Invertrate;
            Mapheight = mapheight;
            Mapwidth = mapwidth;
            Layers = new Dictionary<Maplayers, Layer>
            {
                {Maplayers.Air, new Layer(daynight, mapwidth, mapheight)},
                {Maplayers.Collision, new Layer(true, mapwidth, mapheight)},
                {Maplayers.Destructible, new Layer(true, mapwidth, mapheight)},
                {Maplayers.Decor, new Layer(true, mapwidth, mapheight)},
                {Maplayers.Clouds, new Layer(clouds, mapwidth, mapheight)}
            };

            Grav = new short[mapheight, mapwidth];
            Collision = new bool[mapheight, mapwidth];
            CollisionBackUp = new bool[mapheight, mapwidth];
            Characters = new char?[mapheight, mapwidth];
            Background = new ConsoleColor[mapheight, mapwidth];
            Foreground = new ConsoleColor[mapheight, mapwidth];
            Colors = new short[mapheight, mapwidth];
            Destructible = new bool[mapheight, mapwidth];
            NewFile = newfile;
            FileName = filename;
            CloudsEnabled = clouds;
            DayNightEnabled = daynight;

            for (var i = 0; i < mapheight; i++)
            {
                for (var j = 0; j < mapwidth; j++)
                {
                    foreach (var layer in Layers)
                    {
                        layer.Value.Background[i, j] = ConsoleColor.Black;
                        layer.Value.Foreground[i, j] = ConsoleColor.White;

                        layer.Value.Colors[i, j] = 01;
                    }

                    Grav[i, j] = (short) GravFields.Normal;
                    Collision[i, j] = false;
                    Background[i, j] = ConsoleColor.Black;
                    Foreground[i, j] = ConsoleColor.White;

                    Colors[i, j] = 01;
                    Destructible[i, j] = false;
                }
            }
        }

        public ConsoleColor[,] Background { get; set; }
        public ConsoleColor[,] Foreground { get; set; }
        public char?[,] Characters { get; set; }
        public short[,] Colors { get; set; }
        public bool[,] Collision { get; set; }
        public bool[,] CollisionBackUp { get; set; }
        public short[,] Grav { get; set; }
        public bool[,] Destructible { get; set; }
        public bool NewFile { get; set; }
        public string FileName { get; set; }
        public bool CloudsEnabled { get; set; }
        public bool DayNightEnabled { get; set; }
        public bool Sea { get; set; }
        public bool LowGravity { get; set; }
        public Dictionary<Maplayers, Layer> Layers { get; set; }

        public void RedrawPixel(int xpos, int ypos, buffer outputbuffer)
        {
            var mapchar = Convert.ToString(Characters[ypos, xpos]);
            outputbuffer.Draw(mapchar, xpos, ypos, Colors[ypos, xpos]);
        }

        public void PushtoArray(ConsoleColor[,] SourceBG, ConsoleColor[,] SourceFG, short[,] Destination)
        {
            for (var i = 0; i < SourceBG.GetLength(0); i++)
            {
                for (var j = 0; j < SourceBG.GetLength(1); j++)
                {
                    Destination[i, j] = Painter.Instance.ColorsToAttribute(SourceBG[i, j], SourceFG[i, j]);
                }
            }
        }

        public void SaveMap()
        {
            //Create the maps directory in case it doesn't exist yet.
            Directory.CreateDirectory("maps");

            using (var writer = XmlWriter.Create("maps/" + FileName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Map");
                writer.WriteElementString("Width", Mapwidth.ToString());
                writer.WriteElementString("Height", Mapheight.ToString());
                writer.WriteElementString("DayNightGen", DayNightEnabled.ToString());
                writer.WriteElementString("CloudGen", CloudsEnabled.ToString());

                writer.WriteStartElement("CollDest");
                for (var i = 0; i < Collision.GetLength(0); i++)
                {
                    writer.WriteStartElement("Y" + i);
                    for (var j = 0; j < Collision.GetLength(1); j++)
                    {
                        writer.WriteStartElement("X" + j);
                        writer.WriteAttributeString("Col", Collision[i, j].ToString());
                        writer.WriteAttributeString("Des", Destructible[i, j].ToString());
                        writer.WriteEndElement(); //X
                    }
                    writer.WriteEndElement(); //Y
                }
                writer.WriteEndElement(); //Colldest

                foreach (var layer in Layers)
                {
                    writer.WriteStartElement(layer.Key.ToString());

                    for (var i = 0; i < Background.GetLength(0); i++)
                    {
                        writer.WriteStartElement("Y" + i);
                        for (var j = 0; j < Background.GetLength(1); j++)
                        {
                            writer.WriteStartElement("X" + j);
                            writer.WriteAttributeString("Char",
                                layer.Value.Characters[i, j] == null ? "niks" : layer.Value.Characters[i, j].ToString());
                            writer.WriteAttributeString("Color", layer.Value.Colors[i, j].ToString());
                            writer.WriteEndElement(); //X
                        }
                        writer.WriteEndElement(); //Y
                    }

                    writer.WriteEndElement(); //layer
                }

                writer.WriteEndElement(); //doc
                writer.WriteEndDocument();
            }

            MapEditor.SystemMessage("Map saved to Maps/" + FileName);
        }

        public void LoadMap(string filename)
        {
            using (var reader = XmlReader.Create(filename))
            {
                reader.ReadToFollowing("Width");
                Mapwidth = reader.ReadElementContentAsInt();
                Mapheight = reader.ReadElementContentAsInt();
                DayNightEnabled = Convert.ToBoolean(reader.ReadElementContentAsString("DayNightGen", ""));
                CloudsEnabled = Convert.ToBoolean(reader.ReadElementContentAsString("CloudGen", ""));

                for (var i = 0; i < Mapheight; i++)
                {
                    reader.ReadToFollowing("Y" + i);
                    for (var j = 0; j < Mapwidth; j++)
                    {
                        reader.ReadToFollowing("X" + j);
                        Collision[i, j] = Convert.ToBoolean(reader.GetAttribute("Col"));
                        Destructible[i, j] = Convert.ToBoolean(reader.GetAttribute("Des"));
                    }
                }

                foreach (var t in Layers)
                {
                    for (var i = 0; i < Mapheight; i++)
                    {
                        reader.ReadToFollowing("Y" + i);
                        for (var j = 0; j < Mapwidth; j++)
                        {
                            reader.ReadToFollowing("X" + j);
                            var characterInFile = reader.GetAttribute("Char");
                            if (characterInFile == "niks")
                            {
                                t.Value.Characters[i, j] = null;
                            }
                            else
                            {
                                t.Value.Characters[i, j] = Convert.ToChar(characterInFile);
                            }
                            t.Value.Colors[i, j] = Convert.ToInt16(reader.GetAttribute("Color"));
                            t.Value.Background[i, j] = Painter.Instance.BackgroundFromAttribute(t.Value.Colors[i, j]);
                            t.Value.Foreground[i, j] = Painter.Instance.ForegroundFromAttribute(t.Value.Colors[i, j]);
                        }
                    }
                }
                reader.Close();
            }
        }

        public void MapToBuffer(buffer outputbuffer, char?[,] chararray, short[,] colorarray)
        {
            for (var i = 0; i < chararray.GetLength(0); i++)
            {
                for (var j = 0; j < chararray.GetLength(1); j++)
                {
                    if (chararray[i, j].HasValue)
                    {
                        var CharToString = Convert.ToString(chararray[i, j]);
                        outputbuffer.Draw(CharToString, j, i, colorarray[i, j]);
                    }
                }
            }
        }
    }
}