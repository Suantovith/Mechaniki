using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Engine
{
    public class Variables
    {
        public List<Block> blocks;
        public Rectangle playerRectangle;
        public Rectangle editorCursorRectangle;
        public int blockWidth;
        public int blockHeight;
        public int moveScreenX;
        public int moveScreenY;
        public int moveScreenSpeed;
        public int movePlayerSpeed;
        public bool isCollisionEnabled;
        public int state;

        public Variables()
        {
            moveScreenX = 0;
            moveScreenY = 0;
            blockWidth = 64;
            blockHeight = 64;
            moveScreenSpeed = 2;
            playerRectangle = new Rectangle(0, 0, 64, 64);
            editorCursorRectangle = new Rectangle(0, 0, blockWidth, blockHeight);
            movePlayerSpeed = 2;
            isCollisionEnabled = true;
            state = 0;
            blocks = new List<Block>();
        }
    }
}
