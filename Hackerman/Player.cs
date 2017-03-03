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
    enum PlayerEnum
    {
        Alive, 
        Dead,
        LHealth, // Lose health 
        GameOver,
        ScoreUp
    };

    class Player : Sprite, IPlayer
    {
        public int Health { get; set; }
        public int Speed { get; set; }

        public Player()
        {

        }

        public Player(int xR, int yR, int height, int width, int xV, int yV, float pRotation, float pScale, Color pColor, int health, int speed)
            :base(xR, yR, height, width, xV, yV, pRotation, pScale, pColor)
        {
            this.Health = health;
            this.Speed = speed;
        }


        public void Aim()
        {
            throw new NotImplementedException();
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

        public void Shoot()
        {
            throw new NotImplementedException();
        }

        public void SoundEffect()
        {
            throw new NotImplementedException();
        }
    }
}
