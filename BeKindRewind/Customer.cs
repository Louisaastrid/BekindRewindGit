using System;
using System.Collections.Generic;
using System.Text;

namespace BeKindRewind
{
    class Customer
    {
        public int IdCustomer { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Address_Id { get; set; }
        public Customer()
        {
        }
        public Customer(int idCustomer, string firstName, string lastName, string email, string addressId)
        {
            IdCustomer = idCustomer;
            First_Name = firstName;
            Last_Name = lastName;
            Email = email;
            Address_Id = addressId;
        }
    }
}
