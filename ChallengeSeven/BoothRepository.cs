using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSeven
{
    public class BoothRepository
    {
        private readonly List<Party> _partyDirectory = new List<Party>();

        //CRUD

        //Create
        public bool CreateParty(Party partyToAdd)
        {
            int count = _partyDirectory.Count;
            _partyDirectory.Add(partyToAdd);

            if (count < _partyDirectory.Count)
            {
                return true;
            }
            return false;
        }

        //Read
        public List<Party> ReturnParties()
        {
            return _partyDirectory;
        }

        public Party FindPartyByDate(DateTime date)
        {
            foreach (Party party in _partyDirectory)
            {
                if (date == party.DateOfEvent)
                {
                    return party;
                }
            }
            return null;
        }

        //Update - not needed per challenge requirements

        //Delete
        public bool DeleteParty(Party partyToRemove)
        {
            int count = _partyDirectory.Count;
            _partyDirectory.Remove(partyToRemove);

            if (count > _partyDirectory.Count)
            {
                return true;
            }
            return false;
        }
    }
}
