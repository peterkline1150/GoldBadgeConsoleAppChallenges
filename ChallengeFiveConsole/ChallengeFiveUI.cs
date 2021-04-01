using ChallengeFiveRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiveConsole
{
    public class ChallengeFiveUI
    {
        private readonly CustomerRepository _customerRepo = new CustomerRepository();
        public void Run()
        {
            SeedCustomers();
            Start();
        }

        private void Start()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the customer viewing UI. What would you like to do?\n" +
                    "1. Add a customer.\n" +
                    "2. Show a list of all customers alphabetically.\n" +
                    "3. Update a customer.\n" +
                    "4. Remove a customer.\n" +
                    "5. Exit\n");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        ShowCustomers();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        RemoveCustomer();
                        break;
                    case "5":
                        Console.WriteLine("You may now exit the console.\n");
                        continueRunning = false;
                        PressAnyKey();
                        break;
                    default:
                        break;
                }
            }
        }

        private void RemoveCustomer()
        {
            Console.Clear();

            Console.WriteLine("Enter the First Name of the customer you want to delete:");
            string firstName = Console.ReadLine();
            Console.WriteLine("\nEnter the Last Name of the customer you want to delete:");
            string lastName = Console.ReadLine();

            Customer customerToDelete = _customerRepo.ReadCustomerByFirstAndLastName(firstName, lastName);

            if (_customerRepo.DeleteCustomer(customerToDelete))
            {
                Console.WriteLine("Customer removed successfully.\n");
            }
            else
            {
                Console.WriteLine("Customer was not removed successfully. Returning to main menu.\n");
            }
            PressAnyKey();
        }

        private void UpdateCustomer()
        {
            Console.Clear();

            Customer customerToUpdate = new Customer();
            Console.Write("Enter the First Name of the customer you want to update: ");
            customerToUpdate.FirstName = Console.ReadLine();
            Console.Write("\nEnter the Last Name of the customer you want to update: ");
            customerToUpdate.LastName = Console.ReadLine();

            bool keepAsking;
            do
            {
                keepAsking = false;

                //Originally allowed to update name, but your name doesn't change. That seemed redundant, so I took it out.
                Console.WriteLine("\nChoose the customer's updated type:\n" +
                    "1. Potential customer\n" +
                    "2. Current customer\n" +
                    "3. Past customer");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        customerToUpdate.CustomerType = CustomerType.Potential;
                        break;
                    case "2":
                        customerToUpdate.CustomerType = CustomerType.Current;
                        break;
                    case "3":
                        customerToUpdate.CustomerType = CustomerType.Past;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option.\n");
                        keepAsking = true;
                        break;
                }
            } while (keepAsking);

            if (_customerRepo.UpdateCustomer(customerToUpdate.FirstName, customerToUpdate.LastName, customerToUpdate))
            {
                Console.WriteLine("Customer Updated Successfully.\n");
            }
            else
            {
                Console.WriteLine("Customer not updated successfully. Returning to main menu.\n");
            }
            PressAnyKey();
        }

        private void ShowCustomers()
        {
            Console.Clear();

            List<Customer> currentCustomers = _customerRepo.ReadCustomers();
            currentCustomers.Sort((x, y) => x.FirstName.CompareTo(y.FirstName));

            Console.WriteLine("Here is a list of our customers:\n\n");
            Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,-20}",
                "First Name",
                "Last Name",
                "Type",
                "Email\n"));
            foreach (Customer customer in currentCustomers)
            {
                Console.WriteLine(String.Format("{0,-20}{1,-20}{2,-20}{3,-20}",
                    $"{customer.FirstName}",
                    $"{customer.LastName}",
                    $"{customer.CustomerType}",
                    $"{customer.Email}"));
            }
            PressAnyKey();
        }

        private void AddCustomer()
        {
            Console.Clear();
            Customer newCustomer = AskAboutCustomer();

            if (_customerRepo.CreateCustomer(newCustomer))
            {
                Console.WriteLine("Customer created successfully.\n");
            }
            else
            {
                Console.WriteLine("Sorry, something went wrong.\n");
            }
            PressAnyKey();
        }

        private Customer AskAboutCustomer()
        {
            Customer newCustomer = new Customer();

            Console.Write("Enter the customer's First Name: ");
            newCustomer.FirstName = Console.ReadLine();
            Console.Write("\nEnter the customer's Last Name: ");
            newCustomer.LastName = Console.ReadLine();

            bool keepAsking;
            do
            {
                keepAsking = false;

                Console.WriteLine("\nChoose the customer type:\n" +
                "1. Potential customer\n" +
                "2. Current customer\n" +
                "3. Past customer");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        newCustomer.CustomerType = CustomerType.Potential;
                        break;
                    case "2":
                        newCustomer.CustomerType = CustomerType.Current;
                        break;
                    case "3":
                        newCustomer.CustomerType = CustomerType.Past;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option.\n");
                        keepAsking = true;
                        break;
                }
            } while (keepAsking);
            return newCustomer;
        }

        private void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
        }

        private void SeedCustomers()
        {
            Customer customerOne = new Customer("Jake", "Smith", CustomerType.Potential);
            Customer customerTwo = new Customer("James", "Smith", CustomerType.Current);
            Customer customerThree = new Customer("Jane", "Smith", CustomerType.Past);

            _customerRepo.CreateCustomer(customerThree);
            _customerRepo.CreateCustomer(customerOne);
            _customerRepo.CreateCustomer(customerTwo);
        }
    }
}
