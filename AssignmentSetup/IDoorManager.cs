using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSetup
{
    public interface IDoorManager : IManager
    {
        // door manager class returns bool (int door id )
        bool OpenDoor(int doorID);

        // lock door returns bool (int door id)

        bool LockDoor(int doorID);

        // open all doors returns bool
        bool OpenAllDoors();

        // lock all doors returns bool

        bool LockAllDoors();
    }
}
