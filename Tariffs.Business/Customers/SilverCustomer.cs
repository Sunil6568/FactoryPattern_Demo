using ExternalServices;

namespace Tariffs.Business
{
    public class SilverCustomer : ICustomer
    {
        private const decimal _discount = 0.5M;

        public SilverCustomer()
        {

        }

        #region Public methods

        /// <summary>
        /// Retuens discount for Silver customer
        /// </summary>
        /// <param name="accountHistory"></param>
        /// <returns></returns>
        public decimal GetDiscount(AccountHistory accountHistory)
        {
            if (accountHistory.YearlySpend > 2000)
                return 2;

            return _discount;
        }

        #endregion
    }
}
