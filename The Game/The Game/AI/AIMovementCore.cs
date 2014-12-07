using System;
using System.Collections.Generic;
using System.Threading;
using Confusing_Hobo_Unleashed.Map;

namespace Confusing_Hobo_Unleashed.AI
{
    internal enum Move
    {
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3,
        None = 4
    }

    internal class DirectionBlocker
    {
        private int _counter;
        public bool Enabled { get; set; }

        public int Counter
        {
            get { return _counter; }
            set
            {
                if (value == 1)
                    Enabled = false;
                else if (value > 2)
                    value = 2;
                _counter = value;
            }
        }

        public void Set()
        {
            Counter = -1;
            Enabled = true;
        }
    }

    abstract partial class AiCore
    {
        private readonly Dictionary<Move, bool> _attackDict = new Dictionary<Move, bool>
        {
            {Move.Up, false}
            , {Move.Left, false}
            , {Move.Right, false}
            , {Move.Down, false}
        };

        private readonly Dictionary<Move, DirectionBlocker> _blockers = new Dictionary<Move, DirectionBlocker>
        {
            {Move.Left, new DirectionBlocker()},
            {Move.Right, new DirectionBlocker()},
            {Move.Up, new DirectionBlocker()},
            {Move.Down, new DirectionBlocker()},
        };

        public bool CanFly = false;

        private bool _downForced;
        private bool _hori;
        private bool _leftAllowed;

        public int MinHorizontalProximity = -1;
        public int MinVerticalProximity = -1;
        private int _movementCalculationTimer;
        public int MovementMinTime = 0;
        private int _movementtimer;
        private bool _rightAllowed;

        private bool _upForced;
        private Move _horizontal;
        private int _maxHorizontalProximity;
        private int _maxVerticalProximity;
        private Move _vertical;

        public int MaxHorizontalProximity
        {
            get { return _maxHorizontalProximity; }
            set
            {
                while (value < MinHorizontalProximity + 2 || value < 0)
                    value ++;
                _maxHorizontalProximity = value;
            }
        }

        public int MaxVerticalProximity
        {
            get { return _maxVerticalProximity; }
            set
            {
                while (value < MinVerticalProximity + 5 || value < 0)
                    value++;
                _maxVerticalProximity = value;
            }
        }

        public abstract void SelectTarget();

        private bool Check(int xY, int xX, CustomMap map, Move move)
        {
            if (Y + xY >= map.Mapheight || Y + xY < 0 || X + xX >= map.Mapwidth || X + xX < 0)
                return false;
            if (map.Collision[Y + xY, X + xX])
            {
                if (map.Destructible[Y + xY, X + xX])
                {
                    _attackDict[move] = true;
                    return true;
                }
                return false;
            }
            return true;
        }

        public virtual void Movement(CustomMap map)
        {
            _movementCalculationTimer++;
            if (_movementCalculationTimer > MovementMinTime)
            {
                _movementCalculationTimer = 0;
                SelectTarget();
                bool move = DefineDirections(map);
                foreach (var directionBlocker in _blockers)
                    directionBlocker.Value.Counter++;
                if (move)
                {
                    _hori = false;
                    HorizontalMovement(map);
                    VerticalMovement(map);
                }
            }
        }

        private void HorizontalMovement(CustomMap map)
        {
            if (_horizontal == Move.Right || _vertical == Move.Right)
            {
                if (_attackDict[Move.Right])
                    Attack(map, Move.Right);
                MoveRight(map);
                _hori = true;
            }
            else if (_horizontal == Move.Left || _vertical == Move.Left)
            {
                if (_attackDict[Move.Left])
                    Attack(map, Move.Left);
                MoveLeft(map);
                _hori = true;
            }
        }

        private void VerticalMovement(CustomMap map)
        {
            if (_vertical == Move.Up || _horizontal == Move.Up)
            {
                if (_attackDict[Move.Up])
                    Attack(map, Move.Up);
                Jump(map);
            }
            else if ((_vertical == Move.Down || _horizontal == Move.Down))
            {
                if (_attackDict[Move.Down])
                    Attack(map, Move.Down);
                MoveDown(map);
                if (_hori && (_blockers[Move.Left].Enabled || _blockers[Move.Right].Enabled))
                {
                    _blockers[Move.Up].Enabled = true;
                }
            }
            else if (SpeedY == 0 && Check(1, 0, map, Move.Down) && (_vertical == Move.None || _horizontal == Move.None))
            {
                if (_hori && (_blockers[Move.Left].Enabled || _blockers[Move.Right].Enabled))
                {
                    _blockers[Move.Up].Enabled = true;
                }
            }
        }

        private bool DefineDirections(CustomMap map)
        {
            _leftAllowed = false;
            _rightAllowed = false;
            _horizontal = Move.None;
            _vertical = Move.None;
            _upForced = false;
            _downForced = false;
            bool hori = false;
            bool verti = false;
            int temprandom = Random.Next(15);
            for (int i = 0; i < _attackDict.Count; i++)
            {
                _attackDict[(Move) Enum.Parse(typeof (Move), Convert.ToString(i))] = false;
            }
            if (Random.Next(50) == 7 || !(Y - Target.Y > MinVerticalProximity && Y - Target.Y < MaxVerticalProximity || Target.Y - Y > MinVerticalProximity && Target.Y - Y < MaxVerticalProximity))

                if ((Target.Y - Y < MinVerticalProximity || Y - Target.Y > MaxVerticalProximity))
                {
                    _vertical = Destructiblecheck(map, 2);
                    verti = true;
                }
                else if ((Y - Target.Y < MinVerticalProximity || Target.Y - Y > MaxVerticalProximity))
                {
                    _vertical = Destructiblecheck(map, 3);
                    verti = true;
                }
            if ((X - Target.X > MinHorizontalProximity && X - Target.X < MaxHorizontalProximity || Target.X - X > MinHorizontalProximity && Target.X - X < MaxHorizontalProximity))
            {
                if (temprandom > 0)
                {
                    if (verti)
                        return true;
                    return false;
                }
                hori = true;
            }

            if (((Target.X - X <= MinHorizontalProximity && Target.X - X >= 0 || X - Target.X >= MaxHorizontalProximity && X - Target.X >= 0)) || (hori && (Target.X - X <= MinHorizontalProximity && Target.X - X >= 0 || X - Target.X >= MaxHorizontalProximity && X - Target.X >= 0)))
            {
                _horizontal = Destructiblecheck(map, 0);
            }
            else if (((X - Target.X <= MinHorizontalProximity && X - Target.X >= 0 || Target.X - X >= MaxHorizontalProximity && Target.X - X >= 0)) || (hori && ((X - Target.X <= MinHorizontalProximity && X - Target.X >= 0 || Target.X - X >= MaxHorizontalProximity && Target.X - X >= 0))))
            {
                _horizontal = Destructiblecheck(map, 1);
            }
            return true;
        }

        private void Error()
        {
            Game.BotErrorCount++;
        }

        private void ThreeWayOverride()
        {
            if ((!_leftAllowed || _blockers[Move.Left].Enabled) && (!_upForced || _blockers[Move.Up].Enabled) && (!_downForced || _blockers[Move.Down].Enabled))
            {
                _blockers[Move.Left].Set();
            }
            else if ((!_rightAllowed || _blockers[Move.Right].Enabled) && (!_upForced || _blockers[Move.Up].Enabled) && (!_downForced || _blockers[Move.Down].Enabled))
            {
                _blockers[Move.Right].Set();
            }
            else if ((!_leftAllowed || _blockers[Move.Left].Enabled) && (!_rightAllowed || _blockers[Move.Right].Enabled) && (!_downForced || _blockers[Move.Down].Enabled))
            {
                _blockers[Move.Down].Set();
            }
            else if ((!_leftAllowed || _blockers[Move.Left].Enabled) && (!_upForced || _blockers[Move.Up].Enabled) && (!_rightAllowed || _blockers[Move.Right].Enabled))
            {
                _blockers[Move.Up].Set();
            }
        }

        private Move Destructiblecheck(CustomMap map, int direction)
        {
            _leftAllowed = Check(0, -1, map, Move.Left);
            if (map.Grav[Y, X] > 0)
            {
                _upForced = Check(-1, 0, map, Move.Up);

                _downForced = Check(1, 0, map, Move.Down);
            }
            else
            {
                _upForced = Check(1, 0, map, Move.Up);

                _downForced = Check(-1, 0, map, Move.Down);
            }

            _rightAllowed = Check(0, 1, map, Move.Right);
            ThreeWayOverride();
            switch (direction)
            {
                case 0:
                    if (!_leftAllowed || _blockers[Move.Left].Enabled)
                        if (!_upForced || _blockers[Move.Up].Enabled)
                            if (!_downForced || _blockers[Move.Down].Enabled)
                                if (!_rightAllowed || _blockers[Move.Right].Enabled)
                                    Error();
                                else
                                {
                                    _blockers[Move.Left].Set();
                                    return Move.Right;
                                }
                            else if (map.Grav[Y, X] != 0 && !CanFly)
                            {
                                if (_upForced)
                                    _blockers[Move.Up].Enabled = true;
                                if (CanFly)
                                    return Move.Down;
                                return Move.None;
                            }
                            else return Move.Down;
                        else return Move.Up;
                    else return Move.Left;

                    break;
                case 1:
                    if (!_rightAllowed || _blockers[Move.Right].Enabled)
                        if (!_upForced || _blockers[Move.Up].Enabled)
                            if (!_downForced || _blockers[Move.Down].Enabled)
                                if (!_leftAllowed || _blockers[Move.Left].Enabled)
                                    Error();
                                else
                                {
                                    _blockers[Move.Right].Set();
                                    return Move.Left;
                                }
                            else if (map.Grav[Y, X] != 0 && !CanFly)
                            {
                                if (_upForced)
                                    _blockers[Move.Up].Enabled = true;
                                if (CanFly)
                                    return Move.Down;
                                return Move.None;
                            }
                            else return Move.Down;
                        else return Move.Up;
                    else return Move.Right;
                    break;
                case 2:
                    if (!_upForced || _blockers[Move.Up].Enabled)
                        if (!_leftAllowed || _blockers[Move.Left].Enabled)
                            if (!_rightAllowed || _blockers[Move.Right].Enabled)
                                if (!_downForced || _blockers[Move.Down].Enabled)
                                    Error();
                                else
                                {
                                    _blockers[Move.Up].Set();
                                    if (map.Grav[Y, X] != 0 && !CanFly)
                                    {
                                        if (_upForced)
                                            _blockers[Move.Up].Enabled = true;
                                        if (CanFly)
                                            return Move.Down;
                                        return Move.None;
                                    }
                                    return Move.Down;
                                }
                            else return Move.Right;
                        else return Move.Left;
                    else return Move.Up;
                    break;
                case 3:
                    /*   if ((!DownForced||blockers[Move.Down].Enabled))
                    {
                        if (LeftAllowed || RightAllowed)
                        {
                            if (UpForced||!blockers[Move.Up].Enabled)
                            {
                              blockers[Move.Down].Set();
                                return Move.Up; 
                            }
                            if (RightAllowed&&!blockers[Move.Right].Enabled)
                                return Move.Right;
                            if (LeftAllowed&&!blockers[Move.Left].Enabled)
                                return Move.Left;
                            
                        }
                   }
                    else if (map.Grav[Y, X] != 0 && !CanFly)
                    {
                        if (CanFly)
                            return Move.Down;
                        return Move.None;
                    }    

                    else return Move.Down;*/
                    if (!_downForced || _blockers[Move.Down].Enabled)
                        if (!_leftAllowed || _blockers[Move.Left].Enabled)
                            if (!_rightAllowed || _blockers[Move.Right].Enabled)
                                if (!_upForced || _blockers[Move.Up].Enabled)
                                    Error();
                                else
                                {
                                    _blockers[Move.Down].Set();
                                    if (map.Grav[Y, X] != 0 && !CanFly)
                                    {
                                        if (_upForced)
                                            _blockers[Move.Up].Enabled = true;
                                        if (CanFly)
                                            return Move.Down;
                                        return Move.None;
                                    }
                                    return Move.Up;
                                }
                            else return Move.Right;
                        else return Move.Left;
                    else return Move.Down;
                    break;
            }
            return Move.Up;
        }

        public void Jump(CustomMap map)
        {
            if (!IsPossibleMove(map, Move.Down) && map.Grav[Y, X] > 0 || !IsPossibleMove(map, Move.Up) && map.Grav[Y, X] < 0)
            {
                SpeedY = map.Grav[Y, X]/10;
            }
            else if (CanFly)
            {
                SpeedY = 1;
            }
        }

        public virtual void SetCollision()
        {
            Map.Collision[Y, X] = true;
        }

        public void MoveUp(CustomMap map)
        {
            if (IsPossibleMove(map, Move.Up) && SpeedY > 0)
            {
                if (_movementtimer >= map.Grav[Y, X]%10)
                {
                    _movementtimer = 1;
                    SpeedY--;
                    Y--;
                }
                else _movementtimer++;
            }
            else if (IsPossibleMove(map, Move.Down) && SpeedY < 0)
            {
                if (_movementtimer >= map.Grav[Y, X]%10)
                {
                    _movementtimer = 1;
                    SpeedY++;
                    Y++;
                }
                else _movementtimer++;
            }
            else
            {
                SpeedY = 0;
            }
        }

        public void MoveLeft(CustomMap map)
        {
            if (IsPossibleMove(map, Move.Left))
            {
                X--;
                FacingRight = false;
            }
        }

        public void MoveRight(CustomMap map)
        {
            if (IsPossibleMove(map, Move.Right))
            {
                X++;
                FacingRight = true;
            }
        }

        public void MoveDown(CustomMap map)
        {
            if (_movementtimer >= Math.Abs(map.Grav[Y, X]%10))
            {
                if (IsPossibleMove(map, Move.Down) && map.Grav[Y, X] > 0)
                {
                    _movementtimer = 1;
                    Y++;
                }
                else if (IsPossibleMove(map, Move.Up) && map.Grav[Y, X] < 0)
                {
                    _movementtimer = 1;
                    Y--;
                }
            }
            else _movementtimer++;
        }

        public bool IsPossibleMove(CustomMap map, Move richting)
        {
            if (Y == 54)
                Thread.Sleep(1);
            switch (richting)
            {
                case Move.Down:
                    if (Y + Math.Abs(map.Grav[Y, X]%10) >= map.Mapheight || Y + Math.Abs(map.Grav[Y, X]%10) < 0 || Y + 1 < map.Mapheight && map.Collision[Y + 1, X])
                        return false;
                    return true;

                case Move.Up:
                    if (Y - Math.Abs(map.Grav[Y, X]%10) < 0 || Y - Math.Abs(map.Grav[Y, X]%10) >= map.Mapheight || (Y - 1 > 0 && map.Collision[Y - 1, X]))
                        return false;
                    return true;

                case Move.Left:
                    if (X - 1 < 0 || X - 1 > 0 && map.Collision[Y, X - 1] && Y < map.Mapheight && Y >= 0)
                        return false;
                    return true;

                case Move.Right:
                    if (X + 1 >= map.Mapwidth || X + 1 < map.Mapwidth && map.Collision[Y, X + 1] && Y < map.Mapheight && Y >= 0)
                        return false;
                    return true;

                default:
                    return true;
            }
        }
    }
}