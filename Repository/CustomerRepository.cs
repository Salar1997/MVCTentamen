using MongoDB.Bson;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class CustomerRepository
    {
        public static List<Customer> GetAllUsers()
        {
            Database db = new Database();
            return db.GetAllUsers();
        }

        public static Customer GetUserById(ObjectId userId)
        {
            Database db = new Database();
            return db.GetUserById(userId);
        }

        public static void SaveUser(Customer user)
        {
            Database db = new Database();
            db.SaveUser(user);
        }

        public static void EditUser(ObjectId userId, string firstname, string lastname, int phonenumber, string notes)
        {
            Database db = new Database();
            db.EditUser(userId, firstname, lastname, phonenumber, notes);
        }

        public static void DeleteUser(ObjectId userId)
        {
            Database db = new Database();
            db.DeleteUser(userId);
        }
    }
}
