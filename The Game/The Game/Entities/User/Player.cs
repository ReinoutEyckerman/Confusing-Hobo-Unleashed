using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.Colors;
using Lidgren.Network;

namespace Confusing_Hobo_Unleashed.User
{
    internal class Player : AiCore
    {
        public Player(CustomMap map) : base(map)
        {
            Target = null;
        }

        public Player(CustomMap map, short xpos, short ypos, int totalHp, char playerCharacter, ConsoleColor backGround,
            ConsoleColor foreGround) : base(map, xpos, ypos, totalHp, playerCharacter, backGround, foreGround)
        {
            Target = null;
        }

        public string Name { get; set; }
        public NetConnection Connection { get; set; }

        public override void SelectTarget()
        {
        }

        public override void Special()
        {
        }

        public override void CalculateAttack()
        {
        }

        public override void Movement(CustomMap map)
        {
            if (Connection == null)
                InputHandler.GameInputHandling(0);
        }

        public override void SetSpawn()
        {
            X = 0;
            Y = 0;
            for (short xpos = 0; xpos < Map.Mapwidth; xpos++)
            {
                for (short ypos = 0; ypos < Map.Mapheight; ypos++)
                {
                    if (Map.Grav[ypos, xpos] >= 0)
                    {
                        if (ypos + 1 < Map.Mapheight && !Map.Collision[ypos, xpos] && Map.Collision[ypos + 1, xpos])
                        {
                            Y = ypos;
                            X = xpos;
                            break;
                        }
                    }
                    else if (Map.Grav[ypos, xpos] < 0)
                        if (ypos - 1 > 0 && !Map.Collision[ypos, xpos] && Map.Collision[ypos - 1, xpos])
                        {
                            Y = ypos;
                            X = xpos;
                            break;
                        }
                }

                if (X != 0 || Y != 0)
                    break;
            }
        }
    }
}