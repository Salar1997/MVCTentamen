using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MVCTentamen.Controllers;

namespace MVCTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateCustomerNotNull()
        {
            CustomerController controller = new CustomerController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void GetCustomerNotNull()
        {
            CustomerController controller = new CustomerController();
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

        }
    }
}
