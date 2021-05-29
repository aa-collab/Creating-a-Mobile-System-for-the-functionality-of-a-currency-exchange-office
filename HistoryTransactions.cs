using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndExchangeWCF.DataBase.Model
{
    public class HistoryTransactions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CodeCurr { get; set; }
        public double Amount { get; set; }
        public DateTime? Date { get; set; }
        public string Kind { get; set; }

        public virtual User User { get; set; }
    }
}