using Nethereum.RPC.Eth.DTOs;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TaxiCoinCoreLibrary.RequestObjectPatterns;
using TaxiCoinCoreLibrary.TokenAPI;
using TaxiCoinCoreLibrary.Utils;

namespace TaxiCoinCoreLibrary.ControllerFunctions
{
    public class Comission
    {
        public static async Task<string> GetCommision(ComissionControllerPattern req, User user)
        {
            ContractFunctions contractFunctions = Globals.GetInstance().ContractFunctions;
            TransactionReceipt res;
            try
            {
                res = await contractFunctions.CallFunctionByNameSendTransaction(user.PublicKey, user.PrivateKey, FunctionNames.SetComission, req.Gas, parametrsOfFunction: req.Comission);
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(e.Message);
            }

            return JsonConvert.SerializeObject(res);
        }
    }
}
