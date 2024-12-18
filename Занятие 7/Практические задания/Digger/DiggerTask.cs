﻿using System;
using Avalonia.Input;

namespace Digger;

using Digger.Architecture;
using System;
using Avalonia.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Digger
{

    public class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {

            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {

            return true;
        }

        public int GetDrawingPriority()
        {

            return 1;
        }

        public string GetImageFileName()
        {
            return "Terrain.png";
        }

        public bool IsDead()
        {
            throw new NotImplementedException();
        }
    }
    public class Player : ICreature
    {

        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            if (Game.KeyPressed == Avalonia.Input.Key.Up && y > 0)
            {
                result.DeltaY = -1;
            }
            if (Game.KeyPressed == Avalonia.Input.Key.Down && Game.MapHeight - 1 > y)
            {
                result.DeltaY = 1;
            }
            if (Game.KeyPressed == Avalonia.Input.Key.Left && x > 0 && Game.MapWidth > x)
            {
                result.DeltaX = -1;
            }
            if (Game.KeyPressed == Avalonia.Input.Key.Right && x < Game.MapWidth - 1)
            {
                result.DeltaX = 1;
            }
            return result;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return (conflictedObject is Sack || conflictedObject is Monster);
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }

        public bool IsDead()
        {
            throw new NotImplementedException();
        }
    }
    public class Sack : ICreature
    {
        int Height = 0;
        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            if (y < Game.MapHeight - 1 && Game.Map[x, y + 1] == null)
            {
                result.DeltaY = 1;
                Height++;
            }
            else if (y < Game.MapHeight - 1 && (Game.Map[x, y + 1].GetType() == new Player().GetType() || Game.Map[x, y + 1].GetType() == new Monster().GetType()) && Height > 0)//если мешок не на дне карты(как и в первом случае) и под мешком диггер или монстр
            {
                result.DeltaY = 1;
                Height++;
            }
            else if (Height > 1 || y == Game.MapHeight)
                result.TransformTo = new Gold();
            else Height = 0;
            return result;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Sack.png";
        }

        public bool IsDead()
        {
            throw new NotImplementedException();
        }
    }
    public class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();

        }

        public bool DeadInConflict(ICreature conflictedObject)
        {

            if (conflictedObject is Player)
            {
                Game.Scores += 10;
            }
            return true;
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Gold.png";
        }

        public bool IsDead()
        {
            throw new NotImplementedException();
        }
    }
    public class Position
    {
        public int X;
        public int Y;
    }
    public class Monster : ICreature
    {
        public bool GoOrNo(int x, int y)
        {
            return (Game.Map[x, y] == null || Game.Map[x, y].GetType() == new Gold().GetType()
            || Game.Map[x, y].GetType() == new Player().GetType());
        }
        public Position GetDiggerPosition()
        {
            Position result = null;
            for (int i = 0; i < Game.MapWidth; i++)
                for (int j = 0; j < Game.MapHeight; j++)
                {
                    if (Game.Map[i, j] != null && Game.Map[i, j].GetType() == new Player().GetType())
                    {
                        result = new Position { X = i, Y = j };
                        break;
                    }
                }
            return result;
        }
        public CreatureCommand Act(int x, int y)
        {
            var result = new CreatureCommand();
            var positionDigger = GetDiggerPosition();
            if (positionDigger != null)
            {
                if (positionDigger.X < x && GoOrNo(x - 1, y))
                    result.DeltaX -= 1;
                if (positionDigger.X > x && GoOrNo(x + 1, y))
                    result.DeltaX += 1;
                if (positionDigger.Y < y && GoOrNo(x, y - 1))
                    result.DeltaY -= 1;
                if (positionDigger.Y > y && GoOrNo(x, y + 1))
                    result.DeltaY += 1;
            }
            return result;
        }
        public bool DeadInConflict(ICreature conflictedObject)
        {
            return (conflictedObject.GetType() == new Sack().GetType());
        }

        public int GetDrawingPriority()
        {
            return 1;
        }
        public string GetImageFileName()
        {
            return "Monster.png";
        }

        public bool IsDead()
        {
            throw new NotImplementedException();
        }
    }


}
