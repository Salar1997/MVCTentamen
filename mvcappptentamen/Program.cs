using Repository;
using Repository.Models;
using System;
using System.Collections.Generic;

namespace mvcappptentamen
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            List<Order> orders = OrderRepository.GetAllOrders();
            
            foreach (Order order in orders)
            {
                count += order.Price;
                
            }
            Console.WriteLine(count);
        }
    }
}
