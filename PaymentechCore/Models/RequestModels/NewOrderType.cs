using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class NewOrderType
    {
        public NewOrderType() { }

        public NewOrderType(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string merchantID,
            ValidRoutingBins bin = ValidRoutingBins.Item000002,
            ValidIndustryTypes industryType = ValidIndustryTypes.EC,
            ValidTransTypes messageType = ValidTransTypes.AC,
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