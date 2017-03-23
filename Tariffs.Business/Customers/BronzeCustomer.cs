using ExternalServices;

namespace Tariffs.Business
{
    public class BronzeCustomer : ICustomer
    {
        private const decimal _discount = 0.25M;

        public BronzeCustomer()
        {

        }

        #region Public methods
        /// <summary>
        /// Returns discount for Gold customer
        /// </summary>
        /// <param name="accountHistory"></param>
        /// <returns></returns>
        public decimal GetDiscount(AccountHistory accountHistory)
        {
            if (accountHistory.YearlySpend > 3000)
                return 1;

            return _discount;
        }
        #endregion
    }
}
