using System;
using System.Collections.Generic;
using Confusing_Hobo_Unleashed.AI;
using Confusing_Hobo_Unleashed.User;

namespace Confusing_Hobo_Unleashed.Enemies
{
    public class DamageController : EntityDecorator
    {
        private Direction _attackDirection;
        public Dictionary<byte, Weapon> WeaponInv { get; set; }

        public DamageController(Updateable decoratedEntity) : base(decoratedEntity)
        {
            _attackDirection = Direction.None;
        }

        public override void Update()
        {
            base.Update();
        }

        public Direction getAttackDirection()
        {
            throw new NotImplementedException();
        }

        public void Attack()
        {
            throw new NotImplementedException();    
        }

        private void attackWeapon(Direction direction, Weapon weapon)
        {
            weapon.Use(direction);
        }

        private void Animate(Direction direction)
        {
            throw new NotImplementedException();
        }

    }
}