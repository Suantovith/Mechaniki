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
                    for (int i = 0; i < lines.Length; i += 4)
                    {
                        elements.Add(new Block { position = new Rectangle(Convert.ToInt32(lines[i]), Convert.ToInt32(lines[i + 1]), variables.blockWidth, variables.blockHeight), texture = content.Load<Texture2D>(lines[i + 2]), collision = Convert.ToBoolean(lines[i + 3]) });
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
                    path.Write(block.position.X.ToString() + " " + block.position.Y.ToString() + " " + block.texture.ToString() + " " + block.collision.ToString() + " ");

                }
            }
        }
    }
}
