using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Hackerman
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        Texture2D triangle;
        SpriteBatch spriteBatch;
        Texture2D mainmenu;
        Texture2D interfacaOfPlay;
        Vector2 position;
        Sprite _arrow;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 648;
            graphics.PreferredBackBufferWidth = 1150;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            position = new Vector2(graphics.GraphicsDevice.Viewport.
                       Width / 2,
                                    graphics.GraphicsDevice.Viewport.
                                    Height / 2);
            _arrow = new Sprite(triangle)
            {
                Position = new Vector2(100, 100),
                Color = Color.White,
                Rotation = 0f,
                Scale = 1f,
                Origin = new Vector2(triangle.Bounds.Center.X, triangle.Bounds.Center.Y)
            };
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            mainmenu = Content.Load<Texture2D>("knowledge");
            interfacaOfPlay = Content.Load<Texture2D>("HackMenuScreen");
            triangle = Content.Load<Texture2D>("Triangle");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState state = Mouse.GetState();
            Vector2 mousePosition = new Vector2(state.X, state.Y);
            Vector2 dPos = _arrow.Position - mousePosition;

            _arrow.Rotation = (float)Math.Atan2(dPos.Y, dPos.X);
            //position.X = state.X;
            //position.Y = state.Y;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            _arrow.Draw(spriteBatch, gameTime);
            spriteBatch.Draw(mainmenu, position: new Vector2(0, 0));
            spriteBatch.Draw(triangle, position, scale: new Vector2(0.3f));
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
