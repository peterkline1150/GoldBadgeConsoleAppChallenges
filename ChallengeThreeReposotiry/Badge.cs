using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; } = new List<string>();

        public Badge()
        {

        }
        public Badge(int badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }

        public bool AddDoor(string doorName)
        {
            int count = DoorNames.Count;
            DoorNames.Add(doorName);

            if (count < DoorNames.Count)
            {
                return true;
            }
            return false;
        }
        public bool RemoveDoor(string doorName)
        {
            int count = DoorNames.Count;
            DoorNames.Remove(doorName);

            if (count > DoorNames.Count)
            {
                return true;
            }
            return false;
        }
    }
}
