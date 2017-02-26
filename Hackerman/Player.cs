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
    class Player : IPlayer
    {
        public int Health { get; set; }
        public int Speed { get; set; }

        public Player()
        {

        }

        public Player(int health, int speed) 
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
