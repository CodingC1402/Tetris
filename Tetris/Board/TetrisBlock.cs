using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Tetris.Graphics;
using Tetris.Logic;
using System.Security.Cryptography;

namespace Tetris.Board
{
    public class TetrisBlock : IDisposable
    {
        public static TetrisBlock CreateTetrisBlock()
        {
            var template = TetrisBlockTemplate.GetRandomTemplate();

            var newTetris = new TetrisBlock(template);
            var rotateTime = Program.Rnd.Next(0, 4);
            for (int i = 0; i < rotateTime; i++)
            {
                newTetris.Rotate();
            }

            return newTetris;
        }

        public Block[][] Matrix;
        public Point Position;

        private TetrisBlock(TetrisBlockTemplate template)
        {
            Matrix = new Block[template.Matrix.Length][];
            for (int i = 0; i < Matrix.Length; i++)
            {
                Matrix[i] = new Block[template.Matrix[i].Length];
                for (int r = 0; r < Matrix.Length; r++)
                {
                    if (template.Matrix[i][r] == 1)
                    {
                        Matrix[i][r] = new Block()
                        {
                            Moving = true,
                            Sprite = Sprite.Collection[template.BlockSkinID],
                            LocalPosition = new Point(r, i),
                            Parent = this
                        };
                    }
                }
            }
        }

        public bool MoveRight()
        {
            foreach (Block[] row in Matrix)
            {
                foreach (Block block in row)
                {
                    if (block != null && !block.CheckMoveRight())
                    {
                        return false;
                    }
                }
            }

            Position.X++;
            return true;
        }

        public bool MoveLeft()
        {
            foreach (Block[] row in Matrix)
            {
                foreach (Block block in row)
                {
                    if (block != null && !block.CheckMoveLeft())
                    {
                        return false;
                    }
                }
            }

            Position.X--;
            return true;
        }

        public bool MoveDown()
        {
            foreach (Block[] row in Matrix)
            {
                foreach (Block block in row)
                {
                    if (block != null && !block.CheckMoveDown())
                    {
                        return false;
                    }
                }
            }

            Position.Y++;
            return true;
        }

        public bool CheckMoveDown()
        {
            foreach (Block[] row in Matrix)
            {
                foreach (Block block in row)
                {
                    if (block != null && !block.CheckMoveDown())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void ForcePlace()
        {
            while (MoveDown()) ;
            Dispose();
        }

        public bool Rotate()
        {
            Block[][] newMatrix = new Block[Matrix.Length][];
            for (int i = 0; i < Matrix.Length; i++)
            {
                newMatrix[i] = new Block[Matrix.Length];
                for (int j = 0; j < newMatrix[i].Length; j++)
                {
                    if (Matrix[i][j] != null)
                    {
                        newMatrix[i][j] = (Block)Matrix[i][j].Clone();
                        newMatrix[i][j].Parent = this;
                    }
                }
            }

            bool canRotate = true;
            for (int row = 0; row < Matrix.Length / 2; row++)
            {
                for (int col = row; col <= (Matrix[row].Length - row) / 2; col++)
                {
                    var secondCountRow = col;
                    var secondCountCol = Matrix[row].Length - row - 1;

                    var thirdCountRow = Matrix.Length - 1 - row;
                    var thirdCountCol = Matrix[row].Length - 1 - col;

                    var fourthCountRow = Matrix.Length - 1 - col;
                    var fourthCountCol = row;

                    Block firstBlock = (Block)newMatrix[row][col];
                    Block secondBlock = (Block)newMatrix[secondCountRow][secondCountCol];
                    Block thirdBlock = (Block)newMatrix[thirdCountRow][thirdCountCol];
                    Block fourthBlock = (Block)newMatrix[fourthCountRow][fourthCountCol];

                    newMatrix[fourthCountRow][fourthCountCol] = thirdBlock;
                    if (thirdBlock != null)
                    {
                        thirdBlock.LocalPosition.X = fourthCountCol;
                        thirdBlock.LocalPosition.Y = fourthCountRow;
                        if (!thirdBlock.CheckCurrentPos())
                        {
                            canRotate = false;
                            break;
                        }
                    }

                    newMatrix[row][col] = fourthBlock;
                    if (fourthBlock != null)
                    {
                        fourthBlock.LocalPosition.X = col;
                        fourthBlock.LocalPosition.Y = row;
                        if (!fourthBlock.CheckCurrentPos())
                        {
                            canRotate = false;
                            break;
                        }
                    }

                    newMatrix[secondCountRow][secondCountCol] = firstBlock;
                    if (firstBlock != null)
                    {
                        firstBlock.LocalPosition.X = secondCountCol;
                        firstBlock.LocalPosition.Y = secondCountRow;
                        if (!firstBlock.CheckCurrentPos())
                        {
                            canRotate = false;
                            break;
                        }
                    }

                    newMatrix[thirdCountRow][thirdCountCol] = secondBlock;
                    if (secondBlock != null)
                    {
                        secondBlock.LocalPosition.X = thirdCountCol;
                        secondBlock.LocalPosition.Y = thirdCountRow;
                        if (!secondBlock.CheckCurrentPos())
                        {
                            canRotate = false;
                            break;
                        }
                    }
                }

                if (!canRotate)
                    break;
            }

            if (canRotate)
                Matrix = newMatrix;
            return canRotate;
        }

        public void Dispose()
        {
            foreach (var row in Matrix)
            {
                foreach (var col in row)
                {
                    if (col != null && !col.Place())
                    {
                        BoardLogic.Start();
                        return;
                    }
                }
            }

            BoardLogic.CheckClear(Math.Min(Position.Y + Matrix.Length - 1, BoardLogic.NumberOfRow - 1), Matrix.Length);
        }
    }
}
