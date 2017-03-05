using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Hackerman
{
    enum ControlState
    {//Add enums so that they work with controls
        Left,
        Right,
        Up,
        Down,
        TLeftCorner,
        TRightCorner,
        BLeftCorner,
        BRightCorner
    };
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        Texture2D triangle;
        SpriteBatch spriteBatch;
        Texture2D mainmenu;
        Texture2D interfacaOfPlay;
        Texture2D dot;
        Sprite _dot;
        MouseState state;
        Player _arrow;
        ControlState cState;//make use of this
        Vector2 dPos = new Vector2(0, 0);

        //probably want to add a list of enemies too when we get around making more then 1 (list because the majority would just be duplicates)
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 648;
            graphics.PreferredBackBufferWidth = 1150;
            Content.RootDirectory = "Content";
        }

        public void PlayerControls()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Vector2 revert = new Vector2(_arrow.Speed, _arrow.Speed);
                _arrow.X -= (int)revert.X;
                _arrow.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A) && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Vector2 revert = new Vector2(_arrow.Speed, -_arrow.Speed);
                _arrow.X -= (int)revert.X;
                _arrow.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Vector2 revert = new Vector2(-_arrow.Speed, -_arrow.Speed);
                _arrow.X -= (int)revert.X;
                _arrow.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Vector2 revert = new Vector2(-_arrow.Speed, _arrow.Speed);
                _arrow.X -= (int)revert.X;
                _arrow.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Vector2 revert = new Vector2(_arrow.Speed, 0);
                _arrow.X -= (int)revert.X;
                _arrow.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Vector2 revert = new Vector2(-10, 0);
                _arrow.X -= (int)revert.X;
                _arrow.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Vector2 revert = new Vector2(-1 * _arrow.Speed, 0);
                _arrow.X -= (int)revert.X;
                _arrow.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Vector2 revert = new Vector2(0, -1 * _arrow.Speed);
                _arrow.X -= (int)revert.X;
                _arrow.Y -= (int)revert.Y;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Vector2 revert = new Vector2(0, _arrow.Speed);
                _arrow.X -= (int)revert.X;
                _arrow.Y -= (int)revert.Y;
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            triangle = Content.Load<Texture2D>("Triangle");
            
            dot = Content.Load<Texture2D>("Dot1");
            
            _arrow = new Player(100, 100, 100, 100, 100,100, 0f, 0.75f, Color.White, 10, 5)
            {
                Origin = new Vector2(triangle.Bounds.Center.X, triangle.Bounds.Center.Y)
            };
            _dot = new Sprite(300, 400, 50, 50, 300, 400, 0f, 0.3f, Color.White)
            {
                Origin = new Vector2(dot.Bounds.Center.X, dot.Bounds.Center.Y)
            };
            _arrow.Texture = triangle;
            _dot.Texture = dot;
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            mainmenu = Content.Load<Texture2D>("knowledge");
            interfacaOfPlay = Content.Load<Texture2D>("HackMenuScreen");
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
            

            state = Mouse.GetState();
            Vector2 mousePosition = new Vector2(state.X, state.Y);

            dPos.X = _arrow.X - state.X;
            dPos.Y = _arrow.Y - state.Y;
            
            _arrow.Rotation = (float)Math.Atan2(dPos.Y, dPos.X);
            _dot.X = (int)mousePosition.X;
            _dot.Y = (int)mousePosition.Y;
            PlayerControls();

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
            spriteBatch.Draw(mainmenu, position: new Vector2(0, 0));
            _arrow.Draw(spriteBatch, gameTime);
            _dot.Draw(spriteBatch, gameTime);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
