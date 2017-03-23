using System;

namespace ExternalServices.Stubs
{
    public class AccountsServiceStub : IAccountsService
    {
        public AccountHistory GetAccountHistory(string accountId)
        {
            return new AccountHistory();
        }
    }
}