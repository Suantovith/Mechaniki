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
        Editor editor;
        Travel travel;
        Config config;
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
            editor = new Editor();
            travel = new Travel();
            config = new Config(variables);
            variables = config.LoadConfig(variables);
            if (variables.state == 0)
            {
                travel.Init(map, variables, this.Content);
            }
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (variables.state == 0)
            {
                travel.Update(variables, this.GraphicsDevice);
            }
            else if(variables.state == 1)
            {
                editor.Update(keyState, variables, this.Content, map, this.GraphicsDevice);
            } 


            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            foreach (Block block in variables.blocks)
            {
                spriteBatch.Draw(block.texture, new Rectangle(block.spriteRectangle.X + variables.moveScreenX, block.spriteRectangle.Y + variables.moveScreenY, variables.blockWidth, variables.blockHeight), Color.White);

            }
            
            if(variables.state == 0)
            {
                travel.Draw(spriteBatch, this.Content, variables);
            }
            else if(variables.state == 1)
            {
                editor.Draw(spriteBatch, this.Content, variables);
            }
            
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
