using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTentamen.Models
{
    public class viewModel
    {
        public List<Customer> AllCustomers { get; set; } = CustomerRepository.GetAllUsers();
        public Order Order { get; set; }
    }
}
