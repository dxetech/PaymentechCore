using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class ReversalType
    {
        public ReversalType() { }

        public ReversalType(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string merchantID,
            ValidRoutingBins bin = ValidRoutingBins.Item000002,
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