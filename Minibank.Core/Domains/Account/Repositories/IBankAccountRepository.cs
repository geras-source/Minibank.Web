using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Core.Domains.Account.Repositories
{
    public interface IBankAccountRepository
    {
        IEnumerable<BankAccount> GetAllAccounts();
        HistoryOfMoneyTransfers GetAHistory(int id);
        IEnumerable<HistoryOfMoneyTransfers> GetAllHistory();
        public void CreateAnAccount(BankAccount bankAccount);
        public void CloseAnAccount(int id, BankAccount bankAccount);
        public int CalculatingTheCommission(double amount, int fromAccountId, int toAccountId);
        public void TransferAMoney(double amount, int fromAccountId, int toAccountId);
    }
}
