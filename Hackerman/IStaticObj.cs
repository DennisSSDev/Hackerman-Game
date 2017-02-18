using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerman
{
    interface IStaticObj
    {
        void LaunchSoundEffect();
        string SoundEffect { get; set; }
        string BackgroundTexture { get; set; }
        void SetBackgroundTexture();

    }
}
