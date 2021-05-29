using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BackEndExchangeWCF.DataBase.Model
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Psw { get; set; }
        [DataMember]
        public double AmountPLN { get; set; }
        [DataMember]
        public ICollection<CurrencyesDTO> Currencyes { get; set; }
        [DataMember]
        public ICollection<HistoryTransactionsDTO> Transactions { get; set; }
    }
}