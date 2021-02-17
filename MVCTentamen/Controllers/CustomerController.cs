using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MVCTentamen.Models;
using Repository;
using Repository.Models;

namespace MVCTentamen.Controllers
{
    public class CustomerController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<Customer> userList = CustomerRepository.GetAllUsers();
            return View(userList);
        }

        // GET: User/Details/5
        public ActionResult Details(string id)
        {
            ObjectId userId = new ObjectId(id);
            OrdersCustomerView ordcustview = new OrdersCustomerView();
            ordcustview.customer = CustomerRepository.GetUserById(userId);
            ordcustview.AllOrders = OrderRepository.GetOrdersByCustomerId(userId);
            
            return View(ordcustview);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string firstname, string lastname, int phonenumber, string notes)
        {
            CustomerRepository.SaveUser(new Customer { Firstname = firstname, Lastname = lastname, Phonenumber = phonenumber, Notes = notes });

            return Redirect("/Customer");
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            ObjectId userId = new ObjectId(id);
            Customer user = CustomerRepository.GetUserById(userId);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, string firstname, string lastname, int phonenumber, string notes)
        {
            ObjectId userId = new ObjectId(id);
            CustomerRepository.EditUser(userId, firstname, lastname, phonenumber, notes);
            return Redirect($"/Customer"); 
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            ObjectId userId = new ObjectId(id);
            Customer user = CustomerRepository.GetUserById(userId);

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ObjectId userId = new ObjectId(id);

                CustomerRepository.DeleteUser(userId);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}