using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using MVCTentamen.Models;
using Repository;
using Repository.Models;

namespace MVCTentamen.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            List<Order> orderList = OrderRepository.GetAllOrders();

            return View(orderList);
        }

        // GET: Order/Details/5
        public ActionResult Details(string id)
        {
            ObjectId orderId = new ObjectId(id);
            Order order = OrderRepository.GetOrderById(orderId);
            ViewOfOrdCust ordcustview = new ViewOfOrdCust();
            ordcustview.order = order;
            ordcustview.customer = CustomerRepository.GetUserById(order.CustomerId);
            return View(ordcustview);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            viewModel vm = new viewModel();
            return View(vm);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string customerId, Order order)
        {
            ObjectId customId = new ObjectId(customerId);
            order.CustomerId = customId;

            OrderRepository.SaveOrder(order);
            return Redirect("/Order");
        }

        // GET: Order/Edit/5
        public ActionResult Edit(string id)
        {
            ObjectId orderId = new ObjectId(id);
            Order order = OrderRepository.GetOrderById(orderId);

            return View(order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, string title, int price)
        {
            ObjectId orderId = new ObjectId(id);
            OrderRepository.EditOrder(orderId, title, price);
            return Redirect("/Order");
        }

        // GET: Order/Delete/5
        public ActionResult Delete(string id)
        {
            ObjectId orderId = new ObjectId(id);
            Order order = OrderRepository.GetOrderById(orderId);

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                ObjectId orderId = new ObjectId(id);
                OrderRepository.DeleteOrder(orderId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Route("/Order/{id}/setOwner")]
        public IActionResult OrderOwner(string id)
        {
            List<Customer> customers = CustomerRepository.GetAllUsers();

            return View(customers);
        }

        [HttpPost]
        [Route("/Order/{id}/SetOwner")]
        public IActionResult SetOwner(string id, string customerId)
        {
            ObjectId orderId = new ObjectId(id);
            ObjectId ownerId = new ObjectId(customerId);

            OrderRepository.OrderOwner(orderId, ownerId);
            return Redirect("/Orders");

        }
    }
}