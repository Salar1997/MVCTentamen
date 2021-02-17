using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTentamen.Models
{
    public class ViewOfOrdCust
    {
        public Customer customer { get; set; }
        public Order order { get; set; }
    }
}
