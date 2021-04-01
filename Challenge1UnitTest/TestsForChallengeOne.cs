using GoldBadgeConsoleAppChallenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge1UnitTest
{
    [TestClass]
    public class TestsForChallengeOne
    {
        //AAA - Assemble, Act, Assert

        //Arrange
        Menu menuItem = new Menu();
        MenuRepository _menuRepository = new MenuRepository();

        [TestMethod]
        public void TestingAddMenuItemInMenuRepo_ShouldReturnTrue()
        {
            //Act
            bool wasAddedCorrectly = _menuRepository.AddMenuItem(menuItem);

            //Assert
            Assert.IsTrue(wasAddedCorrectly);
        }
        [TestMethod]
        public void TestingReadMenuItemsInMenuRepository_ShouldReturnTrue()
        {
            //Arrange
            _menuRepository.AddMenuItem(menuItem);
            List<Menu> listOfMenuItems = _menuRepository.ReadMenuItems();

            //Act
            bool directoryHasMenuItems = listOfMenuItems.Contains(menuItem);

            //Assert
            Assert.IsTrue(directoryHasMenuItems);
        }
        [TestMethod]
        public void TestingDeleteMenuItem_ShouldReturnTrue()
        {
            //Arrange
            _menuRepository.AddMenuItem(menuItem);

            //Act
            bool wasRemoved = _menuRepository.DeleteMenuItem(menuItem);

            //Assert
            Assert.IsTrue(wasRemoved);
        }
        [TestMethod]
        public void TestingAddIngredientMethod_ShouldReturnTrue()
        {
            //Act
            bool shouldAddIngredient = menuItem.AddIngredientsToList("Potato");

            //Assert
            Assert.IsTrue(shouldAddIngredient);
        }
    }
}
