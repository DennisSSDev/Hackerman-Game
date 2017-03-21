using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
namespace Hackerman
{
    enum GameState
    {
        Game,
        Menu,
        Edit,
        Help, 
        GameOver,
        Exit
        // Just need a state for the game itself, 
        // not for individual 
    };
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        //Textures
        Texture2D triangle;
        Texture2D mainmenu;
        Texture2D interfacaOfPlay;
        Texture2D dot;
        Texture2D enemyTex;
        Texture2D laserTex;
        Texture2D editBtn;
        Texture2D playBtn;
        Texture2D exitBtn;
        Texture2D helpBtn;
        Texture2D title;
        Texture2D bareMenu;
        Texture2D boxForBox;

        // Menu Rectangles 
        Rectangle play = new Rectangle(0, 200, 379, 86);
        Rectangle edit = new Rectangle(0, 300, 488, 89);
        Rectangle help = new Rectangle(0, 400, 488, 89);
        Rectangle exit = new Rectangle(0, 500, 379, 86);
        Rectangle hack = new Rectangle( 125, 25, 948, 116);

        MouseState prevState;
        Sprite _dot;
        Sprite box;
        MouseState state;
        Player _arrow;
        Laser newLaser;
        Enemy newEnemy;
        double timer = 0;
        GameState cState = GameState.Game; 
        Vector2 dPos = new Vector2(0, 0);
        KeyboardState kbState;
        KeyboardState previousKbState;

        int coordinateXcomponent;
        int coordinateYcomponent;

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
        {//fix the corner problem
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
            if(Mouse.GetState().LeftButton == ButtonState.Pressed && cState == GameState.Game)
            {
                newLaser.Visible = true;
                newLaser.Damage = 1;
            }
        }
        public void ScreenWarp()
        {
            if (_arrow.X >= GraphicsDevice.Viewport.Width-50)//Might not work since checking for screen width
            {
                _arrow.X-=10;
            }
            else if (_arrow.X <= 50)
            {
                _arrow.X +=10;
            }
            else if (_arrow.Y > GraphicsDevice.Viewport.Height-50)
            {
                _arrow.Y -= 10;
            }
            else if (_arrow.Y <= 50)
            {
                _arrow.Y += 10;
            }
        }

        // Creating clickable areas in each rectangle 
        public bool Click(Rectangle r, Vector2 st)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (r.Contains(st))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Used to get back to menu from Help and Game Over
        public bool SingleKeyPress(Keys k)
        {
            if (kbState.IsKeyDown(k) && previousKbState.IsKeyUp(k))
            {
                return true;
            }
            else
            {
                return false;
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
            

            using (Stream streamer = 
                File.Open(@"D:\Profiles\akp4657\Source\Repos\Hackerman\Hackerman\Content\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\Coordinate\coordinate.dat",
                FileMode.Open))//ask steve
            {
                var reader = new BinaryReader(streamer);
                coordinateXcomponent = reader.ReadInt32();
                coordinateYcomponent = reader.ReadInt32();
            }

            boxForBox = Content.Load<Texture2D>("HackTemp");

            triangle = Content.Load<Texture2D>("Triangle");
            
            dot = Content.Load<Texture2D>("Dot1");

            enemyTex = Content.Load<Texture2D>("bug");

            laserTex = Content.Load<Texture2D>("Health");

            mainmenu = Content.Load<Texture2D>("knowledge");

            newEnemy = new Enemy(0, 0, 100, 100, 0, 0, 0f, 5f, Color.White);

            _dot = new Sprite(300, 400, 50, 50, 300, 400, 0f, 0.3f, Color.White)
            {
                Origin = new Vector2(dot.Bounds.Center.X, dot.Bounds.Center.Y)
            };
            _arrow = new Player(300, 300, 100, 100, 100, 100, 0f, 0.75f,Color.White)
            {
                Origin = new Vector2(triangle.Bounds.Center.X, triangle.Bounds.Center.Y)
            };
            newLaser = new Laser(_arrow.X, _arrow.Y, 100, 50, 0, 0, _arrow.Rotation, 1f, Color.White);

            box = new Sprite(coordinateXcomponent, coordinateYcomponent, 200, 200, 0,
                0, 0f, 1f, Color.White);

            _arrow.Texture = triangle;
            _dot.Texture = dot;
            box.Texture = boxForBox;
            newEnemy.Texture = enemyTex;
            newLaser.Texture = laserTex;
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            exitBtn = Content.Load<Texture2D>("Exit");
            playBtn = Content.Load<Texture2D>("PlayButton");
            editBtn = Content.Load<Texture2D>("LevelButton");
            helpBtn = Content.Load<Texture2D>("ControlsButton");
            bareMenu = Content.Load<Texture2D>("BareMenu");
            title = Content.Load<Texture2D>("HackLogo");
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

            kbState = Keyboard.GetState();

            // Menu State 
            if (cState == GameState.Menu)
            {
                // Mouse movement
                state = Mouse.GetState();
                Vector2 mousePosition = new Vector2(state.X, state.Y);
                dPos.X = _arrow.X - state.X;
                dPos.Y = _arrow.Y - state.Y;
                //_arrow.Rotation = (float)Math.Atan2(dPos.Y, dPos.X);
                _dot.X = (int)mousePosition.X;
                _dot.Y = (int)mousePosition.Y;

                // Checking to see which was pressed 
                bool playPressed = Click(play, mousePosition);
                bool helpPressed = Click(help, mousePosition);
                bool exitPressed = Click(exit, mousePosition);
                bool editPressed = Click(edit, mousePosition);

                // If statements
                if (playPressed == true)
                {
                    cState = GameState.Game;
                }
                else if(helpPressed == true)
                {
                    cState = GameState.Help;
                }
                else if(exitPressed == true)
                {
                    Environment.Exit(0);
                }
                else if(editPressed == true)
                {
                    cState = GameState.Edit;
                }

            }

            // Game State 
            else if (cState == GameState.Game)
            {
                state = Mouse.GetState();
                Vector2 mousePosition = new Vector2(state.X, state.Y);
                if (newLaser.Visible == false) 
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

                ScreenWarp();

                newEnemy.FindPlayer(_arrow);
                newEnemy.AttackPlayer(_arrow);
                if (newLaser.Visible)
                {
                    newLaser.Shoot(_arrow);
                }

                if (_arrow.Health == 0)
                {
                    cState = GameState.GameOver;
                }
                if (newEnemy.CheckForDeath(newLaser))
                {
                    cState = GameState.Menu;
                    newEnemy.Strength = 0;
                }
            }

            // Menu State will have player go back to main menu for now 
            else if (cState == GameState.GameOver)
            {
                if(SingleKeyPress(Keys.Enter))
                {
                    cState = GameState.Menu;
                }
            }

            else if (cState == GameState.Help)
            {
                if (SingleKeyPress(Keys.Enter))
                {
                    cState = GameState.Menu;
                }
            }

            else if (cState == GameState.Edit)
            {
                if (SingleKeyPress(Keys.Enter))
                {
                    cState = GameState.Menu;
                }
            }

            previousKbState = kbState;
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
                spriteBatch.Draw(bareMenu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(helpBtn, help, Color.White);
                spriteBatch.Draw(exitBtn, exit, Color.White);
                spriteBatch.Draw(editBtn, edit, Color.White);
                spriteBatch.Draw(playBtn, play, Color.White);
                spriteBatch.Draw(title, hack, Color.White);
                _dot.Draw(spriteBatch, gameTime);
            }

            if (cState == GameState.Help)
            {
                GraphicsDevice.Clear(Color.Red);
            }

            if (cState == GameState.Game)
            {
                spriteBatch.Draw(mainmenu, position: new Vector2(0, 0));
                box.Draw(spriteBatch, gameTime);
                
                _arrow.Draw(spriteBatch, gameTime);
                newEnemy.Draw(spriteBatch, gameTime);
                _dot.Draw(spriteBatch, gameTime);

                if (newLaser.Visible == true)
                {
                    newLaser.Draw(spriteBatch, gameTime);
                }
                // Also need to draw the interface 
            }

            if(cState == GameState.GameOver)
            {
                GraphicsDevice.Clear(Color.Black);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
