using Minibank.Core.Domains.Account.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Core.Domains.Account.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public HistoryOfMoneyTransfers GetAHistory(int id)
        {
            return _bankAccountRepository.GetAHistory(id);
        }

        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return _bankAccountRepository.GetAllAccounts();
        }

        public IEnumerable<HistoryOfMoneyTransfers> GetAllHistory()
        {
            return _bankAccountRepository.GetAllHistory();
        }

        public AccountServices(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }
        public int CalculatingTheCommission(double amount, int fromAccountId, int toAccountId)
        {
            return _bankAccountRepository.CalculatingTheCommission(amount, fromAccountId, toAccountId);
        }

        public void CloseAnAccount(int id, BankAccount bankAccount)
        {
            _bankAccountRepository.CloseAnAccount(id, bankAccount);
        }

        public void CreateAnAccount(BankAccount bankAccount)
        {
            _bankAccountRepository.CreateAnAccount(bankAccount);
        }

        public void TransferAMoney(double amount, int fromAccountId, int toAccountId)
        {
            _bankAccountRepository.TransferAMoney(amount, fromAccountId, toAccountId);
        }
    }
}
