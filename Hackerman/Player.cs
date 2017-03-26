using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hackerman
{//Dennis Made this
    class Player : Sprite, IPlayer
    {
        private int health;
        private int speed;
        private int totalScore;

        /// <summary>
        /// Important!!! since you will need to draw the laser, it cannot be in the player class, 
        /// it requires its own class and will inherit from the player since it needs to know the player position all the time
        /// </summary>
        private Texture2D laser;


        public Texture2D Laser { get { return laser; } set { laser = value; } }
        public int Health { get { return health; } set { health = value; } }
        public int Speed { get { return speed; } set { speed = value; } }
        public int TotalScore { get { return totalScore; } set { totalScore = value; } }
        //player will not have a strength stat since the laser deals damage
        public Player()
        {

        }

        public Player(int xR, int yR, int height, int width, int xV, int yV, float pRotation, float pScale, Color pColor,
            int health = 2, int speed = 10, int pTotalScore  = 0)
            :base(xR, yR, height, width, xV, yV, pRotation, pScale, pColor)
        {
            this.health = health;
            this.speed = speed;
            this.totalScore = pTotalScore;
        }

        public bool Alive(int health)
        {
            throw new NotImplementedException();
        }

        public void Collision(IEnemy enemy, IMoveableObj walls)
        {
            throw new NotImplementedException();
        }

        public void Kill(IEnemy enemy)
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
        public void SoundEffect()
        {
            throw new NotImplementedException();
        }
    }
}
