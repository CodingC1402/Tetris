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

        private Rectangle _innerBound = new Rectangle();
        private Sprite _boardSprite = Sprite.Collection[Sprite.BoardSpriteKey];

        private float _flashBeforeEnd = 1.5f;
        private float _maxOpacityWhenFlash = 0.8f;

        private float _disappearOffset = 0.035f;

        public Board()
        {
            InitializeComponent();
            Instance = this;

            CreateBitmap(StartPos.X * 2 + BoardLogic.NumberOfCol * Block.BlockPixelSize + BlockPadding * (BoardLogic.NumberOfCol + 1), StartPos.Y * 2 + BoardLogic.NumberOfRow * Block.BlockPixelSize + BlockPadding * (BoardLogic.NumberOfRow + 1));
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            NeedToRender.Add(new RenderItem()
            {
                srcRectangle = _boardSprite.SrcRect,
                image = _boardSprite.Texture.Bmp,
                desRectangle = new Rectangle(0, 0, BufferBitmap.Width, BufferBitmap.Height)
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
                            RenderItem newRender = new RenderItem
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
                            NeedToRender.Add(new RenderItem()
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
                                RenderItem newRenderItem = new RenderItem
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
    }
}
