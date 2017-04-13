using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Hackerman
{//Dennis Made this
    class Enemy : Sprite, IEnemy//the list of enemies has to be here 
    {
        private int health;
        private int speed;
        private int strength;
        private bool alive = true;
        public int Speed { get { return speed; } set { speed = value; } }
        public bool Alive { get { return alive; } set { alive = value; } }
        public int Strength { get { return strength; } set { strength = value; } }
        public int RectangleHeight { get; set; }
        public int RectangleWidth { get; set; }
        public int EnemyCount { get; set; }//rework the class with lists
        public Enemy(int xR, int yR, int height, int width, int xV, int yV, float pRotation,
            float pScale, Color pColor, int speed = 3, int strength = 1, int health = 1, bool alive = true)
            :base(xR, yR, height, width, xV, yV, pRotation, pScale, pColor)   
        {
            this.speed = speed;
            this.health = health;
            this.strength = strength;
            this.alive = alive;
            RectangleHeight = height;
            RectangleWidth = width;
            
        }
        public Enemy()
        {
            //blank enemy, used to launch the list
        }
        public bool AttackPlayer(Player obj)
        {
            if (this.Position.Intersects(obj.Position))
            {
                obj.X+=25;
                obj.Health-=strength;
                return true;
            }
            return false;
        }

        public bool CheckForDeath(Laser obj)
        {
            if (this.Position.Intersects(obj.Position) && obj.Visible == true)
            {
                health--;
                obj.Visible = false;//althought the projectile becomes invisible, it will still follow the past projectile state, since we don't reset ater collision

                if (health == 0)
                {
                    alive = false;
                    EnemyCount--;
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

        public int CountOfEnemiesOverFlow()
        {
            try
            {
                if (EnemyCount > 100)
                {
                    throw new Exception("Enemy count is way too big, commiting stop");
                }
                return EnemyCount;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void FacePlayer(Player obj)
        {
            int dPosX = this.X - obj.X;
            int dPosY = this.Y - obj.Y;
            //find the top left corner of the rectangle to set an initial rotation of the enemy towards the player( might want to do this in the constructor) 
            this.Rotation = (float)Math.Atan2(dPosY, dPosX);
        }
        public void ColissionSpawn(Enemy obj)//this method should only be used for spawning 
        {
            if (this.Position.Intersects(obj.Position))
            {
                obj.X += 20;
            }
        }
        public void FindPlayer(Player obj, Enemy obj2)
        {
            
            if (this.X != obj.X && this.Y != obj.Y)
                {
                Vector2 someVec = new Vector2(this.X - obj.X, this.Y - obj.Y);
                //create a temporary rectangle that will try to predict the position of the enemy and if it collides with anyone
                someVec.Normalize();
                Rectangle temp = new Rectangle(this.X, this.Y, this.RectangleWidth, this.RectangleHeight);
                temp.X -= (int)Math.Round(someVec.X);
                temp.Y -= (int)Math.Round(someVec.Y);
               // if (temp.Intersects(obj2.Position))
               // {
                  //  this.X -= 0;
                   // this.Y -= 0;
                   // temp.X = this.X;
                   // temp.Y = this.Y;
                //}
                //else
                //{
                    this.X = temp.X;
                    this.Y = temp.Y;
               // }   
            }  
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (alive)
            {
                base.Draw(spriteBatch, gameTime);
            }
        }

      
    }
}
