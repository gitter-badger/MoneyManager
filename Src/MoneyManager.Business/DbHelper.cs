using System.IO;
using Windows.Storage;
using MoneyManager.Foundation.Model;
using MoneyManager.Foundation.OperationContracts;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;

namespace MoneyManager.Business
{
    public class DbHelper : IDbHelper
    {
        private static readonly string DbPath =
            Path.Combine(ApplicationData.Current.LocalFolder.Path, "moneyfox.sqlite");

        /// <summary>
        ///     Creates an instance of a DbHelper
        /// </summary>
        public DbHelper()
        {
            CreateDatabase();
        }

        /// <summary>
        ///     Returns an SQLite Connection to access the database.
        /// </summary>
        /// <returns>Established database connection.</returns>
        public SQLiteConnection GetSqlConnection()
        {
            return new SQLiteConnection(new SQLitePlatformWinRT(), DbPath);
            //return new SQLiteConnection(Mvx.Resolve<ISQLitePlatform>(), Mvx.Resolve<IDatabasePath>().DbPath);
        }

        /// <summary>
        ///     Creates a new SQLite db file
        /// </summary>
        public void CreateDatabase()
        {
            using (SQLiteConnection db = GetSqlConnection())
            {
                db.CreateTable<Account>();
                db.CreateTable<FinancialTransaction>();
                db.CreateTable<RecurringTransaction>();
                db.CreateTable<Category>();
            }
        }
    }
}