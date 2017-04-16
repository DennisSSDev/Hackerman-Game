using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerman
{
    interface IEnemy
    {
        int Strength { get; set; }
        int Speed { get; set; }
        bool AttackPlayer(Player obj);
        void FindPlayer(Player obj);
        int CountOfEnemiesOverFlow();//this method will help the round method determine if all the enmies are dead
    }
}
