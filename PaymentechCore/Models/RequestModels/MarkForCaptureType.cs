using Newtonsoft.Json;
using PaymentechCore.Models.RequestModels.BaseModels;
using System;

namespace PaymentechCore.Models.RequestModels
{
    public class MarkForCaptureType : markForCaptureType
    {
        public MarkForCaptureType() : base() { }

        public MarkForCaptureType(string orbitalConnectionUsername, string orbitalConnectionPassword, string merchantID, validroutingbins bin = validroutingbins.Item000002, string terminalId = "001") : this()
        {
            OrbitalConnectionUsername = orbitalConnectionUsername;
            OrbitalConnectionPassword = orbitalConnectionPassword;
            MerchantID = merchantID;
            BIN = bin;
            TerminalID = terminalId;
        }

        public markForCaptureType CopyToBase()
        {
            string json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<markForCaptureType>(json);
        }
    }
}