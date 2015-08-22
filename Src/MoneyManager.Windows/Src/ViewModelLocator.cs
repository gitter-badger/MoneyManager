using Cirrious.CrossCore;
using MoneyManager.Business.ViewModels;

namespace MoneyManager.Windows
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => Mvx.Resolve<MainViewModel>();

        public AddAccountViewModel AddAccountViewModel => Mvx.Resolve<AddAccountViewModel>();

        public AccountListUserControlViewModel AccountListUserControlViewModel => Mvx.Resolve<AccountListUserControlViewModel>();

        public AddTransactionViewModel AddTransactionViewModel => Mvx.Resolve<AddTransactionViewModel>();

        public BalanceViewModel BalanceViewModel => Mvx.Resolve<BalanceViewModel>();

        public CategoryListViewModel CategoryListViewModel => Mvx.Resolve<CategoryListViewModel>();

        public TransactionListViewModel TransactionListViewModel => Mvx.Resolve<TransactionListViewModel>();

        public TileSettingsViewModel TileSettingsViewModel => Mvx.Resolve<TileSettingsViewModel>();

        public GeneralSettingViewModel GeneralSettingViewModel => Mvx.Resolve<GeneralSettingViewModel>();

        public SettingDefaultsViewModel SettingDefaultsViewModel => Mvx.Resolve<SettingDefaultsViewModel>();

        public StatisticViewModel StatisticViewModel => Mvx.Resolve<StatisticViewModel>();

        public BackupViewModel BackupViewModel => Mvx.Resolve<BackupViewModel>();
    }
}
