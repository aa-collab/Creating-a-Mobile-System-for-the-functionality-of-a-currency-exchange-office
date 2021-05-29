using BackEndExchangeWCF.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BackEndExchangeWCF.DataBase
{
    public class ExchangeDBContext : DbContext
    {
        public ExchangeDBContext() : base("MyConnectionString") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Currencyes> Currencyes { get; set; }
        public DbSet<HistoryTransactions> HistoryTransactions { get; set; }
    }
}