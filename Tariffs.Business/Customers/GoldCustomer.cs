using ExternalServices;

namespace Tariffs.Business
{
    public class GoldCustomer : ICustomer
    {
        private const decimal _discount = 1;

        public GoldCustomer()
        {

        }

        #region Public methods
        public decimal GetDiscount(AccountHistory accountHistory)
        {
            if (accountHistory.YearlySpend > 1000)
                return 2;

            return _discount;
        }
        #endregion
    }
}
