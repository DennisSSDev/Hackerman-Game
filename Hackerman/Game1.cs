using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Diagnostics;
namespace Hackerman
{
    enum GameState
    {
        Game,
        Menu,
        Edit,
        Help, 
        GameOver,
        Pause,
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
        Texture2D menuRectangle;
        SpriteFont playerScore;
        SpriteFont menuFont;

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
        GameState cState = GameState.Menu; 
        Vector2 dPos = new Vector2(0, 0);
        KeyboardState kbState;
        KeyboardState previousKbState = Keyboard.GetState();
        KeyboardState kbStateInMenu;
        bool fileExists = false;
        bool launchExternal = true;
        bool fileLoadAllowance = true;
        //string controls = "Go";
        

        int coordinateXcomponent;
        int coordinateYcomponent;
        int score = 0;
        
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
            
            // Empty method just stopping all movement
            //else if(s == "Stop")
            // {}
        }
       
        public void LaunchExt()
        {
                if (launchExternal)
                {
                    Process.Start(
                       "WindowsFormsApplication1.exe");
                    launchExternal = false;
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
            kbState = Keyboard.GetState();
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
            

            fileExists = File.Exists(@"Coordinate\coordinate.dat");
 
            if (fileExists)
            {
                using (Stream streamer =
                File.OpenRead(@"Coordinate\coordinate.dat"))//ask steve
                {
                    var reader = new BinaryReader(streamer);
                    coordinateXcomponent = reader.ReadInt32();
                    coordinateYcomponent = reader.ReadInt32();

                }
            }
            playerScore = Content.Load<SpriteFont>("Score");

            menuFont = Content.Load<SpriteFont>("menuFont");

            boxForBox = Content.Load<Texture2D>("HackTemp");

            triangle = Content.Load<Texture2D>("Triangle");
            
            dot = Content.Load<Texture2D>("Dot1");

            enemyTex = Content.Load<Texture2D>("bug");

            laserTex = Content.Load<Texture2D>("Health");

            mainmenu = Content.Load<Texture2D>("knowledge");

            newEnemy = new Enemy(0, 0, 100, 100, 0,0, 0f, 5f, Color.White);

            _dot = new Sprite(300, 400, 50, 50, 300, 400, 0f, 0.3f, Color.White)
            {
                Origin = new Vector2(dot.Bounds.Center.X, dot.Bounds.Center.Y)
            };
            _arrow = new Player(300, 300, 100, 100, 100,100, 0f, 0.75f,Color.White)
            {
                Origin = new Vector2(triangle.Bounds.Center.X, triangle.Bounds.Center.Y)
            };
            newLaser = new Laser(_arrow.X, _arrow.Y, 100, 50, 0, 0, 0.1f, 1f, Color.White);
            if (fileExists != false)
            {
                box = new Sprite(coordinateXcomponent, coordinateYcomponent, 200, 200, 0,
                0, 0f, 1f, Color.White);
                box.Texture = boxForBox;
            }

            _arrow.Texture = triangle;
            _dot.Texture = dot;
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
            menuRectangle = Content.Load<Texture2D>("rectangle");
            //You can't disregard transparent pixels, either create sprites without extra transparent space 
        }

        public void HardReset()
        {
            Rectangle resetPlayerPos = new Rectangle(300, 400, 100, 100);
            _arrow.Position = resetPlayerPos;
            newLaser.Position = _arrow.Position;
            newLaser.Visible = false;
            Rectangle resetEnemyPos = new Rectangle(0, 0, 100, 100);
            newEnemy.Position = resetEnemyPos;
            newEnemy.Strength = 1;
            newEnemy.Alive = true;
            //controls = "Go";
            //This will reset most of the important things, but it won't recet the direction of the shot yet, change it so that when you shoot and the shot is out of bounds, reset it's pos
            //this also doesn't reset the score, which it will, just add it later
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
            if (cState == GameState.Menu)
            {
                fileLoadAllowance = true;
                launchExternal = true;
                HardReset();
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
                if (fileLoadAllowance)
                {
                    if (fileExists)
                    {
                        using (Stream streamer =
                        File.OpenRead(@"Coordinate\coordinate.dat"))//ask steve
                        {
                            var reader = new BinaryReader(streamer);
                            coordinateXcomponent = reader.ReadInt32();
                            coordinateYcomponent = reader.ReadInt32();
                            box.X = coordinateXcomponent;
                            box.Y = coordinateYcomponent;
                        }
                    }
                    fileLoadAllowance = false;
                }

                MouseState forLeftClick = Mouse.GetState();
                if (forLeftClick.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Released)
                {
                    newLaser.Visible = true;
                    newLaser.Damage = 1;

                }
                Vector2 mousePosition = new Vector2(state.X, state.Y);

                if (newLaser.Visible == false) 
                {
                    newLaser.X = _arrow.X;
                    newLaser.Y = _arrow.Y;
                    newLaser.Rotation = _arrow.Rotation+18f;
                }
                state = Mouse.GetState();
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
                    newLaser.Shoot(_arrow,newEnemy);
                }

                if (_arrow.Health == 0)
                {
                    cState = GameState.GameOver;
                }
                if (newEnemy.CheckForDeath(newLaser))
                {
                    cState = GameState.Menu;
                    newEnemy.Strength = 0;
                    score++;
                }

                if(SingleKeyPress(Keys.P))
                {
                    cState = GameState.Pause;
                }
            }

            // Menu State will have player go back to main menu for now 
            else if (cState == GameState.GameOver)
            {
                newEnemy.X = -100;
                _arrow.Health = 2;
                //controls = "Stop";
                if(SingleKeyPress(Keys.Enter))
                {
                    cState = GameState.Menu;
                }
            }

            else if(cState == GameState.Pause)
            {
                if (SingleKeyPress(Keys.Escape))
                {
                    cState = GameState.Exit;
                }
                else if(SingleKeyPress(Keys.M))
                {
                    cState = GameState.Menu;
                }
                else if(SingleKeyPress(Keys.P))
                {
                    cState = GameState.Game;
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
                LaunchExt();
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
                newEnemy.FacePlayer(_arrow);
                spriteBatch.Draw(mainmenu, position: new Vector2(0, 0));
                spriteBatch.DrawString(playerScore, "Score: "+ String.Format("{0:0}", score), new Vector2(900f, 20f), Color.White, 0f, new Vector2(1f, 1f), 2f, SpriteEffects.None, 0f);
                if (fileExists == true)
                {
                    box.Draw(spriteBatch, gameTime);
                }
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
                /*spriteBatch.Draw(mainmenu, position: new Vector2(0, 0));
                spriteBatch.DrawString(playerScore, "Score: " + String.Format("{0:0}", score), new Vector2(900f, 20f), Color.White, 0f, new Vector2(1f, 1f), 2f, SpriteEffects.None, 0f);
                if (fileExists == true)
                {
                    box.Draw(spriteBatch, gameTime);
                }
                _arrow.Draw(spriteBatch, gameTime);
                newEnemy.Draw(spriteBatch, gameTime);
                _dot.Draw(spriteBatch, gameTime);*/
                spriteBatch.Draw(menuRectangle, new Rectangle(GraphicsDevice.Viewport.Width / 4, GraphicsDevice.Viewport.Height / 6, 500, 500), Color.Black * .8f);
            }

            if(cState == GameState.Pause)
            {
                // Having the game in the background 
                spriteBatch.Draw(mainmenu, position: new Vector2(0, 0));
                spriteBatch.DrawString(playerScore, "Score: " + String.Format("{0:0}", score), new Vector2(900f, 20f), Color.White, 0f, new Vector2(1f, 1f), 2f, SpriteEffects.None, 0f);
                if (fileExists == true)
                {
                    box.Draw(spriteBatch, gameTime);
                }
                _arrow.Draw(spriteBatch, gameTime);
                newEnemy.Draw(spriteBatch, gameTime);
                _dot.Draw(spriteBatch, gameTime);

                if (newLaser.Visible == true)
                {
                    newLaser.Draw(spriteBatch, gameTime);
                }
                
                // Rectangle for the menu
                spriteBatch.Draw(menuRectangle, new Rectangle(GraphicsDevice.Viewport.Width / 4, GraphicsDevice.Viewport.Height / 6, 500, 500), Color.Black * .8f);
                spriteBatch.DrawString(menuFont, "PAUSE", new Vector2(425, 150), Color.White);
                spriteBatch.DrawString(menuFont, "Continue - P", new Vector2(375, 250), Color.White);
                spriteBatch.DrawString(menuFont, "Menu - M", new Vector2(425, 350), Color.White);
                spriteBatch.DrawString(menuFont, "Exit - Esc", new Vector2(425, 450), Color.White);
            }

            if (cState == GameState.Edit)
            {
                spriteBatch.Draw(bareMenu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(title, hack, Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
