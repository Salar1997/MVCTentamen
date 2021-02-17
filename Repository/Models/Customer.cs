using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models
{
    public class Customer
    {
        public ObjectId Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Phonenumber  { get; set; }
        public string Notes { get; set; }
        public List<ObjectId> OrderIds { get; set; }

      
    }
}
