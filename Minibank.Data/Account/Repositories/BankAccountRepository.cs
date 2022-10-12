using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Minibank.Core;
using Minibank.Core.Domains.Account;
using Minibank.Core.Domains.Account.Repositories;
using Minibank.Core.Domains.Users.Services;

namespace Minibank.Data.Account.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly static List<BankAccountDbModel> _bankAccountDbModel = new List<BankAccountDbModel>();
        private readonly static List<HistoryDbModel> _historyDbModel = new List<HistoryDbModel>();
        private readonly IUserServices _userServices;
        private readonly IConvector _convector;

        public BankAccountRepository(IUserServices userServices, IConvector convector)
        {
            _userServices = userServices;
            _convector = convector;
        }
        public void CreateAnAccount(BankAccount bankAccount)
        {
            if (bankAccount.Currency != "RUB" && bankAccount.Currency != "USD" && bankAccount.Currency != "EUR") { throw new ValidationException(); }

            if (_userServices.GetAsync(bankAccount.UserId) == null) { throw new Exception("Данного пользователя не существует"); }

            var entity = new BankAccountDbModel
            {
                Id = 6,
                UserId = bankAccount.UserId,
                Amount = 500,
                Currency = bankAccount.Currency,
                IsClosed = false,
                DateOfOpening = DateTime.Now,
            };

            _bankAccountDbModel.Add(entity);
        }
        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return _bankAccountDbModel.Select(it => new BankAccount()
            {
                Id = it.Id,
                UserId = it.UserId,
                Amount = it.Amount,
                Currency = it.Currency,
                IsClosed = it.IsClosed,
                DateOfOpening = it.DateOfOpening,
                DateOfClosing = it.DateOfClosing
            });
        }
        public HistoryOfMoneyTransfers GetAHistory(int id)
        {
            var entitiy = _historyDbModel.FirstOrDefault(it => it.Id == id);

            if (entitiy == null) { return null; }

            return new HistoryOfMoneyTransfers
            {
                Amount = entitiy.Amount,
                Currency = entitiy.Currency,
                FromAccountId = entitiy.FromAccountId,
                ToAccountId = entitiy.ToAccountId
            };
        }
        public IEnumerable<HistoryOfMoneyTransfers> GetAllHistory()
        {
            return _historyDbModel.Select(it => new HistoryOfMoneyTransfers
            {
                Id = it.Id,
                Amount = it.Amount,
                Currency = it.Currency,
                FromAccountId = it.FromAccountId,
                ToAccountId = it.ToAccountId
            });
        }

        public int CalculatingTheCommission(double amount, int fromAccountId, int toAccountId) // заменить на userID
        {
            var fromEntity = _bankAccountDbModel.FirstOrDefault(it => it.Id == fromAccountId);
            var ToEntity = _bankAccountDbModel.FirstOrDefault(it => it.Id == toAccountId);

            if (fromEntity.UserId == ToEntity.UserId) { return 0; }

            return (int)((int)amount * 0.02);
        }
        public void TransferAMoney(double amount, int fromAccountId, int toAccountId)
        {
            var fromEntity = _bankAccountDbModel.FirstOrDefault(it => it.Id == fromAccountId);
            var ToEntity = _bankAccountDbModel.FirstOrDefault(it => it.Id == toAccountId);

            if(fromEntity.UserId != ToEntity.UserId)
            {
                amount -= amount * 0.02;
            }
            fromEntity.Amount -= amount;

            if (fromEntity.Currency != ToEntity.Currency)
            {
                amount = _convector.Convert(amount, fromEntity.Currency, ToEntity.Currency);
            }
            
            ToEntity.Amount += amount;

            var historyEntity = new HistoryDbModel
            {
                Id = 5,//TODO:
                Amount = amount,
                Currency = fromEntity.Currency,
                FromAccountId = fromAccountId,
                ToAccountId = toAccountId
            };

            _historyDbModel.Add(historyEntity);
        }

        public void CloseAnAccount(int id, BankAccount bankAccount)
        {
            var entity = _bankAccountDbModel.FirstOrDefault(it => it.Id == id);

            if (entity != null || entity.Amount == 0)
            {
                bankAccount.IsClosed = false;
            }
        }
    }
}