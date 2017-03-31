using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Diagnostics;
namespace Hackerman
{//Collabarative work present from Alessandro, Anthony, Dennis
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
        Texture2D fHealth;
        Texture2D twoHealth;
        Texture2D oneHealth;
        Texture2D noHealth;
        SpriteFont playerScore;
        SpriteFont menuFont;
        SpriteFont controlFont;
        SpriteFont gameoTitle;
        Song threeHundred;

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
        List<Enemy> incomingEnemies = new List<Enemy>();
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
        int round = 1;
        double timer;
        
        //probably want to add a list of enemies too when we get around making more then 1 (list because the majority would just be duplicates)
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 648;
            graphics.PreferredBackBufferWidth = 1150;
            Content.RootDirectory = "Content";
            
        }

        public void EnemySpawn()
        {
            Random xANDySetter = new Random();
            for (int i = 0; i < round * 2 + 3; i++)
            {
                int sideSetter = xANDySetter.Next(0, 4);
                if(sideSetter == 0)//TOP OF THE BOX
                {
                    incomingEnemies.Add(new Enemy(xANDySetter.Next(0, 1151), 0, 100, 100, 0, 0, 0f, 5f, Color.White));
                }
                else if(sideSetter == 1)//LEFT SIDE OF THE BOX
                {
                    incomingEnemies.Add(new Enemy(0, xANDySetter.Next(0, 649), 100, 100, 0, 0, 0f, 5f, Color.White));
                }
                else if(sideSetter == 2)//BUTTOM OF THE BOX 
                {
                    incomingEnemies.Add(new Enemy(xANDySetter.Next(0,1151), GraphicsDevice.Viewport.Height, 100, 100, 0, 0, 0f, 5f, Color.White));
                }
                else if(sideSetter == 3)//RIGHT SIDE OF THE BOX
                {
                    incomingEnemies.Add(new Enemy(GraphicsDevice.Viewport.Width, xANDySetter.Next(0, 649), 100, 100, 0, 0, 0f, 5f, Color.White));
                }
                else
                {
                    return;
                }
                
            }
        }
         
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

        public bool DoubleKeyPress(Keys k, Keys u)
        {
            kbState = Keyboard.GetState();
            if ((kbState.IsKeyDown(k) && kbState.IsKeyDown(u)) && ((previousKbState.IsKeyUp(k) && previousKbState.IsKeyUp(u))))
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
            // Fonts
            playerScore = Content.Load<SpriteFont>("Score");
            menuFont = Content.Load<SpriteFont>("menuFont");
            controlFont = Content.Load<SpriteFont>("Controls");

            // Textures
            boxForBox = Content.Load<Texture2D>("HackTemp");
            triangle = Content.Load<Texture2D>("Triangle");
            dot = Content.Load<Texture2D>("Crosshair");
            enemyTex = Content.Load<Texture2D>("bug");
            laserTex = Content.Load<Texture2D>("Projectile");
            mainmenu = Content.Load<Texture2D>("HackLvl2");
            menuRectangle = Content.Load<Texture2D>("rectangle");
            fHealth = Content.Load<Texture2D>("Full Health");
            twoHealth = Content.Load<Texture2D>("2-3 Health");
            oneHealth = Content.Load<Texture2D>("1-3 Health");
            noHealth = Content.Load<Texture2D>("0 Health");

            // Music
            threeHundred = Content.Load<Song>("300MB");
            MediaPlayer.Play(threeHundred);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 45f;
            //un-comment when you push

            // Interface
            exitBtn = Content.Load<Texture2D>("Exit");
            playBtn = Content.Load<Texture2D>("PlayButton");
            editBtn = Content.Load<Texture2D>("LevelButton");
            helpBtn = Content.Load<Texture2D>("ControlsButton");
            bareMenu = Content.Load<Texture2D>("BareMenu");
            title = Content.Load<Texture2D>("HackLogo");
            interfacaOfPlay = Content.Load<Texture2D>("HackMenuScreen");
            menuRectangle = Content.Load<Texture2D>("rectangle");

            fileExists = File.Exists(@"Coordinate\coordinate.dat");
 
            if (fileExists)
            {
                using (Stream streamer =
                File.OpenRead(@"Coordinate\coordinate.dat"))//ask steve
                {
                    var reader = new BinaryReader(streamer);
                    try
                    {
                        coordinateXcomponent = reader.ReadInt32();
                        coordinateYcomponent = reader.ReadInt32();
                    }
                    catch (Exception)
                    {
                        coordinateXcomponent = -1000;
                        coordinateYcomponent = -1000;
                    }
                    
                }
                
            }

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
            EnemySpawn();
            for (int i = 0; i < incomingEnemies.Count; i++)
            {
                incomingEnemies[i].Texture = enemyTex;
            }
            newLaser.Texture = laserTex;
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

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
            _arrow.Health = 3;
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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            // Exit();
            // Unneeded as we already have the interface for this. Though, if it's easier to code with it on, then uncomment when you 
            // edit

            /* Volume controls 
            if(SingleKeyPress(Keys.Right))
            {
                MediaPlayer.Volume += 10;
            }
            else if(SingleKeyPress(Keys.Left))
            {
                MediaPlayer.Volume -= 1;
            }*/

            if (SingleKeyPress(Keys.N))
            {
                MediaPlayer.Pause();
            }
            else if (SingleKeyPress(Keys.U))
            {
                MediaPlayer.Resume();
            }

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

                // Menu state transitions
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
                    cState = GameState.Exit;
                }
                else if(editPressed == true)
                {
                    cState = GameState.Edit;
                }
            }

            // Game State 
            else if (cState == GameState.Game)
            {
                if (fileExists)
                {
                    if (box.Position.Intersects(newEnemy.Position))
                    {
                        if (newEnemy.Y >= box.Y + box.Position.Height / 2)
                        {
                            newEnemy.Y = box.Y + box.Position.Height;
                        }

                        else if (newEnemy.X <= box.X + box.Position.Width)
                        {
                            newEnemy.X = box.X;
                        }
                    }
                }
                if (fileLoadAllowance)
                {
                    if (fileExists)
                    {
                        using (Stream streamer =
                        File.OpenRead(@"Coordinate\coordinate.dat"))//ask steve
                        {
                            var reader = new BinaryReader(streamer);
                            try
                            {
                                coordinateXcomponent = reader.ReadInt32();
                                coordinateYcomponent = reader.ReadInt32();
                            }
                            catch (Exception)
                            {
                                coordinateXcomponent = -1000;
                                coordinateYcomponent = -1000;
                            }
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
  
                timer -= gameTime.ElapsedGameTime.Seconds;

                if (newEnemy.AttackPlayer(_arrow))
                {
                    if (timer <= 0)
                    {
                        newEnemy.Strength = 1;
                        timer = 2;
                    }
                    else
                    {
                        newEnemy.Strength = 0;
                    }
                }
                for (int i = 0; i < incomingEnemies.Count; i++)
                {
                    incomingEnemies[i].FindPlayer(_arrow);
                    incomingEnemies[i].AttackPlayer(_arrow);
                }
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
                MediaPlayer.Stop();
                if(SingleKeyPress(Keys.Enter))
                {
                    cState = GameState.Menu;
                    MediaPlayer.Play(threeHundred);
                    //un-comment when you push 
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

            else if(cState == GameState.Exit)
            {
                Exit();
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
            GraphicsDevice.Clear(Color.Black);

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
                spriteBatch.Draw(bareMenu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(title, hack, Color.White);

                spriteBatch.Draw(menuRectangle, new Rectangle(GraphicsDevice.Viewport.Width / 9, GraphicsDevice.Viewport.Height / 4, 525, 450), Color.Black * .8f);
                spriteBatch.DrawString(menuFont, "CONTROLS", new Vector2(150, 175), Color.White);
                spriteBatch.DrawString(controlFont, "Move up/down/left/right: W/S/A/D", new Vector2(150, 250), Color.LimeGreen);
                spriteBatch.DrawString(controlFont, "Fire: Left click", new Vector2(150, 300), Color.LimeGreen);
                spriteBatch.DrawString(controlFont, "Aim: Move mouse", new Vector2(150, 350), Color.LimeGreen);
                spriteBatch.DrawString(controlFont, "Pause: P", new Vector2(150, 400), Color.LimeGreen);
                spriteBatch.DrawString(controlFont, "Push Enter to return to menu", new Vector2(150, 560), Color.White);
            }

            if (cState == GameState.Game)
            {
                newEnemy.FacePlayer(_arrow);
                spriteBatch.Draw(mainmenu, new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(playerScore, "Score: "+ String.Format("{0:0}", score), new Vector2(900f, 20f), Color.White, 0f, new Vector2(1f, 1f), 2f, SpriteEffects.None, 0f);
                if (fileExists == true)
                {
                    box.Draw(spriteBatch, gameTime);
                }
                _arrow.Draw(spriteBatch, gameTime);
                newEnemy.Draw(spriteBatch, gameTime);
                _dot.Draw(spriteBatch, gameTime);
                for(int i = 0; i < incomingEnemies.Count; i++)
                {
                    incomingEnemies[i].Draw(spriteBatch, gameTime);
                }
                if (newLaser.Visible == true)
                {
                    newLaser.Draw(spriteBatch, gameTime);
                }

                // Health bar
                spriteBatch.DrawString(controlFont, "Health", new Vector2(70, 15), Color.LimeGreen);

                if (_arrow.Health == 3)
                {
                    spriteBatch.Draw(fHealth, new Rectangle(200, 10, 300, 42), Color.White);
                }
                else if (_arrow.Health == 2)
                {
                    spriteBatch.Draw(twoHealth, new Rectangle(200, 10, 300, 42), Color.White);
                }
                else if (_arrow.Health == 1)
                {
                    spriteBatch.Draw(oneHealth, new Rectangle(200, 10, 300, 42), Color.White);
                }
                else if (_arrow.Health == 0)
                {
                    spriteBatch.Draw(noHealth, new Rectangle(200, 10, 300, 42), Color.White);
                }
            }

            if(cState == GameState.GameOver)
            {
                spriteBatch.Draw(bareMenu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(title, hack, Color.White);
                spriteBatch.Draw(menuRectangle, new Rectangle(GraphicsDevice.Viewport.Width / 9, GraphicsDevice.Viewport.Height / 4, 525, 450), Color.Black * .8f);
                spriteBatch.DrawString(menuFont, "GAME OVER", new Vector2(150, 175), Color.White);
                spriteBatch.DrawString(controlFont, String.Format("Score: {0}", score), new Vector2(150, 300), Color.White);
                spriteBatch.DrawString(controlFont, String.Format("Rounds: {0}", score), new Vector2(150, 350), Color.White);
                spriteBatch.DrawString(controlFont, "Push Enter to return to menu", new Vector2(150, 560), Color.White);
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
                spriteBatch.DrawString(controlFont, "Continue - P", new Vector2(425, 250), Color.LimeGreen);
                spriteBatch.DrawString(controlFont, "Menu - M", new Vector2(425, 350), Color.LimeGreen);
                spriteBatch.DrawString(controlFont, "Exit - Esc", new Vector2(425, 450), Color.LimeGreen);
            }

            if (cState == GameState.Edit)
            {
                spriteBatch.Draw(bareMenu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(title, hack, Color.White);
                spriteBatch.DrawString(controlFont, "Push Enter to return to menu", new Vector2(150, 560), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
