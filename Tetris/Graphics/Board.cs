using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tetris.Board;
using Tetris.Logic;

namespace Tetris.Graphics
{
    public partial class Board : BitmapRenderer
    {
        public static Board Instance = null;

        public const int BlockPadding = 2;
        public Point StartPos = new Point(10, 10);

        private const int _scoreBoardNextBlockPadding = 30;
        private const int _maxScoreLength = 7;

        private Rectangle _innerBound = new Rectangle();
        private Sprite _boardSprite = Sprite.Collection[Sprite.BoardSpriteKey];

        private Size _boardSize = new Size();
        private Size _scoreBoardSize = new Size(250, 250);

        private float _flashBeforeEnd = 1.5f;
        private float _maxOpacityWhenFlash = 0.8f;

        private float _disappearOffset = 0.035f;
        private Bitmap _pausedOverlayBitmap;

        public Board()
        {
            InitializeComponent();
            Instance = this;

            _boardSize = new Size(
                StartPos.X * 2 + BoardLogic.NumberOfCol * Block.BlockPixelSize + BlockPadding * (BoardLogic.NumberOfCol + 1),
                StartPos.Y * 2 + BoardLogic.NumberOfRow * Block.BlockPixelSize + BlockPadding * (BoardLogic.NumberOfRow + 1)
                );

            CreateBitmap(
                _boardSize.Width + _scoreBoardSize.Width, 
                _boardSize.Height
                );
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            #region Render the scoreBoard
            var scoreStr = BoardLogic.Score.ToString().PadLeft(_maxScoreLength, '0').Substring(0, _maxScoreLength);
            var strSize = pe.Graphics.MeasureString(scoreStr, Font);
            var strPoint = new PointF(_boardSize.Width + (_scoreBoardSize.Width - strSize.Width) / 2, StartPos.Y);
            NeedToRender.Add(new RenderTextItem
            {
                desRect = new RectangleF(strPoint.X, strPoint.Y, strSize.Width, strSize.Height),
                text = scoreStr,
                font = Font,
                textBrush = new SolidBrush(Color.White)
            });

            var nextBlock = BoardLogic.NextBlock;

            if (nextBlock != null)
            {
                var matrixSize = nextBlock.Matrix.Length * Block.BlockPixelSize + (nextBlock.Matrix.Length - 1) * BlockPadding;
                var startY = _scoreBoardSize.Height - _scoreBoardNextBlockPadding - matrixSize;
                var startX = _boardSize.Width + (_scoreBoardSize.Width - matrixSize) / 2;

                foreach (var row in nextBlock.Matrix)
                {
                    foreach (var block in row)
                    {
                        if (block != null)
                        {
                            Point worldPoint = block.LocalPosition;
                            if (worldPoint.Y >= 0)
                            {
                                RenderImageItem newRenderItem = new RenderImageItem
                                {
                                    srcRectangle = block.Sprite.SrcRect,
                                    image = block.Sprite.Texture.Bmp,
                                    desRectangle = new Rectangle(
                                        startX + worldPoint.X * Block.BlockPixelSize + (worldPoint.X + 1) * BlockPadding,
                                        startY + worldPoint.Y * Block.BlockPixelSize + (worldPoint.Y + 1) * BlockPadding,
                                        Block.BlockPixelSize,
                                        Block.BlockPixelSize
                                    ),
                                };
                                NeedToRender.Add(newRenderItem);
                            }
                        }
                    }
                }
            }
            #endregion
            #region Render the board
            NeedToRender.Add(new RenderImageItem()
            {
                srcRectangle = _boardSprite.SrcRect,
                image = _boardSprite.Texture.Bmp,
                desRectangle = new Rectangle(0, 0, _boardSize.Width, BufferBitmap.Height)
            });
            Rectangle desRect = new Rectangle(StartPos.X + BlockPadding, StartPos.Y + BlockPadding, Block.BlockPixelSize, Block.BlockPixelSize);

            for(int row = 0; row < BoardLogic.Blocks.Length; row++)
            {
                if (BoardLogic.RowCleanUpCounter[row] > 0)
                {
                    for (int col = 0; col < BoardLogic.NumberOfCol; col++)
                    {
                        var block = BoardLogic.Blocks[row][col];
                        if (block != null)
                        {
                            RenderImageItem newRender = new RenderImageItem
                            {
                                srcRectangle = block.Sprite.SrcRect,
                                image = block.Sprite.Texture.Bmp,
                                desRectangle = desRect
                            };
                            var colOffSet = (BoardLogic.NumberOfCol - col - 1) * _disappearOffset;
                            newRender.colorMatrix = new System.Drawing.Imaging.ColorMatrix();

                            var opacity = (BoardLogic.RowCleanUpCounter[row] - colOffSet) / (BoardLogic.TimeBeforeClear - colOffSet);
                            if (opacity < 0)
                                opacity = 0;
                            newRender.colorMatrix.Matrix33 = opacity;
                            newRender.colorMatrix.Matrix00 = 1 / opacity;
                            newRender.colorMatrix.Matrix11 = 1 / opacity;
                            newRender.colorMatrix.Matrix22 = 1 / opacity;

                            newRender.desRectangle.X += (int)(newRender.desRectangle.Width * (1 - opacity) / 2.0f);
                            newRender.desRectangle.Y += (int)(newRender.desRectangle.Height * (1 - opacity) / 2.0f);

                            newRender.desRectangle.Width = (int)(newRender.desRectangle.Width * opacity);
                            newRender.desRectangle.Height = (int)(newRender.desRectangle.Height * opacity);

                            NeedToRender.Add(newRender);
                        }
                        desRect.X += BlockPadding + Block.BlockPixelSize;
                    }
                }
                else
                {
                    foreach (var block in BoardLogic.Blocks[row])
                    {
                        if (block != null)
                        {
                            NeedToRender.Add(new RenderImageItem()
                            {
                                srcRectangle = block.Sprite.SrcRect,
                                image = block.Sprite.Texture.Bmp,
                                desRectangle = desRect
                            });
                        }
                        desRect.X += BlockPadding + Block.BlockPixelSize;
                    }
                }

                desRect.X = StartPos.X + BlockPadding;
                desRect.Y += BlockPadding + Block.BlockPixelSize;
            }

            var currentBlock = BoardLogic.CurrentBlock;
            if (currentBlock != null)
            {
                foreach (var row in currentBlock.Matrix)
                {
                    foreach (var block in row)
                    {
                        if (block != null)
                        {
                            Point worldPoint = block.GetWorldPoint();
                            if (worldPoint.Y >= 0)
                            {
                                RenderImageItem newRenderItem = new RenderImageItem
                                {
                                    srcRectangle = block.Sprite.SrcRect,
                                    image = block.Sprite.Texture.Bmp,
                                    desRectangle = new Rectangle(
                                        StartPos.X + worldPoint.X * Block.BlockPixelSize + (worldPoint.X + 1) * BlockPadding,
                                        StartPos.Y + worldPoint.Y * Block.BlockPixelSize + (worldPoint.Y + 1) * BlockPadding,
                                        Block.BlockPixelSize,
                                        Block.BlockPixelSize
                                    ),
                                };
                                if (BoardLogic.StartPlacingCounter)
                                {
                                    newRenderItem.colorMatrix = new System.Drawing.Imaging.ColorMatrix();

                                    float divisionTime = BoardLogic.DelayBetweenDrop / _flashBeforeEnd;
                                    float opacityFactor = (BoardLogic.PlacingCounter % divisionTime) / divisionTime;

                                    if (opacityFactor > 0.5)
                                    {
                                        opacityFactor = 1 - opacityFactor;
                                    }

                                    float opacity = opacityFactor * 2 * _maxOpacityWhenFlash;
                                    newRenderItem.colorMatrix.Matrix33 = opacity;
                                }

                                NeedToRender.Add(newRenderItem);
                            }
                        }
                    }
                }
            }
            #endregion

            if (BoardLogic.Paused)
                NeedToRender.Add(new RenderImageItem
                {
                    image = _pausedOverlayBitmap,
                    srcRectangle = new Rectangle(0, 0, _pausedOverlayBitmap.Width, _pausedOverlayBitmap.Height),
                    desRectangle = new Rectangle(0, 0, _pausedOverlayBitmap.Width, _pausedOverlayBitmap.Height)
                });
            base.OnPaint(pe);
        }

        protected override void SetBoundsForBitmap()
        {
            base.SetBoundsForBitmap();
            _innerBound.X = _offSetX + StartPos.X / 2;
            _innerBound.Y = _offSetY + StartPos.Y / 2;
            _innerBound.Width = _trueWidth - StartPos.X;
            _innerBound.Height = _trueHeight - StartPos.Y;
        }

        public override void CreateBitmap(int width, int height)
        {
            base.CreateBitmap(width, height);
            _pausedOverlayBitmap = new Bitmap(width, height);
            using (System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(_pausedOverlayBitmap))
            {
                gfx.Clear(Color.FromArgb(127, 0, 0, 0));
            }
        }
    }
}
