using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerman
{
    interface IFluidItems
    {
        int Rounds { get; set; }
        int HighScore { get; set; }
        string RandomEvent { get; set; }
        int CountRounds();
        int CountHS();
        string LaunchRandomEvent();
    }
}
