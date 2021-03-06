﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MoneyManager.Core.Logic;
using MoneyManager.Foundation;

namespace MoneyManager.Windows.Views
{
    public sealed partial class TransactionListView
    {
        public TransactionListView()
        {
            InitializeComponent();
        }

        //TODO: move to view model
        private void AddSpendingClick(object sender, RoutedEventArgs e)
        {
            AddTransaction(TransactionType.Spending);
        }

        //TODO: move to view model
        private void AddIncomeClick(object sender, RoutedEventArgs e)
        {
            AddTransaction(TransactionType.Income);
        }

        //TODO: move to view model
        private void AddTransferClick(object sender, RoutedEventArgs e)
        {
            AddTransaction(TransactionType.Transfer);
        }

        private static void AddTransaction(TransactionType type)
        {
            TransactionLogic.GoToAddTransaction(type, true);
            ((Frame) Window.Current.Content).Navigate(typeof (AddTransactionView));
        }
    }
}