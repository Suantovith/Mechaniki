using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    class Editor
    {
        public void Update(KeyState keyState, Variables variables, ContentManager content, Map map, GraphicsDevice graphicsDevice)
        {
            if (keyState.IsKeyReleased(Keys.Enter))
            {
                variables.blocks.Add(new Block { position = new Rectangle(variables.editorCursorRectangle.X - variables.moveScreenX, variables.editorCursorRectangle.Y - variables.moveScreenY, variables.blockWidth, variables.blockHeight), texture = content.Load<Texture2D>("Textures/3"), collision = true });
            }
            if (keyState.IsKeyReleased(Keys.L))
            {
                variables.blocks.Clear();
                map.LoadMap(variables.blocks, "mapa", content, variables);
            }
            if (keyState.IsKeyReleased(Keys.S))
            {
                map.SaveMap(variables.blocks, "mapa");
            }
            if (keyState.IsKeyReleased(Keys.C))
            {
                variables.blocks.Clear();
            }
            if (keyState.IsKeyReleased(Keys.Z))
            {
                if (variables.blocks.Count >= 1)
                {
                    variables.blocks.RemoveAt(variables.blocks.Count - 1);
                }
            }
            if (keyState.IsKeyReleased(Keys.E))
            {
                variables.isCollisionEnabled = !variables.isCollisionEnabled;
            }
            if (keyState.IsKeyPressed(Keys.Left, 800))
            {
                if (variables.editorCursorRectangle.X <= (graphicsDevice.Viewport.Width / 100) * 2)
                {
                    variables.moveScreenX += variables.blockWidth;
                }
                else
                {
                    variables.editorCursorRectangle.X -= variables.blockWidth;
                }
            }
            if (keyState.IsKeyPressed(Keys.Right, 800))
            {
                if (variables.editorCursorRectangle.X >= (graphicsDevice.Viewport.Width / 100) * 98)
                {
                    variables.moveScreenX -= variables.blockWidth;
                }
                else
                {
                    variables.editorCursorRectangle.X += variables.blockWidth;
                }
            }
            if (keyState.IsKeyPressed(Keys.Up, 800))
            {
                if (variables.editorCursorRectangle.Y <= (graphicsDevice.Viewport.Height / 100) * 2)
                {
                    variables.moveScreenY += variables.blockHeight;
                }
                else
                {
                    variables.editorCursorRectangle.Y -= variables.blockHeight;
                }
            }
            if (keyState.IsKeyPressed(Keys.Down, 800))
            {
                if (variables.editorCursorRectangle.Y >= (graphicsDevice.Viewport.Height / 100) * 99)
                {
                    variables.moveScreenY -= variables.blockHeight;
                }
                else
                {
                    variables.editorCursorRectangle.Y += variables.blockHeight;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager content, Variables variables)
        {
            spriteBatch.Draw(content.Load<Texture2D>("Textures/1"), variables.editorCursorRectangle, Color.Red);
        }
    }
}
