using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using MoneyManager.Business.DataAccess;
using MoneyManager.Business.Helper;
using MoneyManager.Foundation;
using MoneyManager.Foundation.Model;
using MoneyManager.Foundation.OperationContracts;
using PropertyChanged;

namespace MoneyManager.Business.ViewModels
{
    [ImplementPropertyChanged]
    public class BalanceViewModel : ViewModelBase
    {
        public double TotalBalance { get; set; }
        public double EndOfMonthBalance { get; set; }
        public bool IsTransactionView { private get; set; }
        public string CurrencyCulture => settings.DefaultCurrency;

        private readonly ITransactionRepository transactionRepository;
        private readonly IRepository<Account> accountRepository;
        private readonly SettingDataAccess settings;

        public BalanceViewModel(ITransactionRepository transactionRepository, IRepository<Account> accountRepository, SettingDataAccess settings)
        {
            this.transactionRepository = transactionRepository;
            this.accountRepository = accountRepository;
            this.settings = settings;
        }

        public void UpdateBalance()
        {
            TotalBalance = GetTotalBalance();
            EndOfMonthBalance = GetEndOfMonthValue();
        }

        private double GetTotalBalance()
        {
            if (IsTransactionView)
            {
                return accountRepository.Selected.CurrentBalance;
            }

            return accountRepository.Data?.Sum(x => x.CurrentBalance) ?? 0;
        }

        private double GetEndOfMonthValue()
        {
            var balance = TotalBalance;
            var unclearedTransactions = LoadUnclreadTransactions();

            foreach (var transaction in unclearedTransactions)
            {
                switch (transaction.Type)
                {
                    case (int) TransactionType.Spending:
                        balance -= transaction.Amount;
                        break;

                    case (int) TransactionType.Income:
                        balance += transaction.Amount;
                        break;

                    case (int) TransactionType.Transfer:
                        balance = HandleTransferAmount(transaction, balance);
                        break;
                }
            }

            return balance;
        }

        private double HandleTransferAmount(FinancialTransaction transaction, double balance)
        {
            if (accountRepository.Selected == transaction.ChargedAccount)
            {
                balance -= transaction.Amount;
            }
            else
            {
                balance += transaction.Amount;
            }
            return balance;
        }

        private IEnumerable<FinancialTransaction> LoadUnclreadTransactions()
        {
            var unclearedTransactions =
                transactionRepository.GetUnclearedTransactions(Utilities.GetEndOfMonth());

            return IsTransactionView
                ? unclearedTransactions.Where(
                    x => x.ChargedAccountId == accountRepository.Selected.Id || x.TargetAccountId == accountRepository.Selected.Id).ToList()
                : unclearedTransactions;
        }
    }
}