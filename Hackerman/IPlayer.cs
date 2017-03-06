using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerman
{
    interface IPlayer
    {
        void Collision(IEnemy enemy, IMoveableObj walls);
        void Move();
        void Kill(IEnemy enemy);
        int Health { get; set; }
        int Speed { get; set; }
        void SoundEffect();
        bool Alive(int health);

    }
}
