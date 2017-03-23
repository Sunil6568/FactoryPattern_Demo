using ExternalServices;

namespace Tariffs.Business
{
    public class DiscountCalculator
    {
        public ICustomer Customer { get; set; }

        public DiscountCalculator(ICustomer customer)
        {
            this.Customer = customer;
        }

        #region Public methods
        /// <summary>
        /// Returns highest discount for a given customer
        /// </summary>
        /// <param name="accountHistory"></param>
        /// <param name="customerPackage"></param>
        /// <returns></returns>
        public decimal GetDiscount(AccountHistory accountHistory, Package customerPackage)
        {
            var customerDiscount = Customer.GetDiscount(accountHistory);

            var packageDiscount = this.GetPackageDiscount(customerPackage);

            return customerDiscount > packageDiscount ? customerDiscount : packageDiscount;
        }

        #endregion

        #region Private methods
        private decimal GetPackageDiscount(Package customerPackage)
        {
            if (customerPackage.FuelType == FuelType.DualFuel
                && customerPackage.BroadbandType == BroadbandType.HighSpeed)
                return 10;

            if ((customerPackage.BroadbandType == BroadbandType.Basic && customerPackage.FuelType == FuelType.DualFuel)
                || (customerPackage.BroadbandType == BroadbandType.HighSpeed &&
                 (customerPackage.FuelType == FuelType.Electricity || customerPackage.FuelType == FuelType.Gas)))
                return 5;

            return 0;
        }
        #endregion
    }
}
