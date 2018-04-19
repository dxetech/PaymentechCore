using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class MarkForCaptureType
    {
        public MarkForCaptureType(
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