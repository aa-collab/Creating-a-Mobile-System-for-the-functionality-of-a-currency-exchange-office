using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BackEndExchangeWCF
{
    public class CustomJSONDeserializator
    {

        public static List<CurrencyType> JSONCustomDeserialisator(string JSON)
        {
            List<CurrencyType> currencies = new List<CurrencyType>();
            int lenghtOfstring = JSON.IndexOf("]}]") - JSON.IndexOf(":[") - 3;
            string[] res = JSON.Substring(JSON.IndexOf(":[") + 3, lenghtOfstring).Split(new string[] { "},{" }, StringSplitOptions.None);

            foreach(string str in res){
                string[] values = str.Split(','); // result like "currency":"yuan renminbi (Chiny)" x3
                var Name = values[0].Split(':')[1].Trim(new char[] { '"'});
                var Code = values[1].Split(':')[1].Trim(new char[] { '"' });
                var Rate = values[2].Split(':')[1].Trim(new char[] { '"' });

                double doubleRate = 0;
                double.TryParse(Rate, out doubleRate); // Parse double with dot

                currencies.Add(
                    new CurrencyType()
                    {
                        Name = Name,
                        Code = Code,
                        Rate = doubleRate
                    }); ; 

            }

            return currencies;
        }
    }
}