using PaymentechCore.Models.RequestModels.BaseModels;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace PaymentechCore.Models.RequestModels
{
    [Serializable]
    public class NewOrderType : newOrderType
    {
        public NewOrderType() : base() { }

        public NewOrderType(string orbitalConnectionUsername, string orbitalConnectionPassword, string merchantID, validroutingbins bin = validroutingbins.Item000002, validindustrytypes industryType = validindustrytypes.EC, validtranstypes messageType = validtranstypes.AC, string terminalId = "001", string currencyCode = "840", string currencyEndpoint = "2") : this()
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

        public newOrderType CopyToBase()
        {
            string json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<newOrderType>(json);
        }
    }
}