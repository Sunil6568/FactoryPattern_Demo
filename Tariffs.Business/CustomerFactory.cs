using ExternalServices;
using System;

namespace Tariffs.Business
{
    public class CustomerFactory
    {
        #region Public methods
        /// <summary>
        /// Initializes and returns concrete customer based on customer account
        /// </summary>
        /// <param name="customerAccount"></param>
        /// <returns></returns>
        public static ICustomer GetCustomer(CustomerAccount customerAccount)
        {
            var currentDate = DateTime.Now;

            if (customerAccount.CreatedOn.AddYears(3) < currentDate)
                return new GoldCustomer();

            else if (customerAccount.CreatedOn.AddYears(3) >= currentDate
                && customerAccount.CreatedOn.AddYears(2) < currentDate)
                return new SilverCustomer();

            else if (customerAccount.CreatedOn.AddYears(2) >= currentDate
                && customerAccount.CreatedOn.AddYears(1) < currentDate)
                return new BronzeCustomer();

            return new NullCustomer();
        }

        #endregion
    }
}
