using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Variables variables;
        Map map;
        KeyState keyState;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            variables = new Variables();
            map = new Map();
            keyState = new KeyState();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (keyState.IsKeyReleased(Keys.Enter))
            {
                variables.blocks.Add(new Block { position = new Rectangle(variables.editorCursorRectangle.X - variables.moveScreenX, variables.editorCursorRectangle.Y - variables.moveScreenY, variables.blockWidth, variables.blockHeight), texture = Content.Load<Texture2D>("Textures/3"), collision = true });
            }
            if (keyState.IsKeyReleased(Keys.L))
            {
                variables.blocks.Clear();
                map.LoadMap(variables.blocks, "mapa", this.Content, variables);
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
            /*if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (variables.playerRectangle.X <= (this.GraphicsDevice.Viewport.Width / 100) * 2)
                {
                    variables.moveScreenX += variables.moveScreenSpeed;
                }
                else {
                    variables.playerRectangle.X -= variables.movePlayerSpeed;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (variables.playerRectangle.X >= (this.GraphicsDevice.Viewport.Width / 100) * 98)
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
                if (variables.playerRectangle.Y <= (this.GraphicsDevice.Viewport.Height / 100) * 2)
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
                if (variables.playerRectangle.Y >= (this.GraphicsDevice.Viewport.Height / 100) * 99)
                {
                    variables.moveScreenY -= variables.moveScreenSpeed;
                }
                else
                {
                    variables.playerRectangle.Y += variables.movePlayerSpeed;
                }
            }*/

            if (keyState.IsKeyPressed(Keys.Left, 800))
            {
                if (variables.editorCursorRectangle.X <= (this.GraphicsDevice.Viewport.Width / 100) * 2)
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
                if (variables.editorCursorRectangle.X >= (this.GraphicsDevice.Viewport.Width / 100) * 98)
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
                if (variables.editorCursorRectangle.Y <= (this.GraphicsDevice.Viewport.Height / 100) * 2)
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
                if (variables.editorCursorRectangle.Y >= (this.GraphicsDevice.Viewport.Height / 100) * 99)
                {
                    variables.moveScreenY -= variables.blockHeight;
                }
                else
                {
                    variables.editorCursorRectangle.Y += variables.blockHeight;
                }
            }
            if (variables.isCollisionEnabled) { CheckForCollisions(); }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            foreach (Block block in variables.blocks)
            {
                spriteBatch.Draw(block.texture, new Rectangle(block.position.X + variables.moveScreenX, block.position.Y + variables.moveScreenY, variables.blockWidth, variables.blockHeight), Color.White);

            }
            //spriteBatch.Draw(Content.Load<Texture2D>("Textures/2"), variables.playerRectangle, Color.White);
            spriteBatch.Draw(Content.Load<Texture2D>("Textures/1"), variables.editorCursorRectangle, Color.Red);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        void CheckForCollisions()
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
