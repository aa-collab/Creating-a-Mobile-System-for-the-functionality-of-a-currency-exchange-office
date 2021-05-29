using BackEndExchangeWCF.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndExchangeWCF
{
    public class Maper
    {
        public static UserDTO Map(User modelObject)
        {
            UserDTO userDto = new UserDTO()
            {
                Name = modelObject.Name,
                Id = modelObject.Id,
                Login = modelObject.Login,
                Psw = modelObject.Psw,
                AmountPLN = modelObject.AmountPLN,
                Currencyes = new List<CurrencyesDTO>(),
                Transactions = new List<HistoryTransactionsDTO>()
            };
            foreach (var curr in modelObject.Currencyes)
            {
                userDto.Currencyes.Add(new CurrencyesDTO()
                {
                    UserId = curr.UserId,
                    Code = curr.Code,
                    CurrentCourse = curr.CurrentCourse,
                    Id = curr.Id,
                    Name = curr.Name,
                    Volume = curr.Volume,
                }); ;

            }
            foreach (var trans in modelObject.Transactions)
            {
                userDto.Transactions.Add(new HistoryTransactionsDTO()
                {
                    Id = trans.Id,
                    UserId = trans.UserId,
                    Date = trans.Date,
                    Amount = trans.Amount,
                    CodeCurr = trans.CodeCurr,
                    Kind = trans.Kind

                });
            }
            return userDto;
            //maping end
        }
    }
}