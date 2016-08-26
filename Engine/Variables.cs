using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Engine
{
    public class Variables
    {
        [XmlIgnore]
        public List<Block> blocks;
        [XmlIgnore]
        public string configFile;

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
            configFile = "config.xml";
            blocks = new List<Block>();
        }
    }
}
