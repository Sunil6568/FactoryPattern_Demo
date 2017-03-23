using System;

namespace ExternalServices.Stubs
{
    public class CustomerServiceStub : ICustomerService
    {
        public CustomerAccount GetAccount(string id)
        {
            return new CustomerAccount();
        }
    }
}