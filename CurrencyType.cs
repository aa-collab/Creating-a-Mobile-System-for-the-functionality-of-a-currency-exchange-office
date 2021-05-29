using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BackEndExchangeWCF
{
    [DataContract]
    public class CurrencyType
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public double Rate { get; set; }
    }
}