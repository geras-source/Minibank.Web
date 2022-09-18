using Microsoft.AspNetCore.Mvc;
using Minibank.Core.Domains.Account;
using Minibank.Core.Domains.Account.Services;
using System.Collections.Generic;
using System.Linq;

namespace Minibank.Web.Controllers.Accounts
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly IAccountServices _accountServices;

        public BankAccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        [HttpPost("Create")]
        public void CreateAnAccount(AccountDto accountDto)
        {
            _accountServices.CreateAnAccount(new BankAccount 
            { 
                UserId = accountDto.UserId,
                Currency = accountDto.Currency
            });
        }

        [HttpGet("GetAll")]
        public IEnumerable<AccountDto> GetAllAccounts()
        {
            return _accountServices.GetAllAccounts().Select(it => new AccountDto()
            {
                Id = it.Id,
                UserId = it.UserId,
                Currency = it.Currency
            });
        }
        [HttpGet("GetAllHistory")]
        public IEnumerable<HistoryDto> GetAllHistory()
        {
            return _accountServices.GetAllHistory().Select(it => new HistoryDto
            {
                Id = it.Id,
                Amount = it.Amount,
                Currency = it.Currency,
                FromAccountId = it.FromAccountId,
                ToAccountId = it.ToAccountId
            });
        }
        [HttpGet("Calculate")]
        public int CalculatingTheCommission(double amount, string fromAccountId, string toAccountId)
        {
            return _accountServices.CalculatingTheCommission(amount, fromAccountId, toAccountId);
        }
        [HttpPost("Transfer")]
        public void TransferAMoney(double amount, string fromAccountId, string toAccountId)
        {
            _accountServices.TransferAMoney(amount, fromAccountId, toAccountId);
        }
        [HttpPut("Close")]
        public void CloseAnAccount(string id, BankAccount bankAccount)
        {
            _accountServices.CloseAnAccount(id, bankAccount);
        }
    }
}
