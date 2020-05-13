using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class MarkForCaptureType
    {
        public MarkForCaptureType() { }

        public MarkForCaptureType(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string merchantID,
            Valid_Routing_Bins bin = Valid_Routing_Bins.Item000002,
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