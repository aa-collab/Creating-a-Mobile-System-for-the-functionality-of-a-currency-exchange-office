using BackEndExchangeWCF.DataBase;
using BackEndExchangeWCF.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;

namespace BackEndExchangeWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BackEndExchangeWCF" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BackEndExchangeWCF.svc or BackEndExchangeWCF.svc.cs at the Solution Explorer and start debugging.
    public class BackEndExchangeWCF : IBackEndExchangeWCF
    {
        private ProxyRESTNBP proxyNBP = new ProxyRESTNBP();

        public int CreateUser(string name, string login, string psw)
        {
            int result = -1;
            using (var context = new ExchangeDBContext())
            {
                if (context.Users.Any(x => x.Login == login))
                {
                    result = -1; // User already exsist
                }
                else
                {
                    context.Users.Add(new User() { 
                        Name = name,
                        Login = login, 
                        Psw = psw,
                        Currencyes = new List<Currencyes>(),
                        Transactions = new List<HistoryTransactions>()
                        
                    });
                    context.SaveChanges();

                    result = 0; // User was added
                }
            }

            return result;
        }
        public int DellUserById(int Id)
        {
            int result = -1;

            using (var context = new ExchangeDBContext())
            {
               if(context.Users.Any(x => x.Id == Id))
                {
                    context.Users.Remove(context.Users.First(x => x.Id == Id));
                    //Recursive Dellett
                    context.SaveChanges();

                    result = 0;
                }
                else
                {
                    result = -1;

                }
            }
           
            return result;

        }

        public List<CurrencyType> GetCurrencies()
        {
            return proxyNBP.GetCurrencies();
        }

        public UserDTO GetUserByLoginAndPsw(string login, string psw)
        {
            using (var context = new ExchangeDBContext())
            {
                if (context.Users.Any(x => x.Login == login && x.Psw == psw))
                {
                    var modelObject = context.Users.First((x => x.Login == login && x.Psw == psw));

                    UserDTO userDto = Maper.Map(modelObject);
                    return userDto;
                }
                else
                {
                    return null;

                }
            }
        }
        public int UpdateUser(UserDTO userDTO)
        {
            int result = -1;
            using (var context = new ExchangeDBContext())
            {
                if (context.Users.Any(x => x.Id == userDTO.Id))
                {
                    User userModel = context.Users.First(x => x.Id == userDTO.Id);
                    userModel.Login = userDTO.Login;
                    userModel.Psw = userDTO.Psw;
                    userModel.Name = userDTO.Name;
                    userModel.AmountPLN = userDTO.AmountPLN;
                    context.SaveChanges();
                    result = 0;
                }
                else
                {
                    result = -1;
                }
                return result;
            }

        }
        public int DellCurrenciesById(int userId, int CurrencyesId)
        {
            int result = -1;
            using (var context = new ExchangeDBContext())
            {
                if(context.Users.Any(x => x.Id == userId) && context.Currencyes.Any(x => x.Id == CurrencyesId))
                {
                    var user = context.Users.First(x => x.Id == userId);
                    //recursive delete 
                    user.Currencyes.Remove(user.Currencyes.First(x => x.Id == CurrencyesId));
                    context.Currencyes.Remove(context.Currencyes.First(x => x.UserId == user.Id));
                    context.SaveChanges();
                    result = 0;
                }
                else
                {
                    result = -1;
                }
            }
            return result;
        }

       
        public int AddCurrencies(int userId, CurrencyesDTO currencyesDTO)
        {
            int result = -1;
            using (var context = new ExchangeDBContext())
            {
                var userModel = context.Users.First(x => x.Id == userId);
                userModel.Currencyes.Add(new Currencyes
                {
                    Code = currencyesDTO.Code,
                    CurrentCourse = currencyesDTO.CurrentCourse,
                    Name = currencyesDTO.Name,
                    Volume = currencyesDTO.Volume,                
                });
                context.SaveChanges();
                result = 0;
            }
            return result;
        }

        public int AddTransaction(int userId, HistoryTransactionsDTO transactionsDTO)
        {
            int result = -1;
            using (var context = new ExchangeDBContext())
            {
                 var userModel = context.Users.First(x => x.Id == userId);
                userModel.Transactions.Add(new HistoryTransactions
                {
                   CodeCurr = transactionsDTO.CodeCurr,
                   Amount = transactionsDTO.Amount,
                   Date = transactionsDTO.Date, 
                   Kind = transactionsDTO.Kind
                   
                });
                context.SaveChanges();
                result = 0;
            }
            return result;
        }



    }
}
