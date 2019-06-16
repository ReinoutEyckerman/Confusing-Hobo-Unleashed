using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.Enemies
{
    internal class Harpy:Updateable
    {
        private Updateable _entity;
        public Harpy()
        {
            _entity= new RandomMovement(new DamageController(new SpellControl(new Entity())));
        }

        public void Update()
        {
            _entity.Update();
        }
    }
}