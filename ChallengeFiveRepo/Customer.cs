using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFiveRepo
{
    public enum CustomerType { Past, Current, Potential }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Email { get
            {
                switch (CustomerType)
                {
                    case CustomerType.Current:
                        return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    case CustomerType.Potential:
                        return "We currently have the lowest rates on Helicopter Insurance!";
                    case CustomerType.Past:
                        return "It's been a long time since we've heard from you, we want you back.";
                    default:
                        return "That's weird, this shouldn't happen!";
                }
            }
        }
        public Customer()
        {

        }
        public Customer(string firstName, string lastName, CustomerType customerType)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerType = customerType;
        }
    }
}
