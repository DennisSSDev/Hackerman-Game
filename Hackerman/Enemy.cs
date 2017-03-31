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
    class Enemy : Sprite, IEnemy
    {
        private int health;
        private int speed;
        private int strength;
        private int xforRotation = 0;
        private int yforRotation = 0;
        private int distanceX = 0;
        private int distanceY = 0;
        private bool alive = true;
        public int Speed { get { return speed; } set { speed = value; } }
        public bool Alive { get { return alive; } set { alive = value; } }
        public int Strength { get { return strength; } set { strength = value; } }
        public Enemy(int xR, int yR, int height, int width, int xV, int yV, float pRotation,
            float pScale, Color pColor, int speed = 3, int strength = 1, int health = 6, bool alive = true)
            :base(xR, yR, height, width, xV, yV, pRotation, pScale, pColor)   
        {
            this.speed = speed;
            this.health = health;
            this.strength = strength;
            this.alive = alive;

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

        public void Collision(IPlayer player, IMoveableObj wall)
        {
            throw new NotImplementedException();
        }

        public bool CheckForDeath(Laser obj)
        {
            if (this.Position.Intersects(obj.Position) && obj.Visible == true)
            {
                health--;
                obj.Visible = false;//althought the projectile becomes invisible, it will still follow the past projectile state, since we don't reset ater collision
                obj.Damage = 0;
                if (health == 0)
                {
                    alive = false;
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

        public int CountOfEnemies()
        {
            throw new NotImplementedException();
        }
        public void FacePlayer(Player obj)
        {
            this.Rotation = (float)Math.Atan(obj.Rotation);
        }

        public void FindPlayer(Player obj)
        {
            
            if (this.X != obj.X && this.Y != obj.Y)
                {
                if (this.X < obj.X)
                {
                    distanceX = obj.X - this.X;
                }
                if (this.X > obj.X)
                {
                    distanceX = this.X - obj.X;
                }
                if (this.Y < obj.Y)
                {
                    distanceY = obj.Y - this.Y;
                }
                if (this.Y > obj.Y)
                {
                    distanceY = this.Y - obj.Y;
                }
                Vector2 someVector = new Vector2(distanceX, distanceY);
                someVector.Normalize();
                    Vector2 someVec = new Vector2(this.X - obj.X, this.Y - obj.Y);
                    someVec.Normalize();
                    this.X -= 3*(int)Math.Round(someVec.X);
                    this.Y -= 3*(int)Math.Round(someVec.Y);   
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
