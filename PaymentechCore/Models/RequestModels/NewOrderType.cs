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
            Valid_Routing_Bins bin = Valid_Routing_Bins.Item000002,
            Valid_Industry_Types industryType = Valid_Industry_Types.EC,
            Valid_Trans_Types messageType = Valid_Trans_Types.AC,
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