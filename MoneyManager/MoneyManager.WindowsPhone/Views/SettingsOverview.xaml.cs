﻿using MoneyManager.Common;
using MoneyManager.UserControls;
using Windows.UI.Xaml.Navigation;

namespace MoneyManager.Views
{
    public sealed partial class SettingsOverview
    {
        private NavigationHelper navigationHelper;

        public SettingsOverview()
        {
            InitializeComponent();

            navigationHelper = new NavigationHelper(this);
        }

        public NavigationHelper NavigationHelper
        {
            get { return navigationHelper; }
        }

        #region NavigationHelper registration

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion NavigationHelper registration
    }
}