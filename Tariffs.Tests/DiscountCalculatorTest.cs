using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tariffs.Business;
using ExternalServices;

namespace Tariffs.Tests
{
    [TestClass]
    public class DiscountCalculatorTest
    {
        #region Gold Customer Tests
        
        [TestMethod]
        public void TestDiscountForGoldCustomerSpedingMoreThan1000()
        {
            var customer = new GoldCustomer();
            var accountHistory = new AccountHistory { YearlySpend = 1001 };

            var discountCalculator = new DiscountCalculator(customer);
            var customerPackage = new Package();

            var discount = discountCalculator.GetDiscount(accountHistory, customerPackage);

            Assert.IsTrue(discount == 2);
        }

        [TestMethod]
        public void TestDiscountForGoldCustomerOnly()
        {
            var customer = new GoldCustomer();
            var accountHistory = new AccountHistory { YearlySpend = 1000 };

            var discountCalculator = new DiscountCalculator(customer);
            var customerPackage = new Package();

            var discount = discountCalculator.GetDiscount(accountHistory, customerPackage);

            Assert.IsTrue(discount == 1);
        }

        [TestMethod]
        public void TestDiscountForGoldCustomerForPackageType()
        {
            var customer = new GoldCustomer();
            var accountHistory = new AccountHistory { YearlySpend = 1000 };

            var discountCalculator = new DiscountCalculator(customer);
            var customerPackage = new Package { BroadbandType = BroadbandType.HighSpeed, FuelType = FuelType.DualFuel };

            var discount = discountCalculator.GetDiscount(accountHistory, customerPackage);

            Assert.IsTrue(discount == 10);
        }

        #endregion

        #region Silver Customer Tests

        [TestMethod]
        public void TestDiscountForSliverCustomerSpendingMoreThan2000()
        {
            var customer = new SilverCustomer();
            var accountHistory = new AccountHistory { YearlySpend = 2001 };

            var discountCalculator = new DiscountCalculator(customer);
            var customerPackage = new Package();

            var discount = discountCalculator.GetDiscount(accountHistory, customerPackage);

            Assert.IsTrue(discount == 2);
        }

        [TestMethod]
        public void TestDiscountForSliverCustomerOnly()
        {
            var customer = new SilverCustomer();
            var accountHistory = new AccountHistory { YearlySpend = 1000 };

            var discountCalculator = new DiscountCalculator(customer);
            var customerPackage = new Package();

            var discount = discountCalculator.GetDiscount(accountHistory, customerPackage);

            Assert.IsTrue(discount == 0.5M);
        }
        #endregion

        #region Tests For Bronze Customers

        [TestMethod]
        public void TestDiscountForBronzeCustomerSpendingMoreThan3000()
        {
            var customer = new BronzeCustomer();
            var accountHistory = new AccountHistory { YearlySpend = 3001 };

            var discountCalculator = new DiscountCalculator(customer);
            var customerPackage = new Package();

            var discount = discountCalculator.GetDiscount(accountHistory, customerPackage);
           
            Assert.IsTrue(discount == 1);
        }

        [TestMethod]
        public void TestDiscountForBronzeCustomerOnly()
        {
            var customer = new BronzeCustomer();
            var accountHistory = new AccountHistory { YearlySpend = 1500 };

            var discountCalculator = new DiscountCalculator(customer);
            var customerPackage = new Package();

            var discount = discountCalculator.GetDiscount(accountHistory, customerPackage);
           
            Assert.IsTrue(discount == 0.25M);

        }

        #endregion

        #region Tests for General Customers

        [TestMethod]
        public void TestDiscountForGeneralCustomerSpendingBelow500()
        {
            var customer = new NullCustomer();
            var accountHistory = new AccountHistory { YearlySpend = 1500 };

            var discountCalculator = new DiscountCalculator(customer);
            var customerPackage = new Package();

            var discount = discountCalculator.GetDiscount(accountHistory, customerPackage);
           
            Assert.IsTrue(discount == 0);
        }
        #endregion

    }
}
