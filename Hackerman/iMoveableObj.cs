using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerman
{
    interface IMoveableObj
    {
        string Walls { get; set; }
        void Collision(IPlayer player, IEnemy enemy);
    }
}
