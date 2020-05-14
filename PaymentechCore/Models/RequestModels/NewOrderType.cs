using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class newOrderType
    {
        public newOrderType() { }

        public newOrderType(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string merchantID,
            validroutingbins bin = validroutingbins.Item000002,
            validindustrytypes industryType = validindustrytypes.EC,
            validtranstypes messageType = validtranstypes.AC,
            string terminalId = "001",
            string currencyCode = "840",
            string currencyEndpoint = "2") : base()
        {
            OrbitalConnectionUsername = orbitalConnectionUsername;
            OrbitalConnectionPassword = orbitalConnectionPassword;
            MerchantID = merchantID;
            BIN = bin;
            IndustryType = industryType;
            MessageType = messageType;
            TerminalID = terminalId;
            CurrencyCode = currencyCode;
            CurrencyExponent = currencyEndpoint;
        }
    }
}