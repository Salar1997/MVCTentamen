using MongoDB.Bson;
using MongoDB.Driver;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class Database
    {

        private readonly IMongoDatabase _database;
        private const string CUSTOMER_COLLECTION = "customers";
        private const string ORDER_COLLECTION = "orders";

        internal List<Order> GetAllOrders()
        {
            var collection = _database.GetCollection<Order>(ORDER_COLLECTION);
            return collection.Find(o => true).ToList();
        }

        internal Order GetOrderById(ObjectId orderId)
        {
            var collection = _database.GetCollection<Order>(ORDER_COLLECTION);
            Order order = collection.Find(o => o.Id == orderId).FirstOrDefault();
            return order;
        }

        internal void EditOrder(ObjectId Id, string title, int price)
        {
            var collection = _database.GetCollection<Order>(ORDER_COLLECTION);

            UpdateDefinition<Order> update = Builders<Order>.Update
                .Set(o => o.Title, title)
                .Set(o => o.Price, price);
            collection.UpdateOne(o => o.Id == Id, update);
        }

        internal List<Order> GetOrdersByCustomerId(ObjectId userId)
        {
            var collection = _database.GetCollection<Order>(ORDER_COLLECTION);
            return collection.Find(o => o.CustomerId == userId).ToList();
        }

        internal void DeleteOrder(ObjectId orderId)
        {
            var collection = _database.GetCollection<Order>(ORDER_COLLECTION);
            collection.DeleteOne(o => o.Id == orderId);
        }

        internal void SaveOrder(Order order)
        {
            var collection = _database.GetCollection<Order>(ORDER_COLLECTION);
            collection.InsertOne(order);
        }

        public Database(string dbName = "customer-listDB")
        {
            MongoClient dbClient = new MongoClient();
            _database = dbClient.GetDatabase(dbName);
        }

        internal Customer GetUserById(ObjectId userId)
        {
            var collection = _database.GetCollection<Customer>(CUSTOMER_COLLECTION);
            Customer user = collection.Find(u => u.Id == userId).FirstOrDefault();
            return user;
        }

        internal void SaveUser(Customer user)
        {
            var collection = _database.GetCollection<Customer>(CUSTOMER_COLLECTION);
            collection.InsertOne(user);
        }

        internal void EditUser(ObjectId Id, string firstname, string lastname, int phonenumber, string notes)
        {
            var collection = _database.GetCollection<Customer>(CUSTOMER_COLLECTION);

            UpdateDefinition<Customer> update = Builders<Customer>.Update
                .Set(u => u.Firstname, firstname)
                .Set(u => u.Lastname, lastname)
                .Set(u => u.Phonenumber, phonenumber)
                .Set(u => u.Notes, notes);
            collection.UpdateOne(u => u.Id == Id, update);
        }

        internal void DeleteUser(ObjectId userId)
        {
            var collection = _database.GetCollection<Customer>(CUSTOMER_COLLECTION);
            collection.DeleteOne(u => u.Id == userId);
        }

        internal List<Customer> GetAllUsers()
        {
   
            var collection = _database.GetCollection<Customer>(CUSTOMER_COLLECTION);

            var findResult = collection.Find(m => true);

            return findResult.ToList();
        }

        internal void SetOrderOwner(ObjectId id, ObjectId ownerId)
        {
            var collection = _database.GetCollection<Order>(ORDER_COLLECTION);

            UpdateDefinition<Order> update = Builders<Order>.Update
                .Set(a => a.CustomerId, ownerId);

            collection.UpdateOne(a => a.Id == id, update);
        }
    }
}
