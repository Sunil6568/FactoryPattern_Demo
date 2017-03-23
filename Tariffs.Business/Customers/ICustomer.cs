using ExternalServices;

namespace Tariffs.Business
{
    public interface ICustomer
    {
        decimal GetDiscount(AccountHistory accountHistory);
    }
}
