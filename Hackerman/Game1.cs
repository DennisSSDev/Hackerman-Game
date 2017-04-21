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
using System.Timers;

namespace Hackerman
{//Collabarative work present from Alessandro, Anthony, Dennis
    //add 2 more timers: one for the enemy spawning, so that they don't spawn all at the same time and another for the shots cooldown so that it won't be a bullet fest
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
        Texture2D background;
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
        Texture2D hackSprite;
        Texture2D coolDownStart;
        Texture2D coolDownTwo;
        Texture2D coolDownOne;
        Texture2D coolDownDone;
        //Texture2D hackSpritesheet;

        // Font textures;
        SpriteFont playerScore;
        SpriteFont menuFont;
        SpriteFont controlFont;

        // Sound
        Song threeHundred;
        SoundEffect mSound;
        SoundEffect hitSound;

        // Menu Rectangles 
        Rectangle play = new Rectangle(0, 200, 379, 86);
        Rectangle edit = new Rectangle(0, 300, 488, 89);
        Rectangle help = new Rectangle(0, 400, 488, 89);
        Rectangle exit = new Rectangle(0, 500, 379, 86);
        Rectangle hack = new Rectangle( 125, 25, 948, 116);

        /* Animation 
        int frame;
        double timeCounter;
        double fps;
        double timePerFrame;

        // Constants for Hackerman Spritesheet 
        const int WALK_FRAME_COUNT = 4;
        const int H_RECT_Y_OFFSET = 100;
        const int H_RECT_HEIGHT = 31;
        const int H_RECT_WIDTH = 31;*/

        // Vector attribute for the background 
        Vector2 backMove = new Vector2(0,0);


        Sprite _dot;
        Sprite box;
        MouseState state;
        Player _arrow;
        Laser newLaser;
        List<Enemy> incomingEnemies = new List<Enemy>();
        List<Enemy> delEnemies = new List<Enemy>();
        List<Laser> laserShots = new List<Laser>();
        List<Laser> delLaserShots = new List<Laser>();
        GameState cState = GameState.Menu; 
        Vector2 dPos = new Vector2(0, 0);
        KeyboardState kbState;
        KeyboardState previousKbState = Keyboard.GetState();
        bool fileExists = false;
        bool launchExternal = true;
        bool fileLoadAllowance = true;
        int threadCount = 1;
        System.Timers.Timer aTimer = new System.Timers.Timer();//timer per round
        System.Timers.Timer aTimerForEnemies = new System.Timers.Timer();//timer per each enemy spawn
        int shotCoolDown = 0;//timer for shot coolDown
        System.Timers.Timer aTimerForCoolDown = new System.Timers.Timer();
        bool allowedShot = true;
        bool allowedSpawn = false;
        bool allowedMOvement = false;
        bool allowedMoveAfterSpawn = false;
        System.Timers.Timer aTimerForAttackingPlayer = new System.Timers.Timer();
        System.Timers.Timer timerForIndividualSpawn = new System.Timers.Timer();
        int allower = 0;
        int b = 0;
        bool continuation = true;
        int counterPerSpawn = 0;
        int addedLasers = -1;
        MouseState forLeftClickcur;
        MouseState forLeftClickprev;


        Enemy blank = new Enemy();
        Thread timerThread;

        int coordinateXcomponent;
        int coordinateYcomponent;
        int score = 0;
        int round = 0;
        int difficulty = 1;
        int intTimer = 0;
        
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
            Random speedSetter = new Random();
            Random xANDySetter = new Random();
            for (int i = 0; i < round * 2 + 1; i++)
            {
                int sideSetter = xANDySetter.Next(0, 4);
                if(sideSetter == 0)//TOP OF THE BOX
                {
                    incomingEnemies.Add(new Enemy(xANDySetter.Next(0, 1151), -15, 100, 100, 0, 0, 0f, 5f, Color.White, speedSetter.Next(1, 4)));
                    blank.EnemyCount++;
                }
                else if(sideSetter == 1)//LEFT SIDE OF THE BOX
                {
                    incomingEnemies.Add(new Enemy(-15, xANDySetter.Next(0, 649), 100, 100, 0, 0, 0f, 5f, Color.White, speedSetter.Next(1, 4)));
                    blank.EnemyCount++;
                }
                else if(sideSetter == 2)//BUTTOM OF THE BOX 
                {
                    incomingEnemies.Add(new Enemy(xANDySetter.Next(0,1151), GraphicsDevice.Viewport.Height+15, 100, 100, 0, 0, 0f, 5f, Color.White, speedSetter.Next(1, 4)));
                    blank.EnemyCount++;
                }
                else if(sideSetter == 3)//RIGHT SIDE OF THE BOX
                {
                    incomingEnemies.Add(new Enemy(GraphicsDevice.Viewport.Width+15, xANDySetter.Next(0, 649), 100, 100, 0, 0, 0f, 5f, Color.White, speedSetter.Next(1, 4)));
                    blank.EnemyCount++;
                }
                else
                {
                    return;
                }
            }
            /*for (int i = 0; i < incomingEnemies.Count; i++)
            {
                for (int j = 1; j < incomingEnemies.Count; j++)
                {
                    incomingEnemies[i].ColissionSpawn(incomingEnemies[j]);
                }
            }*/
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
                if (backMove.X != -350)
                {
                    box.X -= 5;
                    backMove.X -= 5;
                    return;
                }
            }
            else if (_arrow.X <= 50)
            {
                _arrow.X +=10;
                if(backMove.X != 350)
                {
                    box.X += 5;
                    backMove.X += 5;
                    return;
                }
            }
            else if (_arrow.Y >= GraphicsDevice.Viewport.Height-50)
            {
                _arrow.Y -= 10;
                if (backMove.Y != -300)
                {
                    box.Y -= 5;
                    backMove.Y -= 5;
                    return;
                }
            }
            else if (_arrow.Y <= 50)
            {
                _arrow.Y += 10;
                if (backMove.Y != 300)
                {
                    box.Y += 5;
                    backMove.Y += 5;
                    return;
                }
            }
            else if (_arrow.Y >= GraphicsDevice.Viewport.Height - 50 && _arrow.X >= GraphicsDevice.Viewport.Width - 50 && Keyboard.GetState().IsKeyDown(Keys.D)
                && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _arrow.Y -= 50;
                _arrow.X -= 50;
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

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            intTimer += 1;
        }

        private void OnTimedEventForSpawnEnemy(object source, ElapsedEventArgs e)
        {
            allowedSpawn = true;
        }
        private void OnTimeEventForCoolDown(object source, ElapsedEventArgs e)
        {
            shotCoolDown = 0;
            allowedShot = true;
            aTimerForCoolDown.Stop();
        }
        private void OnTimeEventForEnemyAttack(object source, ElapsedEventArgs e)
        {
            for (int i = 0; i < incomingEnemies.Count; i++)
            {
                incomingEnemies[i].Strength = 1;
            }
            aTimerForAttackingPlayer.Stop();
        }
        private void OnTimeEventForIndividualSpawn(object source, ElapsedEventArgs e)
        {
            allowedMOvement = true;
            aTimerForAttackingPlayer.Stop();
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

            /* Initialize the animation 
            fps = 10.0;
            timePerFrame = 1.0 / fps;*/

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            aTimerForEnemies.Elapsed += new ElapsedEventHandler(OnTimedEventForSpawnEnemy);
            aTimerForEnemies.Interval = 50;
            aTimerForEnemies.Enabled = true;

            aTimerForCoolDown.Elapsed += new ElapsedEventHandler(OnTimeEventForCoolDown);
            aTimerForCoolDown.Interval = 3000;
            aTimerForCoolDown.Enabled = true;

            aTimerForAttackingPlayer.Elapsed += new ElapsedEventHandler(OnTimeEventForEnemyAttack);
            aTimerForAttackingPlayer.Interval = 5000;
            aTimerForAttackingPlayer.Enabled = true;

            timerForIndividualSpawn.Elapsed += new ElapsedEventHandler(OnTimeEventForIndividualSpawn);
            timerForIndividualSpawn.Interval = 100;
            timerForIndividualSpawn.Enabled = true;

            // Fonts
            playerScore = Content.Load<SpriteFont>("Score");
            menuFont = Content.Load<SpriteFont>("menuFont");
            controlFont = Content.Load<SpriteFont>("Controls");

            // Textures
            boxForBox = Content.Load<Texture2D>("BoxForEnemies");
            dot = Content.Load<Texture2D>("Crosshair");
            enemyTex = Content.Load<Texture2D>("BugWhite");
            laserTex = Content.Load<Texture2D>("Projectile");
            background = Content.Load<Texture2D>("HackLvl2");
            menuRectangle = Content.Load<Texture2D>("rectangle");
            fHealth = Content.Load<Texture2D>("Full Health");
            twoHealth = Content.Load<Texture2D>("2-3 Health");
            oneHealth = Content.Load<Texture2D>("1-3 Health");
            noHealth = Content.Load<Texture2D>("0 Health");
            hackSprite = Content.Load<Texture2D>("HackSprite");
            // For some reason the cooldowns didn't get through
            coolDownStart = Content.Load<Texture2D>("CooldownStart");
            coolDownOne = Content.Load<Texture2D>("CooldownOne");
            coolDownTwo = Content.Load<Texture2D>("CooldownTwo");
            coolDownDone = Content.Load<Texture2D>("CooldownDone");
            
            //hackSpritesheet = Content.Load<Texture2D>("HackSpriteSheet");

            // Music and sound
            mSound = Content.Load<SoundEffect>("mSound");
            threeHundred = Content.Load<Song>("300MB");
            hitSound = Content.Load<SoundEffect>("hitSound");
            MediaPlayer.Play(threeHundred);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = .15f;

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

            

            _dot = new Sprite(300, 400, 50, 50, 300, 400, 0f, 0.3f, Color.White)
            {
                Origin = new Vector2(dot.Bounds.Center.X, dot.Bounds.Center.Y)
            };
            _arrow = new Player(300, 300, 100, 100, 100,100, 0f, 0.75f,Color.White)
            {
                Origin = new Vector2(hackSprite.Bounds.Center.X, hackSprite.Bounds.Center.Y)
            };
            newLaser = new Laser(_arrow.X, _arrow.Y, 100, 50, 0, 0, 0f, 1f, Color.White);
            if (fileExists != false)
            {
                box = new Sprite(coordinateXcomponent, coordinateYcomponent, 200, 200, 0,
                0, 0f, 1f, Color.White);
                box.Texture = boxForBox;
            }

            _arrow.Texture = hackSprite;
            _dot.Texture = dot;
            //consider putting enemySpawn in the update method since you'd want to spawn new members upon next round
            timerThread = new Thread(()=> {
                EnemySpawn();
                for (int i = 0; i < incomingEnemies.Count; i++)
                {
                    incomingEnemies[i].Texture = enemyTex;
                }

            }
            );
            newLaser.Texture = laserTex;
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //You can't disregard transparent pixels, either create sprites without extra transparent space 
        }
        public void SetMovement()
        {
            for (int i = b; i < incomingEnemies.Count; i++)//Need to loop through all the members of the list but not come back to them, as you don't want to start the timer twice
            {
                if (i < 0)
                {
                    i++;
                    break;
                }
                if (incomingEnemies[i].AllowedMovement == false)
                {
                    if (allowedMOvement)
                    {
                        incomingEnemies[i].AllowedMovement = true;
                        b++;
                        continuation = true;
                        allowedMOvement = false;
                        
                        return;
                    }
                    if (continuation)
                    {
                        Random randomTImeCaster = new Random();

                        timerForIndividualSpawn.Interval = randomTImeCaster.Next(300, 1000);
                        timerForIndividualSpawn.Start();
                        allowedMOvement = false;
                        continuation = false;
                    }
                    return;
                }
                if(incomingEnemies[i].AllowedMovement == true)
                {
                    b++;
                }
                if(incomingEnemies[i] == null)
                {
                    b = 0;
                }

            }
        }

        public void HardReset()
        {
            Rectangle resetPlayerPos = new Rectangle(300, 400, 100, 100);
            _arrow.Position = resetPlayerPos;
            
            Rectangle resetEnemyPos = new Rectangle(0, 0, 100, 100);
            _arrow.Health = 3;

            score = 0;
            round = 0;
            _arrow.Health = 3;
            backMove.X = 0;
            backMove.Y = 0;
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

            // Volume controls 
            if(SingleKeyPress(Keys.Right))
            {
                MediaPlayer.Volume += .10f;
            }
            else if(SingleKeyPress(Keys.Left))
            {
                MediaPlayer.Volume -= .10f;
            }
            if (SingleKeyPress(Keys.N))
            {
                MediaPlayer.Pause();
            }
            else if (SingleKeyPress(Keys.U))
            {
                MediaPlayer.Resume();
            }

            /* Handle animation timing
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if(timeCounter >= timePerFrame)
            {
                frame += 1; 
                if(frame > WALK_FRAME_COUNT)
                {
                    frame = 1;
                }

                timeCounter -= timePerFrame;
                
            }*/

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
                    mSound.Play();
                }
                else if(helpPressed == true)
                {
                    cState = GameState.Help;
                    mSound.Play();
                }
                else if(exitPressed == true)
                {
                    cState = GameState.Exit;
                }
                else if(editPressed == true)
                {
                    cState = GameState.Edit;
                    mSound.Play();
                }
            }

            // Game State 
            else if (cState == GameState.Game)
            {
                
                if (incomingEnemies.Count <= 0)
                {
                    b = 0;
                    counterPerSpawn = 0;
                    aTimer.Start();
                    if (intTimer >= 3)
                    {
                        
                        
                        aTimer.Stop();
                        round++;
                        intTimer = 0;
                        EnemySpawn();
                        for (int i = 0; i < incomingEnemies.Count; i++)
                        {
                         
                            incomingEnemies[i].Texture = enemyTex;
                            incomingEnemies[i].RotateForPlayer(_arrow);
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

                forLeftClickcur = Mouse.GetState();
                if (forLeftClickcur.LeftButton == ButtonState.Pressed && forLeftClickprev.LeftButton != ButtonState.Pressed)
                {
                    
                    if (shotCoolDown == 50)
                    {
                        allowedShot = false;
                        aTimerForCoolDown.Start();
                    }
                    if(allowedShot == true)
                    {
                        laserShots.Add(new Laser(_arrow.X, _arrow.Y, 100, 50, 0, 0, 0.1f, 1f, Color.White));
                        addedLasers++;
                        laserShots[addedLasers].Texture = laserTex;
                        laserShots[addedLasers].Visible = true;
                        shotCoolDown++;
                    }
                    

                }
                forLeftClickprev = forLeftClickcur;
                
                foreach (var item in laserShots)
                {
                    if (item.Visible)
                    {
                      item.Shoot(_arrow);
                        
                    }
                }
                Vector2 mousePosition = new Vector2(state.X, state.Y);
                state = Mouse.GetState();
                dPos.X = _arrow.X - state.X;
                dPos.Y = _arrow.Y - state.Y;
                
                _arrow.Rotation = (float)Math.Atan2(dPos.Y, dPos.X) - 1.75f;
                _dot.X = (int)mousePosition.X;
                _dot.Y = (int)mousePosition.Y;
                
                PlayerControls();

                ScreenWarp();

                SetMovement();


                //make a thread for enemy spawning for each round to give the player some breathing space 

                //add a new attribute for the enemy ( a bool) that is either true or false that will change as the timer progresses(for spawn only)
                //once the movement is allowed for all enemies they should all start moving 
                for (int i = 0; i < incomingEnemies.Count; i++)
                    {
                        //reset the enemy strength once done with debug
                        if (fileExists)
                        {
                            if (incomingEnemies[i].Position.Intersects(box.Position))//requires to get a temp position as they will just stop moving with the actual move
                            {
                                continue;
                            }
                            if(incomingEnemies[i].AllowedMovement)
                            {
                                for (int j = 0; j < incomingEnemies[i].Speed; j++)
                                {
                                    incomingEnemies[i].FindPlayer(_arrow);
                                }

                            }
                            


                        }
                        else
                        {
                            if (incomingEnemies[i].AllowedMovement)
                            {
                                for(int j = 0; j<incomingEnemies[i].Speed; j++)
                                {
                                    incomingEnemies[i].FindPlayer(_arrow);
                                }

                            }

                        }

                        if(incomingEnemies[i].AttackPlayer(_arrow) == true)
                        {
                            for (int j = 0; j < incomingEnemies.Count; j++)
                            {
                                incomingEnemies[j].Strength = 0;
                            }
                            aTimerForAttackingPlayer.Start();
                            hitSound.Play();

                        }
                    }
                
                for (int i = 0; i < incomingEnemies.Count; i++)//this list should be used to find out who died, ocne found, go back up or right after 
                {
                    foreach (var item in laserShots)
                    {
                        if (incomingEnemies[i].CheckForDeath(item))
                        {
                            b--;
                            incomingEnemies[i].Strength = 0;
                            incomingEnemies[i].Speed = 0;
                            incomingEnemies[i].X = 10000;
                            delEnemies.Add(incomingEnemies[i]);
                            item.Visible = false;
                            
                            score++;
                        }
                    }
                }
                foreach (var item in delEnemies)
                {
                    
                    incomingEnemies.Remove(item);
                    
                }


                if (_arrow.Health == 0)
                {
                    cState = GameState.GameOver;
                }

                

                if(SingleKeyPress(Keys.P))
                {
                    cState = GameState.Pause;
                }

                // Drawing Hackerman walking and standing.

            }
            
            else if (cState == GameState.GameOver)
            {
                MediaPlayer.Stop();
                if(SingleKeyPress(Keys.Enter))
                {
                    cState = GameState.Menu;
                    MediaPlayer.Play(threeHundred);
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

        /* Drawing Hackerman either standing or drawing
        public void DrawHackStanding(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(
                hackSpritesheet,
                _arrow.Origin,
                new Rectangle(
                    0,
                    H_RECT_Y_OFFSET,
                    H_RECT_WIDTH,
                    H_RECT_HEIGHT),
                Color.White,
                0f,
                Vector2.Zero,
                1.0f,
                flipSprite,
                0);
        }*/

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

                spriteBatch.Draw(menuRectangle, new Rectangle(GraphicsDevice.Viewport.Width / 9, GraphicsDevice.Viewport.Height / 4, 600, 450), Color.Black * .8f);
                spriteBatch.DrawString(menuFont, "CONTROLS", new Vector2(150, 175), Color.White);
                spriteBatch.DrawString(controlFont, "Move up/down/left/right: W/S/A/D", new Vector2(150, 250), Color.LimeGreen);
                spriteBatch.DrawString(controlFont, "Fire: Left click", new Vector2(150, 300), Color.LimeGreen);
                spriteBatch.DrawString(controlFont, "Aim: Move mouse", new Vector2(150, 350), Color.LimeGreen);
                spriteBatch.DrawString(controlFont, "Pause: 'P'", new Vector2(150, 400), Color.LimeGreen);
                spriteBatch.DrawString(controlFont, "Turn up volume: -> Turn down volume: <-", new Vector2(150, 450), Color.LimeGreen);
                spriteBatch.DrawString(controlFont, "Mwaute: 'N' Unmute: 'U'", new Vector2(150, 500), Color.LimeGreen);
                spriteBatch.DrawString(controlFont, "Push Enter to return to menu", new Vector2(150, 560), Color.White);
            }

            if (cState == GameState.Game)
            {
                for (int i = 0; i < incomingEnemies.Count; i++)//needs a fix, first they need to face the player, then they should be drawn with a dfferent persepctive
                {
                    incomingEnemies[i].FacePlayer(_arrow);
                }
                spriteBatch.Draw(background, backMove, scale: new Vector2(1f));
                spriteBatch.DrawString(controlFont, "Score: "+ String.Format("{0:0}", score), new Vector2(875f, 5f), Color.LimeGreen, 0f, new Vector2(1f, 1f), 1.5f, SpriteEffects.None, 0f);
                spriteBatch.DrawString(controlFont, string.Format("Round: {0}", round), new Vector2(875, 590), Color.LimeGreen, 0f, new Vector2(1f, 1f), 1.5f, SpriteEffects.None, 0f);
                if (fileExists == true)
                {
                    box.Draw(spriteBatch, gameTime);
                }
                _arrow.Draw(spriteBatch, gameTime);
                _dot.Draw(spriteBatch, gameTime);
                for(int i = 0; i < incomingEnemies.Count; i++)
                {
                    if (incomingEnemies[i].Alive == true)
                    {
                        incomingEnemies[i].Draw(spriteBatch, gameTime);
                    }
                }
                foreach (var item in laserShots)
                {
                    if (item.Visible == true)
                    {
                        item.Draw(spriteBatch, gameTime);
                    }

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

                // Cooldown bar 
                if(allowedShot == true)
                {
                    spriteBatch.Draw(coolDownStart, new Rectangle(20,100, 200, 200), Color.White);
                }
            }

            if(cState == GameState.GameOver)
            {
                spriteBatch.Draw(bareMenu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(title, hack, Color.White);
                spriteBatch.Draw(menuRectangle, new Rectangle(GraphicsDevice.Viewport.Width / 9, GraphicsDevice.Viewport.Height / 4, 525, 450), Color.Black * .8f);
                spriteBatch.DrawString(menuFont, "GAME OVER", new Vector2(150, 175), Color.White);
                spriteBatch.DrawString(controlFont, String.Format("Score: {0}", score), new Vector2(150, 300), Color.White);
                spriteBatch.DrawString(controlFont, String.Format("Round: {0}", round), new Vector2(150, 350), Color.White);
                spriteBatch.DrawString(controlFont, "Push Enter to return to menu", new Vector2(150, 560), Color.White);
            }

            if(cState == GameState.Pause)
            {
                for (int i = 0; i < incomingEnemies.Count; i++)
                {
                    incomingEnemies[i].FacePlayer(_arrow);
                }
                // Having the game in the background 
                spriteBatch.Draw(background, backMove);
                spriteBatch.DrawString(controlFont, "Score: " + String.Format("{0:0}", score), new Vector2(875f, 5f), Color.LimeGreen, 0f, new Vector2(1f, 1f), 1.5f, SpriteEffects.None, 0f);
                if (fileExists == true)
                {
                    box.Draw(spriteBatch, gameTime);
                }
                _arrow.Draw(spriteBatch, gameTime);
                _dot.Draw(spriteBatch, gameTime);
                for (int i = 0; i < incomingEnemies.Count; i++)
                {
                    if (incomingEnemies[i].Alive == true)
                    {
                        incomingEnemies[i].Draw(spriteBatch, gameTime);
                    }
                }
                //DrawHackStanding(SpriteEffects.None);

                foreach (var item in laserShots)
                {
                    if (item.Visible == true)
                    {
                        item.Draw(spriteBatch, gameTime);
                    }
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
