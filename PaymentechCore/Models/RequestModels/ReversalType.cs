using Newtonsoft.Json;
using PaymentechCore.Models.RequestModels.BaseModels;
using System;

namespace PaymentechCore.Models.RequestModels
{
    public class ReversalType : reversalType
    {
        public ReversalType() { }

        public ReversalType(string orbitalConnectionUsername, string orbitalConnectionPassword, string merchantID, validroutingbins bin = validroutingbins.Item000002, string terminalId = "001") : base()
        {
            OrbitalConnectionUsername = orbitalConnectionUsername;
            OrbitalConnectionPassword = orbitalConnectionPassword;
            MerchantID = merchantID;
            BIN = bin;
            TerminalID = terminalId;
        }

        public reversalType CopyToBase()
        {
            string json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<reversalType>(json);
        }
    }
}