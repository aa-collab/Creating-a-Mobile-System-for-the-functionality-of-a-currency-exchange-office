using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndExchangeWCF.DataBase.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Login { get; set; }

        public string Psw { get; set; }

        public double AmountPLN { get; set; }

        virtual public ICollection<Currencyes> Currencyes { get; set; }

        virtual public ICollection<HistoryTransactions> Transactions { get; set; }
    }
}