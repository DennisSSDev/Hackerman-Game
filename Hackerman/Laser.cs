using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hackerman
{
    class Laser: Sprite
    {
        private int damage = 0;
        private bool visible = false;
        private MouseState state;
        private int distanceX = 0;
        private int distanceY=0;
        public int Damage { get { return damage; } set { damage = value; } }
        public bool Visible { get { return visible; } set { visible = value; } }
        private Player playerstats = new Player();
        public Laser(int xR, int yR, int height, int width, int xV, int yV, float pRotation, float pScale, Color pColor,
            int pDamage = 1, bool visible = false)
            :base(xR, yR, height, width, xV, yV, pRotation, pScale, pColor)
        {
            this.damage = pDamage;
            this.visible = visible;
        }

        public void Shoot(Player obj)
        {
            if(state.X == 0 && state.Y == 0)
            {
                state = Mouse.GetState();
                distanceX = obj.X - state.X;
                distanceY = obj.Y - state.Y;
            }
            else if (this.X < 0 || this.Y < 0 || this.X > 1000)
            {
                state = Mouse.GetState();
                this.Visible = false;
                this.X = obj.X;
                this.Y = obj.Y;
            }
            if (visible && this.X != distanceX && this.Y != distanceY)
            {
                distanceX = obj.X - state.X;
                distanceY = obj.Y - state.Y;
                //might want to look for specific quadronts
                this.X -= (int)Math.Round(distanceX / 10.0);
                this.Y -= (int)Math.Round(distanceY / 10.0);
                //just look for the state x and y and add a static number until x and y of obj do not reach state.x and state.y, if state.x and state.y are reached,
                //run in the same direction untuil off screen 
            }
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (visible)
            {
                base.Draw(spriteBatch, gameTime);
            }
        }
    }
}
