using ChallengeTwoRepo;
using ChallengeTwoRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwoUnitTest
{
    [TestClass]
    public class TestsForChallengeTwo
    {
        //Arrange
        ClaimRepository _claimRepo = new ClaimRepository();
        Claim claim = new Claim();

        [TestMethod]
        public void TestingCreateClaimMethod_ShouldReturnTrue()
        {
            //Act
            bool shouldBeTrue = _claimRepo.CreateClaim(claim);

            //Assert
            Assert.IsTrue(shouldBeTrue);
        }
        [TestMethod]
        public void TestingReadClaimsMethod_ShouldContainClaim()
        {
            //Arrange
            _claimRepo.CreateClaim(claim);

            //Act
            Queue<Claim> claims = _claimRepo.ReadClaims();

            bool queueHasClaims = claims.Contains(claim);

            //Assert
            Assert.IsTrue(queueHasClaims);
        }
        [TestMethod]
        public void TestingPeekClaimMethod_ShouldReturnValidClaim()
        {
            //Arrange
            _claimRepo.CreateClaim(claim);

            //Act
            Claim claimToPeek = _claimRepo.PeekClaim();

            //Assert
            Assert.AreEqual(claimToPeek, claim);
        }
        [TestMethod]
        public void TestDequeueClaimMethod_ShouldReturnTrue()
        {
            //Arrange
            _claimRepo.CreateClaim(claim);

            //Act
            bool shouldBeTrue = _claimRepo.DequeueClaim();

            //Assert
            Assert.IsTrue(shouldBeTrue);
        }
    }
}
