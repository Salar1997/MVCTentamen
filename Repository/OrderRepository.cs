using MongoDB.Bson;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class OrderRepository
    {
        public static List<Order> GetAllOrders()
        {
            Database db = new Database();
            return db.GetAllOrders();
        }

        public static Order GetOrderById(ObjectId orderId)
        {
            Database db = new Database();
            return db.GetOrderById(orderId);
        }

        public static void SaveOrder(Order order)
        {
            Database db = new Database();
            db.SaveOrder(order);
        }

        public static void EditOrder(ObjectId orderId, string title, int price)
        {
            Database db = new Database();
            db.EditOrder(orderId, title, price);
        }

        public static void DeleteOrder(ObjectId orderId)
        {
            Database db = new Database();
            db.DeleteOrder(orderId);
        }

        public static List<Order> GetOrdersByCustomerId(ObjectId userId)
        {
            Database db = new Database();
            return db.GetOrdersByCustomerId(userId);
        }

        public static void OrderOwner(ObjectId orderId, ObjectId ownerId)
        {
            Database db = new Database();
            db.SetOrderOwner(orderId, ownerId);
        }
    }
}
