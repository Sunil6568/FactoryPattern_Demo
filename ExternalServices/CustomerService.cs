using System;

namespace ExternalServices
{
    public interface ICustomerService
    {
        CustomerAccount GetAccount(string id);
    }

    public class CustomerAccount
    {
        public string AccountId { get; set; }
        public DateTime CreatedOn { get; set; }
    }

}