using Cirrious.MvvmCross.ViewModels;
using MoneyManager.Business.Manager;

namespace MoneyManager.Business.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private readonly TransactionManager transactionManager;
        //private readonly INavigationService navigationService;

        public MvxCommand<string> GoToAddTransactionCommand { get; private set; }
        public MvxCommand GoToAddAccountCommand { get; private set; }
        
        public MainViewModel(TransactionManager transactionManager)
        {
            this.transactionManager = transactionManager;

            GoToAddTransactionCommand = new MvxCommand<string>(GoToAddTransaction);
            //GoToAddAccountCommand = new MvxCommand(() => navigationService.NavigateTo("AddAccountView"));
        }

        private void GoToAddTransaction(string type)
        {
            transactionManager.PrepareCreation(type);
            //navigationService.NavigateTo("AddTransactionView");
        }
    }
}
