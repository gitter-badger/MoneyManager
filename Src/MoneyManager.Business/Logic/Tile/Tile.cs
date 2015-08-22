using System;
using System.Threading.Tasks;
using Windows.UI.StartScreen;
using Cirrious.CrossCore;
using MoneyManager.Foundation.OperationContracts;

namespace MoneyManager.Business.Logic.Tile
{
    public abstract class Tile
    {
        protected bool Exists(string id)
        {
            return SecondaryTile.Exists(id);
        }

        protected async Task Create(SecondaryTile secondTile)
        {
            secondTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            await secondTile.RequestCreateAsync();
        }

        protected async Task Remove(SecondaryTile secondTile)
        {
            await secondTile.RequestDeleteAsync();
        }

        //TODO: make non static
        public static void UpdateMainTile()
        {
            var cashFlow = StatisticLogic.GetMonthlyCashFlow();

            Mvx.Resolve<IUserNotification>()
                .UpdateMainTile(cashFlow[0].Label, cashFlow[1].Label, cashFlow[2].Label);
        }
    }
}