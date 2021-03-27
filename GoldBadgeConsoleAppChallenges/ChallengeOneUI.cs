using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeConsoleAppChallenges
{
    public class ChallengeOneUI
    {
        private readonly MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SeedMenuItems();
            Start();
        }

        private void Start()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                
                Console.WriteLine("Welcome to the Komodo Cafe Menu Management System!\n\n" +
                    "What would you like to do?\n" +
                    "1: View the menu\n" +
                    "2: Add an item to the menu\n" +
                    "3: Delete an item from the menu\n" +
                    "4: Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewMenu();
                        break;
                    case "2":
                        AddMenuItem();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        Console.WriteLine("Thank you! You may exit now.\n");
                        continueToRun = false;
                        PressAnyKey();
                        break;
                    default:
                        Console.WriteLine("Invalid input.\n");
                        PressAnyKey();
                        break;
                }
            }
        }
        private void ViewMenu()
        {
            Console.Clear();

            List<Menu> listOfItems = _menuRepo.ReadMenuItems();
            int count = 0;

            foreach (Menu item in listOfItems)
            {
                count++;
                Console.WriteLine($"Meal Number: {item.MealNumber}\n"+
                    $"Name: {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Price: ${item.Price}\n" +
                    "Ingredients in menu item:\n");
                foreach (string ingredient in item.Ingredients)
                {
                    Console.WriteLine($"{ingredient}\n");
                }
                Console.WriteLine("\n");
            }
            PressAnyKey();
        }

        private void AddMenuItem()
        {
            Console.Clear();

            Menu itemToAdd = new Menu();
            Console.WriteLine("Enter the name of the dish:\n");
            itemToAdd.MealName = Console.ReadLine();
            Console.WriteLine("\nEnter the menu number of the dish:\n");
            itemToAdd.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter a description of the dish:\n");
            itemToAdd.Description = Console.ReadLine();
            Console.WriteLine("\nEnter the price of the dish:\n");
            itemToAdd.Price = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the number of ingredients you wish to add:\n");
            int numIngredients = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 0; i < numIngredients; i++)
            {
                count++;
                Console.WriteLine($"\nPlease enter ingredient #{count}:\n");
                itemToAdd.AddIngredientsToList(Console.ReadLine());
            }

            _menuRepo.AddMenuItem(itemToAdd);

            Console.WriteLine($"\n {itemToAdd.MealName} has been successfully added to the menu.\n");
            PressAnyKey();
        }
        private void DeleteMenuItem()
        {
            Console.Clear();

            List<Menu> listOfItems = _menuRepo.ReadMenuItems();

            Console.WriteLine("Please enter the Number you wish to delete:\n");
            int count = 0;
            foreach (Menu item in listOfItems)
            {
                count++;
                Console.WriteLine($"{count}: {item.MealName}\n");
            }

            int targetItemIndex = int.Parse(Console.ReadLine()) - 1;
            Menu itemToDelete = listOfItems[targetItemIndex];

            if (_menuRepo.DeleteMenuItem(itemToDelete))
            {
                Console.WriteLine($"{itemToDelete.MealName} was successfully removed.\n");
            }
            else
            {
                Console.WriteLine("Something went wrong. Please try again.\n");
            }
            PressAnyKey();
        }
        private void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
        }
        private void SeedMenuItems()
        {
            List<string> ingredientsForSeededItems = new List<string>
            {
                "Lettuce",
                "Tomato",
                "Ground Beef",
                "Bread",
                "Salt"
            };

            Menu seededItemOne = new Menu(1, "Spaghetti", "Good noodles", ingredientsForSeededItems, 20);
            Menu seededItemTwo = new Menu(2, "Beef Stew", "Yummy", ingredientsForSeededItems, 15);
            Menu seededItemThree = new Menu(3, "Mashed Potatoes", "Very creamy", ingredientsForSeededItems, 10);

            _menuRepo.AddMenuItem(seededItemOne);
            _menuRepo.AddMenuItem(seededItemTwo);
            _menuRepo.AddMenuItem(seededItemThree);
        }
    }
}
