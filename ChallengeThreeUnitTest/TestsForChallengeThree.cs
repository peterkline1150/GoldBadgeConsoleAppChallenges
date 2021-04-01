using ChallengeThreeRepo;
using ChallengeThreeReposotiry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThreeUnitTest
{
    [TestClass]
    public class TestsForChallengeThree
    {
        //Arrange
        Badge badgeToTest = new Badge();
        BadgeRepository _badgeRepo = new BadgeRepository();

        [TestMethod]
        public void TestingCreateNewBadgeMethod_ShouldReturnTrue()
        {
            //Act
            bool addBadge = _badgeRepo.CreateNewBadge(badgeToTest);

            //Assert
            Assert.IsTrue(addBadge);
        }
        [TestMethod]
        public void TestingReadBadgesMethod_ShouldReturnTrue()
        {
            //Arrange
            badgeToTest.BadgeID = 12345;
            _badgeRepo.CreateNewBadge(badgeToTest);

            //Act
            Dictionary<int, List<string>> returnedDictionary = _badgeRepo.ReadBadges();
            bool containsRightKey = returnedDictionary.ContainsKey(12345);

            //Assert
            Assert.IsTrue(containsRightKey);
        }

        [TestMethod]
        public void TestingGetBadgeByBadgeID_ShouldReturnCorrectBadge()
        {
            //Arrange
            Badge badgeOne = new Badge(12345, new List<string>() { "A7" });

            _badgeRepo.CreateNewBadge(badgeOne);

            //Act
            Badge returnedBadge = _badgeRepo.GetBadgeByBadgeID(12345);

            //Assert
            Assert.AreEqual(returnedBadge.BadgeID, badgeOne.BadgeID);
            Assert.AreEqual(returnedBadge.DoorNames, badgeOne.DoorNames);
        }
        [TestMethod]
        public void TestingUpdateBadgeMethod_ShouldReturnTrue()
        {
            //Arrange
            Badge oldBadge = new Badge(12345, new List<string>() { "A3, B2"});
            _badgeRepo.CreateNewBadge(oldBadge);

            Badge newBadge = new Badge
            {
                DoorNames = new List<string>() { "A2, B5" }
            };

            //Act
            bool updateTrue = _badgeRepo.UpdateBadge(12345, newBadge);

            //Assert
            Assert.IsTrue(updateTrue);
        }
        [TestMethod]
        public void TestingDeleteBadge_ShouldReturnTrue()
        {
            //Arrange
            Badge badgeToAdd = new Badge(12345, new List<string>() { "C4", "F6" });
            _badgeRepo.CreateNewBadge(badgeToAdd);

            //Act
            bool deletedSuccessfully = _badgeRepo.DeleteBadge(badgeToAdd);

            //Assert
            Assert.IsTrue(deletedSuccessfully);
        }
        [TestMethod]
        public void TestAddDoorMethod()
        {
            //Arrange
            Badge testBadge = new Badge(12345, new List<string>() { "A8" });

            //Act
            bool shouldCorrectlyAddDoor = testBadge.AddDoor("A9");

            //Assert
            Assert.IsTrue(shouldCorrectlyAddDoor);
        }
        [TestMethod]
        public void TestRemoveDoorMethod()
        {
            //Arrange
            Badge testBadge = new Badge(12345, new List<string>() { "A8" });

            //Act
            bool shouldCorrectlyRemoveDoor = testBadge.RemoveDoor("A8");

            //Assert
            Assert.IsTrue(shouldCorrectlyRemoveDoor);
        }
    }
}
