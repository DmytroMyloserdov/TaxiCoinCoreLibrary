using System;
using System.Threading.Tasks;
using TaxiCoinCoreLibrary.RequestObjectPatterns;
using TaxiCoinCoreLibrary.TokenAPI;
using TaxiCoinCoreLibrary.Utils;

namespace TaxiCoinCoreLibrary.ControllerFunctions
{
    public class Balance
    {
        public static async Task<string> GetTokenBalance(User user)
        {
            ulong res;
            var contractFunctions = Globals.GetInstance().ContractFunctions;

            try
            {
                res = await contractFunctions.CallFunctionByName<UInt64>(user.PublicKey, user.PrivateKey, FunctionNames.Balance, user.PublicKey);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return res.ToString();
        }

        public static async Task<string> GetEthereumBalance(User user)
        {
            var contractFunctions = Globals.GetInstance().ContractFunctions;
            string res;

            try
            {
                res = await contractFunctions.GetUserBalance(user.PublicKey, user.PrivateKey);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return res;
        }
    }
}
