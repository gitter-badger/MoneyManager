using System.Collections.ObjectModel;
using System.Linq;
using MoneyManager.Foundation.Model;
using MoneyManager.Foundation.OperationContracts;
using SettingDataAccess = MoneyManager.Business.DataAccess.SettingDataAccess;

namespace MoneyManager.Business.ViewModels
{
    public class SettingDefaultsViewModel
    {
        public ObservableCollection<Account> AllAccounts => accountRepository.Data;

        private readonly SettingDataAccess settings;
        private readonly IRepository<Account> accountRepository;

        public SettingDefaultsViewModel(SettingDataAccess settings, IRepository<Account> accountRepository)
        {
            this.settings = settings;
            this.accountRepository = accountRepository;
        }

        public Account DefaultAccount
        {
            get
            {
                return settings.DefaultAccount == -1
                    ? accountRepository.Selected
                    : AllAccounts.FirstOrDefault(x => x.Id == settings.DefaultAccount);
            }
            set { settings.DefaultAccount = value.Id; }
        }
    }
}