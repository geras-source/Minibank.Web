using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Core.Domains.Account.Services
{
    public interface IAccountServices
    {
        IEnumerable<BankAccount> GetAllAccounts();
        public HistoryOfMoneyTransfers GetAHistory(string id);
        IEnumerable<HistoryOfMoneyTransfers> GetAllHistory();
        public void CreateAnAccount(BankAccount bankAccount);
        public void CloseAnAccount(string id, BankAccount bankAccount);
        public int CalculatingTheCommission(double amount, string fromAccountId, string toAccountId);
        public void TransferAMoney(double amount, string fromAccountId, string toAccountId);
    }
}
