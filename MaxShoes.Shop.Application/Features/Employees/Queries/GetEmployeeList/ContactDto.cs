using System;
using System.Collections.Generic;
using System.Text;

namespace MaxShoes.Shop.Application.Features.Employees.Queries.GetEmployeeList
{
    public class ContactDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
    }
}
