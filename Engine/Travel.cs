using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    class Travel
    {
        public void Init(Map map, Variables variables, ContentManager content)
        {
            variables.blocks.Clear();
            map.LoadMap(variables.blocks, "mapa", content, variables);
        }
        public void Update(Variables variables, GraphicsDevice graphicsDevice)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (variables.playerRectangle.X <= (graphicsDevice.Viewport.Width / 100) * 2)
                {
                    variables.moveScreenX += variables.moveScreenSpeed;
                }
                else
                {
                    variables.playerRectangle.X -= variables.movePlayerSpeed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (variables.playerRectangle.X >= (graphicsDevice.Viewport.Width / 100) * 98)
                {
                    variables.moveScreenX -= variables.moveScreenSpeed;
                }
                else
                {
                    variables.playerRectangle.X += variables.movePlayerSpeed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (variables.playerRectangle.Y <= (graphicsDevice.Viewport.Height / 100) * 2)
                {
                    variables.moveScreenY += variables.moveScreenSpeed;
                }
                else
                {
                    variables.playerRectangle.Y -= variables.movePlayerSpeed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (variables.playerRectangle.Y >= (graphicsDevice.Viewport.Height / 100) * 99)
                {
                    variables.moveScreenY -= variables.moveScreenSpeed;
                }
                else
                {
                    variables.playerRectangle.Y += variables.movePlayerSpeed;
                }
            }
            if (variables.isCollisionEnabled) { CheckForCollisions(variables); }
        }
        public void Draw(SpriteBatch spriteBatch, ContentManager content, Variables variables)
        {
            spriteBatch.Draw(content.Load<Texture2D>("Textures/2"), variables.playerRectangle, Color.White);
        }
        void CheckForCollisions(Variables variables)
        {
            foreach (Block block in variables.blocks)
            {
                if (block.collision)
                {
                    Rectangle working = new Rectangle(block.position.X + variables.moveScreenX, block.position.Y + variables.moveScreenY, variables.blockWidth, variables.blockHeight);
                    Rectangle collisionRectangle = Rectangle.Intersect(working, variables.playerRectangle);
                    if (collisionRectangle.Height < collisionRectangle.Width)
                    {
                        if (variables.playerRectangle.Center.Y > working.Center.Y)
                        {
                            variables.playerRectangle.Y += collisionRectangle.Height;
                        }
                        else
                        {
                            variables.playerRectangle.Y -= collisionRectangle.Height;
                        }
                    }
                    else if (collisionRectangle.Width < collisionRectangle.Height)
                    {
                        if (variables.playerRectangle.Center.X > working.Center.X)
                        {
                            variables.playerRectangle.X += collisionRectangle.Width;
                        }
                        else
                        {
                            variables.playerRectangle.X -= collisionRectangle.Width;
                        }
                    }
                }
            }
        }
    }
}
