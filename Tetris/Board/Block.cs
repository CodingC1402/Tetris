using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Tetris.Graphics;
using Tetris.Logic;

namespace Tetris.Board
{
    public class Block : ICloneable
    {
        public const int BlockPixelSize = 32;
        public Sprite Sprite;
        public Point LocalPosition = new Point();

        public bool Moving = true;
        public TetrisBlock Parent = null;

        public Point GetWorldPoint()
        {
            if (!Moving)
                return LocalPosition;
            else
                return new Point(Parent.Position.X + LocalPosition.X, Parent.Position.Y + LocalPosition.Y);
        }

        // if touching other blocks or the end it will return false else return true
        public bool CheckMoveDown()
        {
            Point newPos = GetWorldPoint();
            newPos.Y++;

            if (newPos.Y < 0)
                return true;

            if (newPos.Y >= BoardLogic.NumberOfRow)
                return false;

            if (newPos.Y < 0)
                return true;

            var block = BoardLogic.Blocks[newPos.Y][newPos.X];
            return block == null;
        }

        public bool CheckMoveRight()
        {
            Point newPos = GetWorldPoint();
            newPos.X++;

            if (newPos.X >= BoardLogic.NumberOfCol)
                return false;

            if (newPos.Y < 0)
                return true;

            var block = BoardLogic.Blocks[newPos.Y][newPos.X];
            return block == null;
        }

        public bool CheckMoveLeft()
        {
            Point newPos = GetWorldPoint();
            newPos.X--;

            if (newPos.X < 0)
                return false;

            if (newPos.Y < 0)
                return true;

            var block = BoardLogic.Blocks[newPos.Y][newPos.X];
            return block == null;
        }

        public bool CheckCurrentPos()
        {
            Point newPos = GetWorldPoint();

            Block block;

            if (newPos.X < 0 || newPos.X >= BoardLogic.NumberOfCol)
                return false;

            if (newPos.Y < 0)
                return true;

            block = BoardLogic.Blocks[newPos.Y][newPos.X];
            return block == null;
        }

        // Only Used to move a piece already on the board down by 1
        public bool MoveDown()
        {
            if (CheckMoveDown())
            {
                LocalPosition.Y++;
                return true;
            }
            else return false;
        }

        public bool Place()
        {
            if (!Moving)
                return false;

            var worldPos = GetWorldPoint();

            try
            {
                if (BoardLogic.Blocks[worldPos.Y][worldPos.X] != null)
                {
                    throw new Exception("There is already a block here!!!");
                }
                else
                {
                    BoardLogic.Blocks[worldPos.Y][worldPos.X] = this;
                    Moving = false;
                    Parent = null;
                }
                return true;
            }
            catch { return false; }
        }

        public object Clone()
        {
            return new Block()
            {
                Moving = Moving,
                Sprite = Sprite,
                LocalPosition = LocalPosition
            };
        }
    }
}
