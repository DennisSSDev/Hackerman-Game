using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerman
{
    interface ILevelEditor: IMoveableObj
    {
        string Buttons { get; set; }
        void PlaceWalls(IMoveableObj walls);
        void RemoveWalls(IMoveableObj walls);
        bool PressedButton();
        void SaveChanges();
        void ResetMap();
    }
}
