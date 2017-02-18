﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerman
{
    interface IEnemy
    {
        void Collision(IPlayer player, IMoveableObj wall);
        int Strength { get; set; }
        int Speed { get; set; }
        void AttackPlayer(IPlayer player);
        void FindPlayer(IPlayer player);
        string EnemyTexture { get; set; }
        int CountOfEnemies();//this method will help the round method determine if all the enmies are dead
    }
}