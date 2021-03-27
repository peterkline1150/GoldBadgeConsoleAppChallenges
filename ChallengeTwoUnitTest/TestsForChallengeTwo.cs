using ChallengeTwoRepo;
using ChallengeTwoRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
    }
}
