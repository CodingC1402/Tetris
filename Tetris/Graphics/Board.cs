using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

        public Bitmap[] BackgroundsCollection = new Bitmap[]
        {
            Images.BackGround,
            Images.BackGround2
        };
        public int BackgroundIndex = 0;
        public Bitmap BackgroundBitmap = null;
        public Bitmap OldBackgroundBitmap = null;

        public int BackgroundChangingInterval = 30000;
        public float FadeTime = 1f;
        private float _fadeCounter = 0;

        public Point StartPos = new Point(10, 10);

        private float _boardOpacity = 1f;
        public float BoardOpacity
        {
            get => _boardOpacity;
            set
            {
                _boardOpacity = Math.Clamp(value, 0, 1);
            }
        }

        private const int _scoreBoardNextBlockPadding = 30;
        private const int _scoreBoardScorePadding = 15;
        private const int _maxScoreLength = 7;

        private Rectangle _innerBound = new Rectangle();
        private Sprite _boardSprite = Sprite.Collection[Sprite.BoardSpriteKey];
        private Sprite _scoreBoardSprite = Sprite.Collection[Sprite.ScoreboardSpriteKey];

        private Size _boardSize = new Size();
        private int _scoreBoardPadding = 10;
        private Rectangle _scoreBoardRect = new Rectangle(0, 0, 250, 250);

        private float _flashBeforeEnd = 1.5f;
        private float _maxOpacityWhenFlash = 0.8f;

        private float _disappearOffset = 0.035f;
        private Bitmap _pausedOverlayBitmap;

        private Timer _backgroundTimer = new Timer();

        private float _tetrisEffectOffset = 0.05f;

        private float _shadowOpacity = 0.45f;
        private float _shadowScale = 0.9f;

        private int _pausedBoardHeight = 400;
        private Color _pausedBoardColor = Color.FromArgb(255, 38, 45, 45);

        private int _countingImageSize = 150;
        private Bitmap[] _countingImages = {
            Images.counter1,        
            Images.counter2,        
            Images.counter3,        
        };

        public Board()
        {
            InitializeComponent();
            Instance = this;

            ChangeBackground();
            _backgroundTimer.Interval = BackgroundChangingInterval;
            _backgroundTimer.Tick += (s, e) => ChangeBackground();
            _backgroundTimer.Start();

            _boardSize = new Size(
                StartPos.X * 2 + BoardLogic.NumberOfCol * Block.BlockPixelSize + BlockPadding * (BoardLogic.NumberOfCol + 1),
                StartPos.Y * 2 + BoardLogic.NumberOfRow * Block.BlockPixelSize + BlockPadding * (BoardLogic.NumberOfRow + 1)
                );

            _scoreBoardRect.X = _boardSize.Width + _scoreBoardPadding;

            CreateBitmap(
                _boardSize.Width + _scoreBoardRect.Width + _scoreBoardPadding, 
                _boardSize.Height
                );
        }

        protected void ChangeBackground()
        {
            if (BackgroundsCollection.Length == 0)
            {
                OldBackgroundBitmap = null;
                BackgroundBitmap = null;
                BackgroundIndex = 0;
                return;
            }

            OldBackgroundBitmap = BackgroundBitmap;
            _fadeCounter = FadeTime;

            BackgroundBitmap = BackgroundsCollection[BackgroundIndex];
            BackgroundIndex = (BackgroundIndex + 1) % BackgroundsCollection.Length;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            #region Draw background
            pe.Graphics.Clear(BackColor);
            pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            pe.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            if (BackgroundBitmap != null)
            {
                if (_fadeCounter > -FadeTime)
                {
                    _fadeCounter -= Program.DeltaTimeBetweenRender;

                    ColorMatrix colorMatrix = new ColorMatrix();

                    var opacity = MathF.Abs(_fadeCounter) / FadeTime;
                    colorMatrix.Matrix33 = opacity;

                    ImageAttributes attributes = new ImageAttributes();
                    attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    if (_fadeCounter > 0)
                    {
                        if (OldBackgroundBitmap == null)
                            _fadeCounter = 0;
                        else
                        {
                            var drawPos = new Point(
                        (Width - OldBackgroundBitmap.Width) / 2,
                        (Height - OldBackgroundBitmap.Height) / 2
                        );

                            pe.Graphics.DrawImage(
                                OldBackgroundBitmap,
                                new Rectangle(drawPos.X,
                                                drawPos.Y,
                                                OldBackgroundBitmap.Width,
                                                OldBackgroundBitmap.Height),
                                0,
                                0,
                                OldBackgroundBitmap.Width,
                                OldBackgroundBitmap.Height,
                                GraphicsUnit.Pixel,
                                attributes);
                        }
                    }
                    else
                    {
                        var drawPos = new Point(
                        (Width - BackgroundBitmap.Width) / 2,
                        (Height - BackgroundBitmap.Height) / 2
                        );

                        pe.Graphics.DrawImage(
                            BackgroundBitmap,
                            new Rectangle(drawPos.X,
                                            drawPos.Y,
                                            BackgroundBitmap.Width,
                                            BackgroundBitmap.Height),
                            0,
                            0,
                            BackgroundBitmap.Width,
                            BackgroundBitmap.Height,
                            GraphicsUnit.Pixel,
                            attributes);
                    }
                }
                else
                {
                    var drawPos = new Point(
                    (Width - BackgroundBitmap.Width) / 2,
                    (Height - BackgroundBitmap.Height) / 2
                    );

                    pe.Graphics.DrawImage(BackgroundBitmap, drawPos.X, drawPos.Y, BackgroundBitmap.Width, BackgroundBitmap.Height);
                }
            }
            #endregion
            #region Render the scoreBoard
            var scoreBoardItem = new RenderImageItem
            {
                image = _scoreBoardSprite.Texture.Bmp,
                desRectangle = new Rectangle(_scoreBoardRect.X, 0, _scoreBoardRect.Width, _scoreBoardRect.Height),
                srcRectangle = _scoreBoardSprite.SrcRect,
                colorMatrix = new ColorMatrix()
            };
            scoreBoardItem.colorMatrix.Matrix33 = _boardOpacity;
            NeedToRender.Add(scoreBoardItem);

            var scoreStr = BoardLogic.Score.ToString().PadLeft(_maxScoreLength, '0').Substring(0, _maxScoreLength);
            var strSize = pe.Graphics.MeasureString(scoreStr, Font);
            var strPoint = new PointF(_scoreBoardRect.X + (_scoreBoardRect.Width - strSize.Width) / 2, _scoreBoardScorePadding);

            // Shadow
            NeedToRender.Add(new RenderTextItem
            {
                desRect = new RectangleF(strPoint.X, strPoint.Y + 4, strSize.Width, strSize.Height),
                text = scoreStr,
                font = Font,
                textBrush = new SolidBrush(Color.FromArgb(127, 0, 0, 0))
            });

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
                var startY = _scoreBoardNextBlockPadding + (_scoreBoardRect.Height - matrixSize) / 2;
                var startX = _boardSize.Width + (_scoreBoardRect.Width - matrixSize) / 2;

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
            RenderImageItem boardItem = new RenderImageItem()
            {
                srcRectangle = _boardSprite.SrcRect,
                image = _boardSprite.Texture.Bmp,
                desRectangle = new Rectangle(0, 0, _boardSize.Width, BufferBitmap.Height),
                colorMatrix = new ColorMatrix()
            };
            boardItem.colorMatrix.Matrix33 = _boardOpacity;

            NeedToRender.Add(boardItem);

            if (!BoardLogic.Paused)
            {
                if (BoardLogic.TetrisEffectCounter > 0)
                    DrawBoardTetrisEffect();
                else
                    DrawBoardWthoutTetrisEffect();

                DrawCurrentBlock();
            }
            #endregion

            base.OnPaint(pe);
        }

        protected override void OnBeforePaintCall(PaintEventArgs pe)
        {
            base.OnBeforePaintCall(pe);

            if (BoardLogic.Paused || BoardLogic.CountingCounter > 0)
            {
                pe.Graphics.DrawImage(_pausedOverlayBitmap, 0, 0, Width, Height);
                if (BoardLogic.CountingCounter > 0)
                {
                    var countingNumber = BoardLogic.CountingCounter / (BoardLogic.CountingTime / 3);
                    var drawX = (Width - _countingImageSize) / 2;
                    var drawY = (Height - _countingImageSize) / 2;

                    pe.Graphics.DrawImage(_countingImages[(int)Math.Clamp(countingNumber, 0, _countingImages.Length - 1)], drawX, drawY, _countingImageSize, _countingImageSize);
                }

                if (BoardLogic.Paused)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = Width;
                    rectangle.Height = _pausedBoardHeight;
                    rectangle.Y = (Height - rectangle.Height) / 2;

                    using (Brush brush = new SolidBrush(_pausedBoardColor))
                    {
                        pe.Graphics.FillRectangle(brush, rectangle);
                    }
                }
            }
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

        protected void DrawCurrentBlock()
        {
            var currentBlock = BoardLogic.CurrentBlock;
            if (currentBlock != null)
            {
                bool needToDrawShadow = !currentBlock.Position.Equals(currentBlock.ShadowPosition);
                foreach (var row in currentBlock.Matrix)
                {
                    foreach (var block in row)
                    {
                        if (block != null)
                        {
                            // Drawing shadows
                            Point shadowPoint = block.GetShadowPosition();
                            if (needToDrawShadow && shadowPoint.Y >= 0)
                            {
                                var offSet = (int)(Block.BlockPixelSize * (1 - _shadowScale) / 2);
                                RenderImageItem newRenderItem = new RenderImageItem
                                {
                                    srcRectangle = block.Sprite.SrcRect,
                                    image = block.Sprite.Texture.Bmp,
                                    desRectangle = new Rectangle(
                                        StartPos.X + shadowPoint.X * Block.BlockPixelSize + (shadowPoint.X + 1) * BlockPadding + offSet,
                                        StartPos.Y + shadowPoint.Y * Block.BlockPixelSize + (shadowPoint.Y + 1) * BlockPadding + offSet,
                                        (int)(Block.BlockPixelSize * _shadowScale),
                                        (int)(Block.BlockPixelSize * _shadowScale)
                                    ),
                                    colorMatrix = new ColorMatrix()
                                };
                                newRenderItem.colorMatrix.Matrix33 = _shadowOpacity;

                                NeedToRender.Add(newRenderItem);
                            }

                            // Drawing the block
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
        }

        protected void DrawBoardWthoutTetrisEffect()
        {
            Rectangle desRect = new Rectangle(StartPos.X + BlockPadding, StartPos.Y + BlockPadding, Block.BlockPixelSize, Block.BlockPixelSize);
            for (int row = 0; row < BoardLogic.Blocks.Length; row++)
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
        }

        protected void DrawBoardTetrisEffect()
        {
            Rectangle desRect = new Rectangle(StartPos.X + BlockPadding, StartPos.Y + BlockPadding, Block.BlockPixelSize, Block.BlockPixelSize);
            for (int row = 0; row < BoardLogic.Blocks.Length; row++)
            {
                var colOffSet = (row) * _tetrisEffectOffset;
                for (int col = 0; col < BoardLogic.NumberOfCol; col++)
                {
                    var block = BoardLogic.Blocks[row][col];
                    if (block != null)
                    {
                        var newItem = new RenderImageItem
                        {
                            srcRectangle = block.Sprite.SrcRect,
                            image = block.Sprite.Texture.Bmp,
                            desRectangle = desRect,
                            colorMatrix = new ColorMatrix()
                        };

                        // Converting linear timeline to segmented in/out timeline for tetris
                        var opacity = MathF.Max(0, (BoardLogic.TetrisEffectCounter - colOffSet)) / (BoardLogic.TetrisEffectTime - colOffSet);
                        if (opacity < 0.5)
                        {
                            opacity = 1 - opacity;
                        }
                        opacity = (opacity - 0.5f) * 2;
                        //newItem.colorMatrix.Matrix33 = opacity;
                        newItem.colorMatrix.Matrix00 = 1 / opacity;
                        newItem.colorMatrix.Matrix11 = 1 / opacity;
                        newItem.colorMatrix.Matrix22 = 1 / opacity;

                        NeedToRender.Add(newItem);
                    }
                    desRect.X += BlockPadding + Block.BlockPixelSize;
                }

                desRect.X = StartPos.X + BlockPadding;
                desRect.Y += BlockPadding + Block.BlockPixelSize;
            } 
        }
    }
}
