using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerman
{
    enum EnemyEnum
    {
        Dead, 
        Attack,
        Spawn
    };

    class Enemy : IEnemy
    {
        public int Speed { get; set; }

        public int Strength { get; set; }

        public Enemy(int speed, int strength)
        {

        }

        public void AttackPlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void Collision(IPlayer player, IMoveableObj wall)
        {
            throw new NotImplementedException();
        }

        public int CountOfEnemies()
        {
            throw new NotImplementedException();
        }

        public void FindPlayer(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
