using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerman
{
    class MainMenu : IMainMenu
    {
        enum MenuEnum
        {
            Main, // Main Menu screen
            Game, // game.exe 
            Death, // Death Screen
            Pause, 
            LevelEdit,
            Help,
            Exit, 
        };

        public string BackgroundTexture
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Image
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string SoundEffect
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void DeathScreen(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void LaunchSoundEffect()
        {
            throw new NotImplementedException();
        }

        public void LoadMainImage()
        {
            throw new NotImplementedException();
        }

        public void PauseScreen()
        {
            throw new NotImplementedException();
        }

        public bool PressedMenuButton(string button)
        {
            throw new NotImplementedException();
        }

        public void SetBackgroundTexture()
        {
            throw new NotImplementedException();
        }

        public int ShowHS()
        {
            throw new NotImplementedException();
        }
    }
}
