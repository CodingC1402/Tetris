using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Tetris.Board;

namespace Tetris.Graphics
{
    public class Sprite
    {
        public static readonly Dictionary<string, Sprite> Collection = new Dictionary<string, Sprite>();
        public static readonly string BoardSpriteKey = "Board";
        public static readonly string ScoreboardSpriteKey = "ScoreBoard";

        public readonly string ID = "";
        public readonly Texture Texture = null;
        public readonly Rectangle SrcRect;

        static Sprite()
        {
            Rectangle srcRect = new Rectangle(0, 0, Block.BlockPixelSize, Block.BlockPixelSize);

            Sprite newSprite = new Sprite("Block0", Texture.Collection[Texture.BlockTextureKey], srcRect);
            Collection.Add(newSprite.ID, newSprite);
            srcRect.X += Block.BlockPixelSize;

            newSprite = new Sprite("Block1", Texture.Collection[Texture.BlockTextureKey], srcRect);
            Collection.Add(newSprite.ID, newSprite);
            srcRect.X += Block.BlockPixelSize;

            newSprite = new Sprite("Block2", Texture.Collection[Texture.BlockTextureKey], srcRect);
            Collection.Add(newSprite.ID, newSprite);
            srcRect.X += Block.BlockPixelSize;

            newSprite = new Sprite("Block3", Texture.Collection[Texture.BlockTextureKey], srcRect);
            Collection.Add(newSprite.ID, newSprite);
            srcRect.X += Block.BlockPixelSize;

            newSprite = new Sprite("Block4", Texture.Collection[Texture.BlockTextureKey], srcRect);
            Collection.Add(newSprite.ID, newSprite);
            srcRect.X += Block.BlockPixelSize;

            newSprite = new Sprite("Block5", Texture.Collection[Texture.BlockTextureKey], srcRect);
            Collection.Add(newSprite.ID, newSprite);
            srcRect.X += Block.BlockPixelSize;

            newSprite = new Sprite("Block6", Texture.Collection[Texture.BlockTextureKey], srcRect);
            Collection.Add(newSprite.ID, newSprite);
            srcRect.X += Block.BlockPixelSize;

            newSprite = new Sprite("Block7", Texture.Collection[Texture.BlockTextureKey], srcRect);
            Collection.Add(newSprite.ID, newSprite);
            srcRect.X += Block.BlockPixelSize;

            newSprite = new Sprite("Board", Texture.Collection[Texture.BoardTextureKey]);
            Collection.Add(newSprite.ID, newSprite);

            newSprite = new Sprite("ScoreBoard", Texture.Collection[Texture.ScoreBoardTextureKey]);
            Collection.Add(newSprite.ID, newSprite);
        }

        private Sprite(string id, Texture texture, Rectangle srcRect)
        {
            ID = id;
            Texture = texture;
            SrcRect = srcRect;
        }

        public Sprite(string id, Texture texture)
        {
            ID = id;
            Texture = texture;
            SrcRect = new Rectangle(0, 0, texture.Bmp.Width, texture.Bmp.Height);
        }
    }
}
