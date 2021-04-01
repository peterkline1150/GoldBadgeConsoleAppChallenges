using ChallengeThreeRepo;
using ChallengeThreeReposotiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeConsole
{
    public class ChallengeThreeUI
    {
        private readonly BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            SeedBadges();
            Start();
        }

        private void Start()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();

                Console.WriteLine("Hello Security Admin, What would you like to do?\n\n" +
                    "1. Add a badge.\n" +
                    "2. Edit a badge.\n" +
                    "3. List all badges.\n" +
                    "4. Remove Badge.\n" +
                    "5. Remove all doors from a certain Badge.\n" +
                    "6. Exit.");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadges();
                        break;
                    case "4":
                        RemoveBadgeFromDictionary();
                        break;
                    case "5":
                        RemoveAllDoors();
                        break;
                    case "6":
                        Console.WriteLine("You may now exit the console.\n");
                        continueRunning = false;
                        PressAnyKey();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.\n");
                        PressAnyKey();
                        break;
                }
            }
        }

        private void RemoveAllDoors()
        {
            Console.Clear();
            Console.Write("What is the badge number to remove doors from? ");
            int badgeNumber = int.Parse(Console.ReadLine());

            Badge badgeToRemoveDoorsFrom = _badgeRepo.GetBadgeByBadgeID(badgeNumber);

            if (badgeToRemoveDoorsFrom != null)
            {
                foreach (string door in badgeToRemoveDoorsFrom.DoorNames.ToList())
                {
                    badgeToRemoveDoorsFrom.RemoveDoor(door);
                }

                Console.WriteLine($"\nAll doors have been removed from {badgeToRemoveDoorsFrom.BadgeID}.\n");
            }
            else
            {
                Console.WriteLine("Incorrect badge number. Returning to main menu.\n");
            }
            PressAnyKey();
        }

        private void RemoveBadgeFromDictionary()
        {
            Console.Clear();
            Console.Write("What is the badge number to delete? ");
            int badgeNumber = int.Parse(Console.ReadLine());

            Badge badgeToDelete = _badgeRepo.GetBadgeByBadgeID(badgeNumber);

            if (badgeToDelete != null && _badgeRepo.DeleteBadge(badgeToDelete))
            {
                Console.WriteLine($"{badgeToDelete.BadgeID} has been successfully deleted.\n");
            }
            else
            {
                Console.WriteLine("Could not delete badge. Returning to main menu.\n");
            }
            PressAnyKey();
        }

        private void ListBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> dictionaryOfBadges = _badgeRepo.ReadBadges();

            Console.WriteLine("Key\n");
            Console.WriteLine(String.Format("{0,-15}{1,-15}",
                "Badge #",
                "Door Access"));
            foreach (KeyValuePair<int, List<string>> badge in dictionaryOfBadges)
            {
                string doors = string.Join(", ", badge.Value);

                Console.WriteLine(String.Format("{0,-15}{1,-15}",
                    $"{badge.Key}",
                    $"{doors}"));

            }
            PressAnyKey();
        }

        private void AddBadge()
        {
            Console.Clear();
            Badge badgeToAdd = new Badge();

            Console.Write("What is the number on the Badge: ");
            badgeToAdd.BadgeID = int.Parse(Console.ReadLine());

            bool continueAddingDoors = true;
            while (continueAddingDoors)
            {
                Console.Write("List a door that it needs access to: ");
                string doorToAdd = Console.ReadLine();
                badgeToAdd.AddDoor(doorToAdd);

                Console.WriteLine("Any other doors(y/n)?");
                string choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "y":
                        break;
                    case "n":
                        Console.WriteLine("Done adding doors. Returning to main menu.\n");
                        continueAddingDoors = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Returning to main menu.\n");
                        continueAddingDoors = false;
                        break;
                }
            }
            _badgeRepo.CreateNewBadge(badgeToAdd);
            PressAnyKey();
        }

        private void EditBadge()
        {
            Console.Clear();
            Console.Write("What is the badge number to update? ");
            int badgeNumber = int.Parse(Console.ReadLine());

            Badge badgeToUpdate = _badgeRepo.GetBadgeByBadgeID(badgeNumber);
            if (badgeToUpdate != null)
            {
                DisplayDoors(badgeToUpdate);

                Console.WriteLine("What would you like to do?\n\n" +
                    "1. Remove a door\n" +
                    "2. Add a door");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RemoveDoorFromBadge(badgeToUpdate);
                        break;
                    case "2":
                        AddDoorToBadge(badgeToUpdate);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Returning to main menu.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("That badge does not exist. Returning to main menu.\n");
            }
            PressAnyKey();
        }

        private void RemoveDoorFromBadge(Badge badgeToRemoveFrom)
        {
            Console.Write("Which door would you like to remove? ");
            string doorToRemove = Console.ReadLine();

            badgeToRemoveFrom.RemoveDoor(doorToRemove);

            Console.WriteLine("Door removed.\n");

            DisplayDoors(badgeToRemoveFrom);
        }

        private void AddDoorToBadge(Badge badgeToAddTo)
        {
            Console.Write("Which door would you like to add? ");
            string doorToAdd = Console.ReadLine();

            badgeToAddTo.AddDoor(doorToAdd);

            DisplayDoors(badgeToAddTo);
        }

        private void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
        }

        private void DisplayDoors(Badge badgeToDisplayDoors)
        {
            if (badgeToDisplayDoors.DoorNames.Count == 0)
            {
                Console.WriteLine($"{badgeToDisplayDoors.BadgeID} doesn't have access to any doors.\n");
            }
            else
            {
                string doors = string.Join(" & ", badgeToDisplayDoors.DoorNames);

                Console.WriteLine($"{badgeToDisplayDoors.BadgeID} has access to doors {doors}.\n");
            }
        }

        private void SeedBadges()
        {
            Badge badgeOne = new Badge(12345, new List<string>() { "A7" });
            Badge badgeTwo = new Badge(22345, new List<string>() { "A1", "A4", "B1", "B2" });
            Badge badgeThree = new Badge(32345, new List<string>() { "A4", "A5" });

            _badgeRepo.CreateNewBadge(badgeOne);
            _badgeRepo.CreateNewBadge(badgeTwo);
            _badgeRepo.CreateNewBadge(badgeThree);
        }
    }
}
