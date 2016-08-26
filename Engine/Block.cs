using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Block
    {
        public Texture2D texture { set; get; }
        public bool collision { set; get; }
        public Rectangle spriteRectangle { set; get; }

        public Rectangle hitboxRectangle { set; get; }


    }
}
