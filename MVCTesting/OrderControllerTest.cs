using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MVCTentamen.Controllers;

namespace MVCTesting
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void CreateOrderNotNull()
        {
            OrderController controller = new OrderController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void GetAllOrdersNotNull()
        {
            OrderController controller = new OrderController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

        }
    }
}
