using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Hackerman
{
    enum GameState
    {
        Game,
        Menu,
        Help, 
        GameOver,
        Exit
        // Just need a state for the game itself, 
        // not for individual 
    };
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        Texture2D triangle;
        SpriteBatch spriteBatch;
        Texture2D mainmenu;
        Texture2D interfacaOfPlay;
        Texture2D dot;
        Texture2D enemyTex;
        Texture2D laserTex;
        Sprite _dot;
        MouseState state;
        Player _arrow;
        Laser newLaser;
        Enemy newEnemy;
        double timer = 0;
        GameState cState = GameState.Game; // Since we have no menu code, we'll just start in the game 
        Vector2 dPos = new Vector2(0, 0);
        KeyboardState kbState;
        KeyboardState previousKbState = Keyboard.GetState();

        //probably want to add a list of enemies too when we get around making more then 1 (list because the majority would just be duplicates)
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 648;
            graphics.PreferredBackBufferWidth = 1150;
            Content.RootDirectory = "Content";
        }
        //Add a wrap method, to keep the playing field within the bounds of the screen 
        public void PlayerControls()//allows the control of the player 
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
            else if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                newLaser.Visible = true;
            }
        }
        public void ScreenWrap()
        {
            if (_arrow.X == GraphicsDevice.Viewport.Width)//Might not work since checking for screen width
            {
                _arrow.X -=10;
            }
            else if (_arrow.X == 0)
            {
                _arrow.X += 10;
            }

            if (_arrow.Y == GraphicsDevice.Viewport.Height)
            {
                _arrow.Y -= 10;
            }
            else if (_arrow.Y == 0)
            {
                previousKbState = kbState;//might not be needed check during debug
                kbState = Keyboard.GetState();
                if (kbState.IsKeyDown(Keys.A))
                {
                    //use a black box

                }
               

               
                
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
            //We should initialize the player only, without the dot since if we initialize the dot,
            //it might appear on the menu screen, we don't want that 
            
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

            enemyTex = Content.Load<Texture2D>("bug");

            laserTex = Content.Load<Texture2D>("Health");
            
            newEnemy = new Enemy(0, 0, 100, 100, 0, 0, 0f, 5f, Color.White);

            

            _dot = new Sprite(300, 400, 50, 50, 300, 400, 0f, 0.3f, Color.White)
            {
                Origin = new Vector2(dot.Bounds.Center.X, dot.Bounds.Center.Y)
            };
            _arrow = new Player(300, 300, 100, 100, 100, 100, 0f, 0.75f, Color.White, 10, 5)
            {
                Origin = new Vector2(triangle.Bounds.Center.X, triangle.Bounds.Center.Y)
            };
            newLaser = new Laser(_arrow.X, _arrow.Y, 100, 50, 0, 0, _arrow.Rotation, 1f, Color.White);
            _arrow.Texture = triangle;
            _dot.Texture = dot;
            newEnemy.Texture = enemyTex;
            newLaser.Texture = laserTex;
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
            
            // Menu State 
            if(cState == GameState.Menu)
            {
                // Somehow we need to interact with rectangles and the mouse click
                // if(user clicks help)
                // { cState = GameState.Help }
                // else if(user clicks Exit) 
                // { cState = GameState.Exit }
                // else if(user clicks play) 
                // { cState = GameState.Game }
            }

            // Game State 
            else if (cState == GameState.Game)
            {
                state = Mouse.GetState();
                Vector2 mousePosition = new Vector2(state.X, state.Y);
                if(newLaser.Visible == false)
                {
                    newLaser.X = _arrow.X;
                    newLaser.Y = _arrow.Y;
                    newLaser.Rotation = _arrow.Rotation;
                }
                dPos.X = _arrow.X - state.X;
                dPos.Y = _arrow.Y - state.Y;

                _arrow.Rotation = (float)Math.Atan2(dPos.Y, dPos.X);
                _dot.X = (int)mousePosition.X;
                _dot.Y = (int)mousePosition.Y;

                PlayerControls();

                timer += gameTime.ElapsedGameTime.TotalSeconds;
                newEnemy.FindPlayer(_arrow);
                newEnemy.AttackPlayer(_arrow);
                if (newLaser.Visible)
                {
                    newLaser.Shoot(_arrow);
                }

                 if(_arrow.Health == 0 || timer == 0) 
                 {
                    cState = GameState.GameOver; 
                 }
            }

            // Menu State will have player go back to main menu for now 
            else if(cState == GameState.GameOver)
            {
                // Check to see if they just press enter 
                // or something similar
            }

            else if(cState == GameState.Exit)
            {
                // Exit program 
            }

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
            if(cState == GameState.Menu)
            {
                // Draw menu screen
            }

            if (cState == GameState.Help)
            {
                // Draw help screen 
            }

            if (cState == GameState.Game)
            {
                spriteBatch.Draw(mainmenu, position: new Vector2(0, 0));
                _arrow.Draw(spriteBatch, gameTime);
                newEnemy.Draw(spriteBatch, gameTime);
                _dot.Draw(spriteBatch, gameTime);
                if(newLaser.Visible == true)
                {
                    newLaser.Draw(spriteBatch, gameTime);
                }
                // Also need to draw the interface 
            }

            if(cState == GameState.GameOver)
            {
                // Draw game over screen
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
