using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Engine
{
    class Travel
    {
        public void Init(Map map, Variables variables, ContentManager content)
        {
            variables.blocks.Clear();
            if (File.Exists("mapa.map"))
            {
                map.LoadMap(variables.blocks, "mapa", content, variables);
            }
        }
        public void Update(Variables variables, GraphicsDevice graphicsDevice)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (variables.playerSpriteRectangle.X <= (graphicsDevice.Viewport.Width / 100) * 2)
                {
                    variables.moveScreenX += variables.moveScreenSpeed;
                }
                else
                {
                    variables.playerSpriteRectangle.X -= variables.movePlayerSpeed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (variables.playerSpriteRectangle.X >= (graphicsDevice.Viewport.Width / 100) * 98)
                {
                    variables.moveScreenX -= variables.moveScreenSpeed;
                }
                else
                {
                    variables.playerSpriteRectangle.X += variables.movePlayerSpeed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (variables.playerSpriteRectangle.Y <= (graphicsDevice.Viewport.Height / 100) * 2)
                {
                    variables.moveScreenY += variables.moveScreenSpeed;
                }
                else
                {
                    variables.playerSpriteRectangle.Y -= variables.movePlayerSpeed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (variables.playerSpriteRectangle.Y >= (graphicsDevice.Viewport.Height / 100) * 99)
                {
                    variables.moveScreenY -= variables.moveScreenSpeed;
                }
                else
                {
                    variables.playerSpriteRectangle.Y += variables.movePlayerSpeed;
                }
            }
            if (variables.isCollisionEnabled) { CheckForCollisions(variables); }
        }
        public void Draw(SpriteBatch spriteBatch, ContentManager content, Variables variables)
        {
            spriteBatch.Draw(content.Load<Texture2D>("Textures/2"), variables.playerSpriteRectangle, Color.White);
        }
        void CheckForCollisions(Variables variables)
        {
            Rectangle playerRectangle;
            Rectangle working;
            Rectangle collisionRectangle;
            foreach (Block block in variables.blocks)
            {
                if (block.collision)
                {
                    working = new Rectangle(block.spriteRectangle.X + block.hitboxRectangle.X + variables.moveScreenX, block.spriteRectangle.Y + block.hitboxRectangle.Y + variables.moveScreenY, block.hitboxRectangle.Width, block.hitboxRectangle.Height);
                    playerRectangle = new Rectangle(variables.playerSpriteRectangle.X + variables.playerHitboxRectangle.X,variables.playerSpriteRectangle.Y + variables.playerHitboxRectangle.Y,variables.playerHitboxRectangle.Width,variables.playerHitboxRectangle.Height);
                    collisionRectangle = Rectangle.Intersect(working, playerRectangle);
                    if (collisionRectangle.Height < collisionRectangle.Width)
                    {
                        if (playerRectangle.Center.Y > working.Center.Y)
                        {
                            variables.playerSpriteRectangle.Y += collisionRectangle.Height;
                        }
                        else
                        {
                            variables.playerSpriteRectangle.Y -= collisionRectangle.Height;
                        }
                    }
                    else if (collisionRectangle.Width < collisionRectangle.Height)
                    {
                        if (playerRectangle.Center.X > working.Center.X)
                        {
                            variables.playerSpriteRectangle.X += collisionRectangle.Width;
                        }
                        else
                        {
                            variables.playerSpriteRectangle.X -= collisionRectangle.Width;
                        }
                    }
                }
            }
        }
    }
}
