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
            var rotateTime = Program.GetRandom(0, 4);
            for (int i = 0; i < rotateTime; i++)
            {
                newTetris.Rotate();
            }

            return newTetris;
        }

        public Block[][] Matrix;

        private Point _position = new Point();
        public Point Position
        {
            get => _position;
            set
            {
                if (_position != value)
                {
                    _position = value;
                    UpdateShadow();
                }
            }
        }
        public Point ShadowPosition;

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

            _position.X++;
            UpdateShadow();
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

            _position.X--;
            UpdateShadow();
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

            _position.Y++;
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
            // Create new copy of the old matrix
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
            // Rotate the copy
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
                    }

                    newMatrix[row][col] = fourthBlock;
                    if (fourthBlock != null)
                    {
                        fourthBlock.LocalPosition.X = col;
                        fourthBlock.LocalPosition.Y = row;
                    }

                    newMatrix[secondCountRow][secondCountCol] = firstBlock;
                    if (firstBlock != null)
                    {
                        firstBlock.LocalPosition.X = secondCountCol;
                        firstBlock.LocalPosition.Y = secondCountRow;
                    }

                    newMatrix[thirdCountRow][thirdCountCol] = secondBlock;
                    if (secondBlock != null)
                    {
                        secondBlock.LocalPosition.X = thirdCountCol;
                        secondBlock.LocalPosition.Y = thirdCountRow;
                    }
                }
            }

            bool needShiftLeft = false;
            bool needShiftRight = false;

            bool needShiftDown = false;
            bool needShiftUp = false;

            for (var row = 0; row < newMatrix.Length; row++)
            {
                bool collide = false;

                for (int col = 0; col < newMatrix[row].Length; col++)
                {
                    var block = newMatrix[row][col];
                    if (block != null && !block.CheckCurrentPos())
                    {
                        collide = true;

                        if (col < newMatrix[row].Length / 2)
                            needShiftRight = true;
                        else
                            needShiftLeft = true;
                    }
                }

                if (collide)
                {
                    if (row < (newMatrix.Length / 2))
                        needShiftDown = true;
                    else
                        needShiftUp = true;
                }
            }

            if (needShiftUp && needShiftDown)
                canRotate = false;
            else if (needShiftUp)
            {
                canRotate = CheckShiftUp(newMatrix);
            }
            else if (needShiftDown)
            {
                canRotate = CheckShiftDown(newMatrix);
            }

            if (needShiftLeft && needShiftRight)
                canRotate = false;
            else if (needShiftLeft)
            {
                canRotate =  CheckShiftLeft(newMatrix);
            }
            else if (needShiftRight)
            {
                canRotate = CheckShiftRight(newMatrix);
            }

            if (canRotate)
            {
                Matrix = newMatrix;
                UpdateShadow();
            }

            return canRotate;
        }

        public bool CheckCurrentPos()
        {
            return CheckMatrix(Matrix);
        }

        private bool CheckMatrix(Block[][] matrix)
        {
            foreach (var row in matrix)
            {
                for (int col = 0; col < row.Length; col++)
                {
                    var block = row[col];
                    if (block != null && !block.CheckCurrentPos())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #region Shifting when rotate
        // Will shift left if can, if not return false and do nothing
        private bool CheckShiftLeft(Block[][] matrix)
        {
            int shifted = 0;
            bool ableToShift = CheckMatrix(matrix);
            for (shifted = 0; shifted < matrix.Length / 2 && !ableToShift; shifted++)
            {
                _position.X--;
                ableToShift = CheckMatrix(matrix);
            }

            if (!ableToShift)
            {
                _position.X += shifted;
            }

            return ableToShift;
        }
        // Will shift right if can, if not return false and do nothing
        private bool CheckShiftRight(Block[][] matrix)
        {
            int shifted = 0;
            bool ableToShift = CheckMatrix(matrix);
            for (shifted = 0; shifted < matrix.Length / 2 && !ableToShift; shifted++)
            {
                _position.X++;
                ableToShift = CheckMatrix(matrix);
            }

            if (!ableToShift)
            {
                _position.X -= shifted;
            }

            return ableToShift;
        }
        // Will shift up if can, if not return false and do nothing
        private bool CheckShiftUp(Block[][] matrix)
        {
            int shifted = 0;
            bool ableToShift = false;
            for (shifted = 0; shifted < matrix.Length / 2 && !ableToShift; shifted++)
            {
                _position.Y--;
                ableToShift = CheckMatrix(matrix);
            }

            if (!ableToShift)
            {
                _position.Y += shifted;
            }

            return ableToShift;
        }
        // Will shift down if can, if not return false and do nothing
        private bool CheckShiftDown(Block[][] matrix)
        {
            int shifted = 0;
            bool ableToShift = false;
            for (shifted = 0; shifted < matrix.Length / 2 && !ableToShift; shifted++)
            {
                _position.Y++;
                ableToShift = CheckMatrix(matrix);
            }

            if (!ableToShift)
            {
                _position.Y -= shifted;
            }

            return ableToShift;
        }
        #endregion

        public void Dispose()
        {
            foreach (var row in Matrix)
            {
                foreach (var col in row)
                {
                    if (col != null && !col.Place())
                    {
                        BoardLogic.Start(BoardLogic.CurrentGameMode);
                        return;
                    }
                }
            }

            BoardLogic.CheckClear(Math.Min(Position.Y + Matrix.Length - 1, BoardLogic.NumberOfRow - 1), Matrix.Length);
        }

        public void UpdateShadow()
        {
            ShadowPosition = Position;

            bool hitBottom = false;
            while (!hitBottom)
            {
                foreach (Block[] row in Matrix)
                {
                    foreach (Block block in row)
                    {
                        if (block != null && !block.CheckShadowCast())
                        {
                            return;
                        }
                    }
                }

                ShadowPosition.Y++;
            }
        }
    }
}
