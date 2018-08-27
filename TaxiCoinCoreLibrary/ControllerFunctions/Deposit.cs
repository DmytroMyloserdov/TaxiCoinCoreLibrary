using Nethereum.RPC.Eth.DTOs;
using Newtonsoft.Json;
using System;
using TaxiCoinCoreLibrary.RequestObjectPatterns;
using TaxiCoinCoreLibrary.TokenAPI;
using TaxiCoinCoreLibrary.Utils;

namespace TaxiCoinCoreLibrary.ControllerFunctions
{
    public class Deposit
    {
        public static string DepositToContract(DepositPattern req, User user)
        {
            TransactionReceipt result;
            try
            {
                result = TokenFunctionsResults<UInt64>.InvokeByTransaction(user, FunctionNames.Deposit, Value: req.Value, Gas: req.Gas);
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(e.Message);
            }

            return JsonConvert.SerializeObject(result);
        }
    }
}
