using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class NewOrderType
    {
        public NewOrderType()
        {
            IndustryType = ValidIndustryTypes.EC;
            MessageType = ValidTransTypes.AC;
            TerminalID = "001";
            CurrencyCode = "840";
            CurrencyExponent = "2";
        }
    }
}