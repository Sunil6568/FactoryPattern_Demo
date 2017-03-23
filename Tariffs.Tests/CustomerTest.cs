using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tariffs.Business;
using ExternalServices;

namespace Tariffs.Tests
{
    [TestClass]
    public class CustomerTest
    {
        #region Test to create GoldCustomer
       
        [TestMethod]
        public void TestForCreatingGoldCustomer()
        {
            var customer = CustomerFactory.GetCustomer(new CustomerAccount { CreatedOn = new DateTime(2014, 3, 3) });

            Assert.IsInstanceOfType(customer, typeof(GoldCustomer));
        }
        #endregion

        #region Test for creating SilverCustomer

       [TestMethod]
        public void TestForCreatingSilverCustomer()
        {
            var customer = CustomerFactory.GetCustomer(new CustomerAccount { CreatedOn = new DateTime(2014, 4, 1) });

            Assert.IsInstanceOfType(customer, typeof(SilverCustomer));

            customer = CustomerFactory.GetCustomer(new CustomerAccount { CreatedOn = new DateTime(2015, 3, 5) });

            Assert.IsInstanceOfType(customer, typeof(SilverCustomer));
        }

        #endregion

        #region Test for creating Bronze Customer

        [TestMethod]
        public void TestForCreatingBronzeCustomer()
        {
            var customer = CustomerFactory.GetCustomer(new CustomerAccount { CreatedOn = new DateTime(2015, 4, 6) });

            Assert.IsInstanceOfType(customer, typeof(BronzeCustomer));

            customer = CustomerFactory.GetCustomer(new CustomerAccount { CreatedOn = new DateTime(2016, 3, 5) });

            Assert.IsInstanceOfType(customer, typeof(BronzeCustomer));
        }

        #endregion
    }
}
