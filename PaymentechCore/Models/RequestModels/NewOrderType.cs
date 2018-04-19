using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class NewOrderType
    {
        public NewOrderType(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            ValidRoutingBins bin = ValidRoutingBins.Item000002,
            ValidIndustryTypes industryType = ValidIndustryTypes.EC,
            ValidTransTypes messageType = ValidTransTypes.AC,
            string terminalId = "001",
            string currencyCode = "840",
            string currencyEndpoint = "2")
        {
            OrbitalConnectionUsername = orbitalConnectionUsername;
            OrbitalConnectionPassword = orbitalConnectionPassword;
            BIN = bin;
            IndustryType = industryType;
            MessageType = messageType;
            TerminalID = terminalId;
            CurrencyCode = currencyCode;
            CurrencyExponent = currencyEndpoint;
        }
    }
}