using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Tetris.Board;
using Tetris.Graphics;
using Tetris.Sound;

namespace Tetris.Logic
{
    public static class BoardLogic
    {
        public static Block[][] Blocks;
        public static TetrisBlock CurrentBlock = null;
        public static TetrisBlock NextBlock = null;

        public static readonly int NumberOfRow = 20;
        public static readonly int NumberOfCol = 10;
        public static readonly float TimeBeforeClear = 0.5f;
        public static readonly int BaseScore = 40;

        private static bool _paused = false;
        public static bool Paused
        {
            get => _paused;
            set
            {
                _paused = value;
            }
        }

        private static bool _clearingRow = false;

        private static float _inputMoveLeftCheckCounter = 0;
        private static float _inputMoveRightCheckCounter = 0;
        private static float _inputMoveDownCheckCounter = 0;
        private static float _delayBetweenEachInputcheck = 0.1f;

        private static float _counter = 0;
        private static float _maxCounter = 3;
        private static int _dropSpeed = 1;
        private static float _delayBetweenDrop;
        private static int _lineCleared = 0;

        private static float _tetrisEffectTime = 1f;
        private static float _tetrisEffectCounter = 0f;
        public static float TetrisEffectCounter { get => _tetrisEffectCounter; }
        public static float TetrisEffectTime { get => _tetrisEffectTime; }

        private static float _scoreMultiplyer2 = 2.5f;
        private static float _scoreMultiplyer3 = 3.0f;
        private static float _scoreMultiplyer4 = 4.0f;

        private static SoundEffect _playerActionSound = SoundEffect.Collection[SfxFileName.PlayerAction];
        private static SoundEffect _clearOneSound = SoundEffect.Collection[SfxFileName.ClearOne1];
        private static SoundEffect _clearTwoSound = SoundEffect.Collection[SfxFileName.ClearTwo1];
        private static SoundEffect _clearThreeSound = SoundEffect.Collection[SfxFileName.ClearThree1];
        private static SoundEffect _tetrisSound = SoundEffect.Collection[SfxFileName.Tetris1];

        private static int _score = 0;
        public static int Score
        {
            get => _score;
            private set
            {
                _score = value;
            }
        }

        private static float[] _rowCleanUpCounter = new float[NumberOfRow];
        public static float[] RowCleanUpCounter
        {
            get => _rowCleanUpCounter;
        }

        private static float _placingCounter = 0;
        public static float PlacingCounter
        {
            get => _placingCounter;
        }
        private static bool _startPlacingCounter = false;
        public static bool StartPlacingCounter
        {
            get => _startPlacingCounter;
        }

        public static int DropSpeed
        {
            get => _dropSpeed;
            set
            {
                _dropSpeed = value;
                _delayBetweenDrop = 1 / (float)value;
            }
        }
        public static float DelayBetweenDrop
        {
            get => _delayBetweenDrop;
        }
        public static int LineCleared
        {
            get => _lineCleared;
            set
            {
                _lineCleared = value;
                DropSpeed = _lineCleared / 50 + 1;
            }
        }

        static BoardLogic()
        {
            _delayBetweenDrop = 1 / (float)_dropSpeed;

            Blocks = new Block[BoardLogic.NumberOfRow][];
            for (int i = 0; i < BoardLogic.NumberOfRow; i++)
            {
                Blocks[i] = new Block[BoardLogic.NumberOfCol];
                _rowCleanUpCounter[i] = -1;
            }
        }

        public static void Start()
        {
            Music.StartPlayingGameMusic();

            NextBlock = TetrisBlock.CreateTetrisBlock();
            CurrentBlock = null;
            CreateBlock();
            Blocks = new Block[BoardLogic.NumberOfRow][];
            for (int i = 0; i < BoardLogic.NumberOfRow; i++)
            {
                Blocks[i] = new Block[BoardLogic.NumberOfCol];
                _rowCleanUpCounter[i] = -1;
            }

            //for (int i = NumberOfRow - 1; i > NumberOfRow - 5; i--)
            //{
            //    for (int c = 1; c < NumberOfCol; c++)
            //    {
            //        Blocks[i][c] = new Block
            //        {
            //            LocalPosition = new System.Drawing.Point(c, i),
            //            Sprite = Sprite.Collection["Block0"],
            //        };
            //    }
            //}

            DropSpeed = 1;
            Score = 0;
        }

        public static void Update()
        {
            if (Paused)
                return;

            if (_tetrisEffectCounter > 0)
            {
                _tetrisEffectCounter -= Program.DeltaTime;
                return;
            }

            #region clearing rows

            if (_clearingRow)
            {
                for (int row = 0; row < NumberOfRow; row++)
                {
                    if (_rowCleanUpCounter[row] > 0)
                    {
                        _rowCleanUpCounter[row] -= Program.DeltaTime;
                        if (_rowCleanUpCounter[row] <= 0)
                        {
                            ClearRow(row);
                            _clearingRow = false;
                        }
                    }
                }

                if (_clearingRow)
                    return;
                else
                    CreateBlock();
            }

            #endregion
            #region Move down and check place
            _counter += Program.DeltaTime;
            if (_counter > _maxCounter)
                _counter = _maxCounter;

            if (_counter > _delayBetweenDrop)
            {
                _counter -= _delayBetweenDrop;
                if (CurrentBlock != null)
                {
                    CurrentBlock.MoveDown();
                }
            }

            _inputMoveDownCheckCounter += Program.DeltaTime;
            _inputMoveLeftCheckCounter += Program.DeltaTime;
            _inputMoveRightCheckCounter += Program.DeltaTime;

            if (CurrentBlock != null)
            {
                var needToCheckRight = _inputMoveRightCheckCounter >= _delayBetweenEachInputcheck;
                var needToCheckLeft = _inputMoveLeftCheckCounter >= _delayBetweenEachInputcheck;
                var needToCheckDown = _inputMoveDownCheckCounter >= MathF.Min(_delayBetweenEachInputcheck, _delayBetweenDrop);
                bool executeAction = false;

                if (InputSystem.MoveLeftInput.IsKeyPressed ^ InputSystem.MoveRightInput.IsKeyPressed)
                {
                    if (InputSystem.MoveLeftInput.IsKeyDown || (needToCheckLeft && InputSystem.MoveLeftInput.IsKeyPressed))
                    {

                        if (CurrentBlock.MoveLeft())
                            executeAction = true;
                        _inputMoveLeftCheckCounter = 0;
                    }
                    else if (InputSystem.MoveRightInput.IsKeyDown || (needToCheckRight && InputSystem.MoveRightInput.IsKeyPressed))
                    {
                        if (CurrentBlock.MoveRight())
                            executeAction = true;
                        _inputMoveRightCheckCounter = 0;
                    }
                }

                if (InputSystem.MoveDownInput.IsKeyDown || (needToCheckDown && InputSystem.MoveDownInput.IsKeyPressed))
                {
                    if (CurrentBlock.MoveDown())
                        executeAction = true;
                    _counter = 0;
                    _inputMoveDownCheckCounter = 0;
                }

                if (InputSystem.RotateInput.IsKeyDown)
                {
                    if (CurrentBlock.Rotate())
                        executeAction = true;
                }

                if (InputSystem.ForcePlaceInput.IsKeyDown)
                {
                    CurrentBlock.ForcePlace();
                    executeAction = true;
                    CurrentBlock = null;
                    if (!_clearingRow)
                        CreateBlock();
                }

                if (executeAction)
                {
                    _playerActionSound.Play();
                }

            }
            #endregion
            #region Counter to place
            if (CurrentBlock!= null && !CurrentBlock.CheckMoveDown())
            {
                if (_startPlacingCounter)
                {
                    _placingCounter += Program.DeltaTime;
                    if (_placingCounter >= _delayBetweenDrop)
                    {
                        PlaceBlock();
                        if (!_clearingRow)
                            CreateBlock();
                    }
                }
                else
                {
                    _startPlacingCounter = true;
                    _placingCounter = 0;
                }
            }
            else
            {
                _startPlacingCounter = false;
            }
            #endregion
        }

        private static void PlaceBlock()
        {
            _startPlacingCounter = false;
            CurrentBlock.Dispose();
            CurrentBlock = null;
        }

        private static void ClearRow(int row)
        {
            for (int clearingRow = row; clearingRow > 0; clearingRow--)
            {
                Blocks[clearingRow] = Blocks[clearingRow - 1];
            }
            Blocks[0] = new Block[NumberOfCol];
            LineCleared++;
        }

        private static void CreateBlock()
        {
            _counter = 0;

            bool foundBlock = false;
            int row;

            CurrentBlock = NextBlock;
            for (row = CurrentBlock.Matrix.Length - 1; row >= 0; row--)
            {
                for (int col = 0; col < CurrentBlock.Matrix[row].Length; col++)
                {
                    if (CurrentBlock.Matrix[row][col] != null)
                    {
                        foundBlock = true;
                        break;
                    }
                }

                if (foundBlock)
                    break;
            }
            CurrentBlock.Position = new System.Drawing.Point((NumberOfCol - CurrentBlock.Matrix[0].Length) / 2, -row - 1);
            NextBlock = TetrisBlock.CreateTetrisBlock();
        }

        // Bottom up
        public static void CheckClear(int startRow, int numberOfRowCheck)
        {
            bool clear;
            int numberOfRowCleared = 0;
            for (int row = startRow; row > startRow - numberOfRowCheck && row > 0; row--)
            {
                clear = true;
                foreach (var block in Blocks[row])
                {
                    if (block == null)
                    {
                        clear = false;
                        break;
                    }
                }

                if (clear)
                {
                    _rowCleanUpCounter[row] = TimeBeforeClear;
                    _clearingRow = true;
                    numberOfRowCleared++;
                    //for (int clearingRow = row; clearingRow > 0; clearingRow--)
                    //{
                    //    Blocks[clearingRow] = Blocks[clearingRow - 1];
                    //}
                    //Blocks[0] = new Block[NumberOfCol];
                    //row++;
                    //LineCleared++;
                }
            }

            if (numberOfRowCleared > 0)
            {
                int score = BaseScore;
                if (numberOfRowCleared == 1)
                {
                    _clearOneSound.Play();
                }
                else if (numberOfRowCleared == 2)
                {
                    score = (int)(score * _scoreMultiplyer2);
                    _clearTwoSound.Play();
                }
                else if (numberOfRowCleared == 3)
                {
                    score = (int)(score * _scoreMultiplyer2 * _scoreMultiplyer3);
                    _clearThreeSound.Play();
                }
                else if (numberOfRowCleared == 4)
                {
                    score = (int)(score * _scoreMultiplyer2 * _scoreMultiplyer3 * _scoreMultiplyer4);
                    _tetrisSound.Play();
                    _tetrisEffectCounter = _tetrisEffectTime;
                }

                score *= _dropSpeed;
                Score += score;
            }
        }
    }
}
