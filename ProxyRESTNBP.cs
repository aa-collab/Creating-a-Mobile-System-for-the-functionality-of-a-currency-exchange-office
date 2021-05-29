using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BackEndExchangeWCF
{
    public class ProxyRESTNBP
    {
        public List<CurrencyType> GetCurrencies()
        {
            List<CurrencyType> currencies = new List<CurrencyType>();
            var client = new HttpClient();
            Task<HttpResponseMessage> task = client.GetAsync("http://api.nbp.pl/api/exchangerates/tables/a/");
            if (task.Result.IsSuccessStatusCode)
            {
                var res = task.Result.Content.ReadAsStringAsync().Result;
                currencies = CustomJSONDeserializator.JSONCustomDeserialisator(res);               
            }


            return currencies;
        }
    }
}