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
        private float distanceX = 0;
        private float distanceY=0;
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

        public void Shoot(Player obj, Enemy obj2)
        {

            //EDIT: There is an important error: if you are able to catch the shot while it's being shot it will change the trajectory of the shot
            //Solutions: 
            //FIX the method, or... 
            //make the player to always be slower than the shot so that he could never be able to catch
            if (state.X == 0 && state.Y == 0)
            {
                state = Mouse.GetState();
                distanceX = obj.X - state.X;
                distanceY = obj.Y - state.Y;
                this.Rotation = (float)(Math.Atan2(distanceY, distanceX));//might be a bad idea
            }//this is all sorts of wrong, since sometimes the shots don't reach the destination and might start shooting in the same direction
            else if (this.X < 0 || this.Y < 0 || this.X > 1200 || this.Y > 800 || this.Position.Intersects(obj2.Position))
            {
                //also add if the laser is visible and collides with the palyer position, make sure then to add a little to the shots starting point as it will always collide
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
