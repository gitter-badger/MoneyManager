using GalaSoft.MvvmLight;
using MoneyManager.Business.Logic.Tile;
using PropertyChanged;
using SettingDataAccess = MoneyManager.Business.DataAccess.SettingDataAccess;

namespace MoneyManager.Business.ViewModels
{
    /// <summary>
    ///     Provides the information for the TileSettingsView
    /// </summary>
    [ImplementPropertyChanged]
    public class TileSettingsViewModel : ViewModelBase
    {
        private readonly SettingDataAccess settingDataAccess;

        /// <summary>
        ///     Creates a TileSettingsViewModel object
        /// </summary>
        /// <param name="settingDataAccess">Instance of settingDataAccess</param>
        public TileSettingsViewModel(SettingDataAccess settingDataAccess)
        {
            this.settingDataAccess = settingDataAccess;
        }

        /// <summary>
        ///     Returns the setting if the Cash Flow shall be displayed on the tile
        /// </summary>
        public bool ShowInfoOnMainTile
        {
            get { return settingDataAccess.ShowCashFlowOnMainTile; }
            set { SetValue(value); }
        }

        /// <summary>
        ///     Creates an IncomeTile object
        /// </summary>
        public IncomeTile IncomeTile => new IncomeTile();

        /// <summary>
        ///     Creates an SpendingTile object
        /// </summary>
        public SpendingTile SpendingTile => new SpendingTile();

        /// <summary>
        ///     Creates a TransferTile Object
        /// </summary>
        public TransferTile TransferTile => new TransferTile();

        private void SetValue(bool value)
        {
            settingDataAccess.ShowCashFlowOnMainTile = value;
        }
    }
}