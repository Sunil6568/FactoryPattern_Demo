using System;
using System.Web.Mvc;
using ExternalServices;
using Tariffs.Business;

namespace Tariffs
{
    public class DiscountController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountsService _accountsService;
        private readonly IPackageService _packageService;

        public DiscountController(ICustomerService customerService, IAccountsService accountsService, IPackageService packageService)
        {
            _customerService = customerService;
            _accountsService = accountsService;
            _packageService = packageService;
        }

        [HttpGet]
        [Route("customers/{id}/discount")]
        public decimal GetCustomerDiscount(string id)
        {
            var customerAccount = _customerService.GetAccount(id);
            var accountPaymentHistory = _accountsService.GetAccountHistory(customerAccount.AccountId);
            var customerPackage = _packageService.GetPackage(id);

            //Get customer
            var customer = CustomerFactory.GetCustomer(customerAccount);

            //Initialize DiscountCalculator by providing customer
            var discountCalculator = new DiscountCalculator(customer);

            //Get highest applicable discount
            var discount = discountCalculator.GetDiscount(accountPaymentHistory, customerPackage);

            return discount;
        }

        //[HttpGet]
        //[Route("customers/{id}/discount")]
        //public decimal GetCustomerDiscount(string id)
        //{
        //    var customerAccount = _customerService.GetAccount(id);
        //    var accountPaymentHistory = _accountsService.GetAccountHistory(customerAccount.AccountId);
        //    var customerPackage = _packageService.GetPackage(id);

        //    if (customerAccount.CreatedOn.AddYears(1) <= DateTime.Now ||
        //        (accountPaymentHistory.YearlySpend >= 500 && accountPaymentHistory.YearlySpend <= 1000))
        //        return 0.25M;

        //    if (customerAccount.CreatedOn.AddYears(2) <= DateTime.Now ||
        //        (accountPaymentHistory.YearlySpend >= 1000 && accountPaymentHistory.YearlySpend <= 2000))
        //        return 0.5M;

        //    if (customerAccount.CreatedOn.AddYears(3) <= DateTime.Now ||
        //        (accountPaymentHistory.YearlySpend >= 2000 && accountPaymentHistory.YearlySpend <= 5000))
        //        return 1;

        //    if (accountPaymentHistory.YearlySpend >= 5000)
        //        return 2;

        //    if ((customerPackage.BroadbandType == BroadbandType.Basic && customerPackage.FuelType == FuelType.DualFuel) ||
        //        (customerPackage.BroadbandType == BroadbandType.HighSpeed &&
        //         customerPackage.FuelType == FuelType.Electricity) ||
        //        (customerPackage.BroadbandType == BroadbandType.HighSpeed && customerPackage.FuelType == FuelType.Gas))
        //        return 5;

        //    if (customerPackage.FuelType == FuelType.DualFuel && customerPackage.BroadbandType == BroadbandType.HighSpeed)
        //        return 10;

        //    return 0;

        //}
    }
}