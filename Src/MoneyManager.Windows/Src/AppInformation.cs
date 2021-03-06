﻿using System.Globalization;
using Windows.ApplicationModel;
using MoneyManager.Foundation.OperationContracts;

namespace MoneyManager.Windows
{
    public class AppInformation : IAppInformation
    {
        public string GetVersion
        {
            get
            {
                var version = Package.Current.Id.Version;

                return string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}.{1}.{2}.{3}",
                    version.Major,
                    version.Minor,
                    version.Build,
                    version.Revision);
            }
        }
    }
}