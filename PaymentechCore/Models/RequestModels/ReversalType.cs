using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class ReversalType
    {
        public ReversalType(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            ValidRoutingBins bin = ValidRoutingBins.Item000002,
            string terminalId = "001")
        {
            OrbitalConnectionUsername = orbitalConnectionUsername;
            OrbitalConnectionPassword = orbitalConnectionPassword;
            BIN = bin;
            TerminalID = terminalId;
        }
    }
}