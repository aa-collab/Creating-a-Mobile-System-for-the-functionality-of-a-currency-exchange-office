using BackEndExchangeWCF.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BackEndExchangeWCF
{
    [ServiceContract]
    public interface IBackEndExchangeWCF
    {
        [OperationContract]
        List<CurrencyType> GetCurrencies();
        [OperationContract]
        int CreateUser(string name, string login, string psw);
        [OperationContract]
        int UpdateUser(UserDTO user);
        [OperationContract]
        int DellUserById(int Id);
        [OperationContract]
        UserDTO GetUserByLoginAndPsw(string login, string psw);
        [OperationContract]
        int AddCurrencies(int userId, CurrencyesDTO currencyesDTO);
        [OperationContract]
        int DellCurrenciesById(int userId, int CurrencyesId);
        [OperationContract]
        int AddTransaction(int userId, HistoryTransactionsDTO transactionsDTO);
       

    }
}
