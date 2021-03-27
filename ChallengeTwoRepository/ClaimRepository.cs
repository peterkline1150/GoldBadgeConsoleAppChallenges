using ChallengeTwoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepository
{
    public class ClaimRepository
    {
        private readonly Queue<Claim> _queueOfClaims = new Queue<Claim>();

        //CRUD

        //Create
        public bool CreateClaim(Claim newClaim)
        {
            int count = _queueOfClaims.Count;
            _queueOfClaims.Enqueue(newClaim);

            if (count < _queueOfClaims.Count)
            {
                return true;
            }
            return false;
        }
    }
}
