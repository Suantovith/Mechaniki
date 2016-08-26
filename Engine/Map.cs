using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Engine
{
    public class Map
    {
        public void LoadMap(List<Block> elements, string file, ContentManager content, Variables variables)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file + ".map"))
                {
                    string line = sr.ReadToEnd();
                    string[] lines = line.Split(' ');
                    for (int i = 0; i < lines.Length; i += 8)
                    {
                        elements.Add(new Block { spriteRectangle = new Rectangle(Convert.ToInt32(lines[i]), Convert.ToInt32(lines[i + 1]), variables.blockWidth, variables.blockHeight), hitboxRectangle = new Rectangle(Convert.ToInt32(lines[i + 2]), Convert.ToInt32(lines[i + 3]), Convert.ToInt32(lines[i + 4]), Convert.ToInt32(lines[i + 5])), texture = content.Load<Texture2D>(lines[i + 6]), collision = Convert.ToBoolean(lines[i + 7]) });
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not read the file: " + ex.Message);
            }
        }
        public void SaveMap(List<Block> elements, string file)
        {
            using (System.IO.StreamWriter path = new System.IO.StreamWriter(file + ".map"))
            {
                foreach (Block block in elements)
                {
                    path.Write(block.spriteRectangle.X.ToString() + " " + block.spriteRectangle.Y.ToString() + " " + block.hitboxRectangle.X + " " + block.hitboxRectangle.Y + " " + block.hitboxRectangle.Width + " " + block.hitboxRectangle.Height + " " + block.texture.ToString() + " " + block.collision.ToString() + " ");

                }
            }
        }
    }
}
