using ChallengeThreeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeReposotiry
{
    public class BadgeRepository
    {
        private readonly Dictionary<int, List<string>> _badgeDirectory = new Dictionary<int, List<string>>();
        //CRUD

        //Create
        public bool CreateNewBadge(Badge newBadge)
        {
            int count = _badgeDirectory.Count;
            _badgeDirectory.Add(newBadge.BadgeID, newBadge.DoorNames);

            if (count < _badgeDirectory.Count)
            {
                return true;
            }
            return false;
        }

        //Read
        public Dictionary<int, List<string>> ReadBadges()
        {
            return _badgeDirectory;
        }

        public Badge GetBadgeByBadgeID(int id)
        {
            Badge badgeToReturn = new Badge();

            foreach (KeyValuePair<int, List<string>> badge in _badgeDirectory)
            {
                if (badge.Key == id)
                {
                    badgeToReturn.BadgeID = badge.Key;
                    badgeToReturn.DoorNames = badge.Value;
                }
            }
            return badgeToReturn;
        }

        //Update
        public bool UpdateBadge(int id, Badge newBadge)
        {
            Badge oldBadge = GetBadgeByBadgeID(id);

            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.DoorNames = newBadge.DoorNames;
                return true;
            }
            else
            {
                return false;
            }

        }

        //Delete
        public bool DeleteBadge(Badge badgeToBeDeleted)
        {
            bool hasBeenDeleted = _badgeDirectory.Remove(badgeToBeDeleted.BadgeID);
            return hasBeenDeleted;
        }
    }
}
