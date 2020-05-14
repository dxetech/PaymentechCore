using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class reversalType
    {
        public reversalType() { }

        public reversalType(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string merchantID,
            validroutingbins bin = validroutingbins.Item000002,
            string terminalId = "001") : base()
        {
            OrbitalConnectionUsername = orbitalConnectionUsername;
            OrbitalConnectionPassword = orbitalConnectionPassword;
            MerchantID = merchantID;
            BIN = bin;
            TerminalID = terminalId;
        }
    }
}