using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFourRepo
{
    public class OutingRepository
    {
        private readonly List<Outing> _outings = new List<Outing>();

        //CRUD

        //Create
        public bool CreateOuting(Outing newOuting)
        {
            int count = _outings.Count;
            _outings.Add(newOuting);

            if (count < _outings.Count)
            {
                return true;
            }
            return false;
        }

        //Read
        public List<Outing> ReadOutings()
        {
            return _outings;
        }

        //Update - Do not need for this Challenge

        //Delete - Do not need for this challenge
    }
}
