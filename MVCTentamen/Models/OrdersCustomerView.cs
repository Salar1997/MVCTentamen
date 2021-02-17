using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTentamen.Models
{
    public class OrdersCustomerView
    {
        public List<Order> AllOrders { get; set; } = OrderRepository.GetAllOrders();
        public Customer customer { get; set; }
    }
}
