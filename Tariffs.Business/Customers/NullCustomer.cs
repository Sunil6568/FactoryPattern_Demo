using ExternalServices;

namespace Tariffs.Business
{
    public class NullCustomer : ICustomer
    {
        private const decimal _discount = 0;

        public NullCustomer()
        {

        }

        #region Public methods
        public decimal GetDiscount(AccountHistory accountHistory)
        {
            return _discount;
        }
        #endregion
    }
}
