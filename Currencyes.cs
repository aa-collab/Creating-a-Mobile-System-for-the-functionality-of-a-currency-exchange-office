using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndExchangeWCF.DataBase.Model
{
    public class Currencyes
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String Name { get; set; }

        public String Code { get; set; }

        public double Volume { get; set; }

        public double CurrentCourse { get; set; }

        public virtual User User { get; set; }
    }
}