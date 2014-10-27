using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MoneyManager.Business.Src
{
    [DataContract]
    public class CurrencyServiceDTO
    {
        [DataMember(Name = "items")]
        public List<CurrencyDTO> items { get; set; }
    }

    [DataContract(Name = "results")]
    public class CurrencyDTO
    {
        [DataMember(Name = "currencyId")]
        public string CurrencyShortName { get; set; }

        [DataMember(Name = "currencyName")]
        public string CurrencyName { get; set; }

        [DataMember(Name = "name")]
        public string CountryName { get; set; }

        [DataMember(Name = "alpha3")]
        public string CountryAlpha3 { get; set; }

        [DataMember(Name = "id")]
        public string CountryShortName { get; set; }
    }
}