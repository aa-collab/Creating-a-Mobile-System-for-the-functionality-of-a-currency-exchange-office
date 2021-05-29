using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BackEndExchangeWCF.DataBase.Model
{
    [DataContract]
    public class CurrencyesDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String Code { get; set; }
        [DataMember]
        public double Volume { get; set; }
        [DataMember]
        public double CurrentCourse { get; set; }

    }
}