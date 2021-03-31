using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiveRepo
{
    public class CustomerRepository
    {
        private readonly List<Customer> _customerDirectory = new List<Customer>();

        //CRUD

        //Create
        public bool CreateCustomer(Customer customerToCreate)
        {
            int count = _customerDirectory.Count;
            _customerDirectory.Add(customerToCreate);

            if (count < _customerDirectory.Count)
            {
                return true;
            }
            return false;
        }

        //Read
        public List<Customer> ReadCustomers()
        {
            return _customerDirectory;
        }

        public Customer ReadCustomerByFirstAndLastName(string firstName, string lastName)
        {
            foreach (Customer customer in _customerDirectory)
            {
                if (firstName == customer.FirstName && lastName == customer.LastName)
                {
                    return customer;
                }
            }
            return null;
        }

        //Update
        public bool UpdateCustomer(string firstName, string lastName, Customer newCustomer)
        {
            Customer customerToUpdate = ReadCustomerByFirstAndLastName(firstName, lastName);

            if (customerToUpdate != null)
            {
                customerToUpdate.CustomerType = newCustomer.CustomerType;
                customerToUpdate.FirstName = newCustomer.FirstName;
                customerToUpdate.LastName = newCustomer.LastName;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteCustomer(Customer customerToBeDeleted)
        {
            int count = _customerDirectory.Count;
            _customerDirectory.Remove(customerToBeDeleted);

            if (count > _customerDirectory.Count)
            {
                return true;
            }
            return false;
        }
    }
}
