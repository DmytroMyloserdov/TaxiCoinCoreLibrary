using Nethereum.RPC.Eth.DTOs;
using Newtonsoft.Json;
using System;
using TaxiCoinCoreLibrary.RequestObjectPatterns;
using TaxiCoinCoreLibrary.TokenAPI;
using TaxiCoinCoreLibrary.Utils;

namespace TaxiCoinCoreLibrary.ControllerFunctions
{
    public class Order
    {
        public static string GetOrder(UInt64 id, DefaultControllerPattern req, User user)
        {
            TransactionReceipt result;
            try
            {
                result = TokenFunctionsResults<TransactionReceipt>.InvokeByTransaction(user, FunctionNames.GetOrder, req.Gas, funcParametrs: id);
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(e.Message);
            }

            return JsonConvert.SerializeObject(result);
        }

        public static string CompleteOrder(UInt64 id, DefaultControllerPattern req, User user)
        {
            TransactionReceipt result;
            try
            {
                result = TokenFunctionsResults<int>.InvokeByTransaction(user, FunctionNames.CompleteOrder, req.Gas, funcParametrs: id);
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(e.Message);
            }

            return JsonConvert.SerializeObject(result);
        }
    }
}
