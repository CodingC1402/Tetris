using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Tetris.Graphics
{
    public class Texture
    {
        public static readonly Dictionary<string, Texture> Collection = new Dictionary<string, Texture>();
        public static readonly string BlockTextureKey = "BlockTexture";
        public static readonly string BoardTextureKey = "BoardTexture";

        public readonly string ID;
        public readonly Bitmap Bmp;

        static Texture()
        {
            Texture newTexture = new Texture(BlockTextureKey, Tetris.Images.SpriteImage);
            Collection.Add(newTexture.ID, newTexture);

            newTexture = new Texture(BoardTextureKey, Tetris.Images.board);
            Collection.Add(newTexture.ID, newTexture);
        }

        public static Texture GetTexture(string id)
        {
            return Collection[id];
        }

        private Texture(string id, Bitmap bmp)
        {
            ID = id;
            Bmp = bmp;
        }
    }
}
