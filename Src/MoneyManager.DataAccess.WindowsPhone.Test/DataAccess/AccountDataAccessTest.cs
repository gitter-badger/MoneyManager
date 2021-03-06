﻿using System.Linq;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MoneyManager.Business.DataAccess;
using MoneyManager.Foundation.Model;

namespace MoneyManager.DataAccess.WindowsPhone.Test.DataAccess
{
    [TestClass]
    public class AccountDataAccessTest
    {
        [TestInitialize]
        public void InitTests()
        {
            using (var db = SqlConnectionFactory.GetSqlConnection())
            {
                db.CreateTable<Account>();
            }
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void AccountDataAccess_CrudAccount()
        {
            var accountDataAccess = new AccountDataAccess();

            const string firstName = "fooo Name";
            const string secondName = "new Foooo";

            var account = new Account
            {
                CurrentBalance = 20,
                Iban = "CHF20 0000 00000 000000",
                Name = firstName,
                Note = "this is a note"
            };

            accountDataAccess.Save(account);

            accountDataAccess.LoadList();
            var list = accountDataAccess.LoadList();

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(firstName, list.First().Name);

            account.Name = secondName;

            accountDataAccess.Save(account);

            list = accountDataAccess.LoadList();

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(secondName, list.First().Name);

            accountDataAccess.Delete(account);

            list = accountDataAccess.LoadList();

            Assert.IsFalse(list.Any());
        }
    }
}