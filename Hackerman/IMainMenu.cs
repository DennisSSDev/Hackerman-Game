using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerman
{
    interface IMainMenu: IStaticObj
    {
        //Needs a list to hold image textures for the menu
        int ShowHS();//Will show the highscore to the player in the menu
        string Image { get; set; }//property that allows to get and check the desired image
        void LoadMainImage();
        bool PressedMenuButton(string button);//if the method returns true, then a button was pressed
        void DeathScreen(IPlayer player);//Will spawn if player is dead
        void PauseScreen();//if player pauses, launch this method
    }
}
