using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BackEndExchangeWCF.DataBase.Model
{
    [DataContract]
    public class HistoryTransactionsDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string CodeCurr { get; set; }
        [DataMember]
        public double Amount { get; set; }
        [DataMember]
        public DateTime? Date { get; set; }
        [DataMember]
        public string Kind { get; set; }
    }
}